using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewServer
{
    public partial class FormMain : Form
    {
        IPAddress _serverIP = IPAddress.Parse("0.0.0.0");
        int _serverPort = 0;

        private Socket _socketListen = null;
        private List<Socket> _listClient = new List<Socket>();
        private Thread threadListenConnect = null;
        private Thread threadReceivePacket = null;
        string _leftPacket = "";
        public FormMain()
        {
            InitializeComponent();
            IPHostEntry ipHostEntry = Dns.GetHostEntry(Dns.GetHostName());
            comboBoxServerIP.DataSource = ipHostEntry.AddressList;

            comboBoxServerIP.Text = ipHostEntry.AddressList[0].ToString();
        }

        private void buttonStartListen_Click(object sender, EventArgs e)
        {
            try
            {
                _socketListen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                //_serverIP = IPAddress.Parse("127.0.0.1");
                _serverIP = IPAddress.Parse(comboBoxServerIP.Text);
                _serverPort = Convert.ToInt32(numericUpDown1.Text);
                IPEndPoint ipEndPoint = new IPEndPoint(_serverIP, _serverPort);
                _socketListen.Bind(ipEndPoint);

                threadListenConnect = new Thread(ServerListenConnect);
                threadListenConnect.IsBackground = true;

                threadListenConnect.Start();

                buttonStartListen.Text = "监听中";
                comboBoxServerIP.Enabled = false;
                numericUpDown1.Enabled = false;
                buttonStartListen.Enabled = false;
            }
            catch (Exception excep)
            {
                MessageBox.Show(this, excep.Message+ _serverIP.ToString(), "buttonStartListen_Click异常", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ServerListenConnect()
        {
            while (true)
            {
                try
                {
                    _socketListen.Listen(20);
                    Socket socket = _socketListen.Accept();
                    _listClient.Add(socket);

                    /*
                    IPAddress ip = ((IPEndPoint)socket.RemoteEndPoint).Address;
                    int port = ((IPEndPoint)socket.RemoteEndPoint).Port;
                    MessageBox.Show(this, ip.ToString() + "已经通过" + port.ToString() +
                        "端口连接到服务器！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     */

                    threadReceivePacket = new Thread(ServerReceivePaket);

                    threadReceivePacket.IsBackground = true;
                    threadReceivePacket.Start(socket);
                }
                catch (Exception excep)
                {
                    MessageBox.Show(this, excep.Message, "ServerListenConnect异常", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        public void SlicePacket(string originalPacket, out string validPacket, out string leftPacket)
        {
            int headPos = -1, tailPos = -1;
            headPos = originalPacket.IndexOf('\a');
            if (headPos == -1)
            {
                validPacket = "";
                leftPacket = originalPacket;
                return;
            }
            tailPos = originalPacket.IndexOf('\t', headPos);
            if (tailPos == -1)
            {
                validPacket = "";
                leftPacket = originalPacket;
                return;
            }

            validPacket = originalPacket.Substring(headPos + 1, tailPos - headPos - 1);
            leftPacket = originalPacket.Remove(headPos) + originalPacket.Remove(0, tailPos + 1);
        }

        private void ServerReceivePaket(object objSocket)
        {
            while (true)
            {
                Socket socket = (Socket)objSocket;
                if (socket.Connected == true)
                {
                    byte[] bytePacket = new byte[4000];
                    int length = socket.Receive(bytePacket);
                    String receivePacket = Encoding.UTF8.GetString(bytePacket, 0, length);

                    string validPacket = "", totalPacket = "";
                    totalPacket = _leftPacket + receivePacket;
                    do
                    {
                        SlicePacket(totalPacket, out validPacket, out _leftPacket);
                        totalPacket = _leftPacket;
                        if(validPacket!="")
                        {
                            ListViewItem item = new ListViewItem(receivePacket);
                            listViewPaket.Items.Add(item);

                            IPAddress fromIp, toIp; int fromPort, toPort; string content = "";
                            bool result = DecodePacket(validPacket, out fromIp, out fromPort, out toIp, out toPort, out content);
                            //MessageBox.Show(result.ToString()+content);
                            if (result == true)
                            {
                                if (toIp.Equals(_serverIP) == true && toPort.Equals(_serverPort) == true)
                                {

                                }
                                else if (toIp.Equals(IPAddress.Parse("255.255.255.255")) == true)
                                {
                                    ServerRelayBroadcastPacket(content, fromIp, fromPort);
                                }
                                else
                                    ServerRelayPtpPacket(content, fromIp, fromPort, toIp, toPort);

                                if (content.IndexOf("新人报到") == 0)
                                {
                                    string nickName = content.Remove(0, 5);

                                    AddItemToListViewClient(nickName, fromIp, fromPort);
                                    /*
                                    ListViewItem item2 = new ListViewItem(nickName);
                                    item2.SubItems.Add(fromIp.ToString());
                                    item2.SubItems.Add(fromPort.ToString());
                                    listViewClient.Items.Add(item2);
                                    */
                                }
                                else if (content.IndexOf("我下线了") == 0)
                                {
                                    RemoveItemFromListViewClient(fromIp, fromPort);
                                    RemoveNodeFromListClient(socket);
                                    return;
                                }
                            }
                        }
                    } while (validPacket != "");

                   
                    //MessageBox.Show(this, "收到数据包：" + receivePacket, "数据包", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        //服务器转发点对点数据包到某个客户端
        public void ServerRelayPtpPacket(string content, IPAddress fromIp, int fromPort, IPAddress toIp, int toPort)
        {
            for (int i = 0; i <= _listClient.Count - 1; i++)
            {
                if (_listClient[i] != null && _listClient[i].Connected == true)
                {
                    try
                    {
                        IPAddress ip = ((IPEndPoint)_listClient[i].RemoteEndPoint).Address;
                        int port = ((IPEndPoint)_listClient[i].RemoteEndPoint).Port;

                        if (ip.Equals(toIp) != true || port != toPort) continue;

                        string sendPacket = "\a"+fromIp.ToString() + "|" + fromPort.ToString() + "|"
                            + toIp.ToString() + "|" + toPort.ToString() + "|" + content+"\t";
                        byte[] buffer = Encoding.UTF8.GetBytes(sendPacket);
                        _listClient[i].Send(buffer);
                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show(this, excep.Message, "ServerRelayPtpPacket异常", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        //发送广播数据包到所有客户端
        public void ServerRelayBroadcastPacket(string content,IPAddress fromIp,int fromPort)
        {
            for (int i = 0; i <= _listClient.Count - 1; i++)
            {
                if (_listClient[i] != null && _listClient[i].Connected == true)
                {
                    try
                    {
                        IPAddress ip = ((IPEndPoint)_listClient[i].RemoteEndPoint).Address;
                        int port = ((IPEndPoint)_listClient[i].RemoteEndPoint).Port;
                        if (fromIp.Equals(ip) && fromPort == port) continue;
                        string sendPacket = "\a"+fromIp.ToString() + "|" + fromPort.ToString() + "|"
                            + ip.ToString() + "|" + port.ToString() + "|" + content+"\t";
                        byte[] buffer = Encoding.UTF8.GetBytes(sendPacket);
                        _listClient[i].Send(buffer);
                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show(this, excep.Message, "ServerRelayBroadcastPacket异常", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        //发送广播数据包到所有客户端
        public void ServerRelayBroadcastPacket(string content)
        {
            for (int i = 0; i <= _listClient.Count - 1; i++)
            {
                if (_listClient[i] != null && _listClient[i].Connected == true)
                {
                    try
                    {
                        IPAddress ip = ((IPEndPoint)_listClient[i].RemoteEndPoint).Address;
                        int port = ((IPEndPoint)_listClient[i].RemoteEndPoint).Port;
                        string sendPacket = "\a" + _serverIP.ToString() + "|" + _serverPort.ToString() + "|"
                            + ip.ToString() + "|" + port.ToString() + "|" + content+"\t";
                        byte[] buffer = Encoding.UTF8.GetBytes(sendPacket);
                        _listClient[i].Send(buffer);
                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show(this, excep.Message, "ServerRelayBroadcastPacket异常", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }


        public bool DecodePacket(string packet, out IPAddress fromIp, out int fromPort, out IPAddress toIp, out int toPort, out string content)
        {
            int cnt = 0;
            int[] pos = new int[4];
            for (int i = 0; i <= packet.Length-1; i++)
            {
                if (packet[i] == '|')
                {
                    pos[cnt] = i;
                    cnt++;
                    if (cnt >= 4) break;
                }
            }
           
            //
           // MessageBox.Show(cnt.ToString()+flag.ToString());
            if (cnt >= 4)
            {
                try
                {
                    fromIp = IPAddress.Parse(packet.Substring(0, pos[0] - 0));
                    fromPort = Convert.ToInt32(packet.Substring(pos[0] + 1, pos[1] - pos[0] - 1));
                    toIp = IPAddress.Parse(packet.Substring(pos[1] + 1, pos[2] - pos[1] - 1));
                    toPort = Convert.ToInt32(packet.Substring(pos[2] + 1, pos[3] - pos[2] - 1));
                    content = packet.Remove(0, pos[3] + 1);     
                    return true;
                }
                catch (Exception excep)
                {
                    //MessageBox.Show(this, excep.Message, "ServerRelayBroadcastPacket异常", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fromIp = IPAddress.Parse("0.0.0.0");
                    fromPort = 0;
                    toIp = IPAddress.Parse("0.0.0.0");
                    toPort = 0;
                    content = "";
                    return false;
                }
            }
            else
            {
                //MessageBox.Show(cnt.ToString());
                fromIp = IPAddress.Parse("0.0.0.0");
                fromPort = 0;
                toIp = IPAddress.Parse("0.0.0.0");
                toPort = 0;
                content = "";
                return false;
            }

        }

        public void RemoveItemFromListViewClient(IPAddress ip, int port)
        {
            for (int i = 0; i < listViewClient.Items.Count; i++)
            {
                if (listViewClient.Items[i].SubItems[1].Text == ip.ToString() && listViewClient.Items[i].SubItems[2].Text == port.ToString())
                {
                    listViewClient.Items.RemoveAt(i);
                    return;
                }
            }
        }

        public void AddItemToListViewClient(string nick, IPAddress ip, int port)
        {
            for (int i = 0; i < listViewClient.Items.Count; i++)
            {
                if (listViewClient.Items[i].SubItems[1].Text == ip.ToString() && listViewClient.Items[i].SubItems[2].Text == port.ToString())
                {
                    listViewClient.Items[i].Text = nick;
                    return;
                }
            }

            ListViewItem item = new ListViewItem(nick);
            item.SubItems.Add(ip.ToString());
            item.SubItems.Add(port.ToString());
            listViewClient.Items.Add(item);
        }

        public void RemoveNodeFromListClient(Socket socket)
        {
            for (int i = _listClient.Count - 1; i >= 0; i--)
            {
                if (_listClient[i] == socket)
                {
                    try
                    {
                        if (_listClient[i] != null)
                            _listClient[i].Close();
                        _listClient.RemoveAt(i);
                        return;
                    }
                    catch (Exception excep)
                    {

                    }
                }
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(this, "需要关闭程序吗？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
            else
            {
                try
                {
                    ServerRelayBroadcastPacket("服务器关闭|");

                    if (_socketListen != null) _socketListen.Close();
                    for (int i = 0; i < _listClient.Count; i++)
                        if (_listClient[i] != null)
                            _listClient[i].Close();
                }
                catch (Exception excep)
                {
                    MessageBox.Show(this, excep.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
