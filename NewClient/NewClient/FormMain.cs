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

namespace NewClient
{
    public partial class FormMain : Form
    {
        private Socket _socketClient = null;
        private Thread threadReceivePacket = null;

        private IPAddress _localIP = IPAddress.Parse("0.0.0.0");
        private int _localPort = 0;
        private string _localNickName = "";

        private IPAddress _serveerIP= IPAddress.Parse("0.0.0.0");
        private int _serverPort = 0;

        string _leftPacket = "";
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                _socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                IPAddress serverIP = IPAddress.Parse(textBoxServerIP.Text);
                int serverPort = Convert.ToInt32(numericUpDownUpDownServerPort.Text);
                IPEndPoint ipEndPoint = new IPEndPoint(serverIP, serverPort);
                _socketClient.Connect(ipEndPoint);

                threadReceivePacket = new Thread(new ThreadStart(ClientReceivePakcet));

                threadReceivePacket.IsBackground = true;
                threadReceivePacket.Start();

                _localIP = ((IPEndPoint)_socketClient.LocalEndPoint).Address;
                _localPort = ((IPEndPoint)_socketClient.LocalEndPoint).Port;
                _localNickName = textBoxNickName.Text;

                _serveerIP = ((IPEndPoint)_socketClient.RemoteEndPoint).Address;
                _serverPort = ((IPEndPoint)_socketClient.RemoteEndPoint).Port;

                textBoxNickName.Enabled = false;
                textBoxServerIP.Enabled = false;
                numericUpDownUpDownServerPort.Enabled = false;
                buttonLogIn.Enabled = false;
                buttonLoginOut.Enabled = true;

                ClientSendBroadcastPacket("新人报到|" + _localNickName);
            }
            catch (Exception excep)
            {
                MessageBox.Show(this, excep.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //接收服务器数据包
        private void ClientReceivePakcet()
        {
            while(true)
            {
                try
                {
                    if (_socketClient.Connected == true)
                    {
                        byte[] bytePacket = new byte[4000];
                        int length = _socketClient.Receive(bytePacket);

                        String receivePacket = Encoding.UTF8.GetString(bytePacket, 0, length);
                        string validPacket = "",totalPacket = "";
                        totalPacket = _leftPacket + receivePacket;
                        do {
                            SlicePacket(totalPacket, out validPacket, out _leftPacket);
                            totalPacket = _leftPacket;
                            if(validPacket!="")
                            {
                                IPAddress fromIp, toIp;
                                int fromPort, toPort;
                                string content = "";
                                bool result = DecodePacket(validPacket, out fromIp, out fromPort, out toIp, out toPort, out content);

                                if (result == true)
                                {
                                    if (content.IndexOf("新人报到") == 0)
                                    {
                                        string nickName = content.Remove(0, 5);
                                        AddItemToListViewClient(nickName, fromIp, fromPort);
                                        ClientSendPtpPacket("回复新人|" + _localNickName, fromIp, fromPort);
                                    }
                                    else if (content.IndexOf("回复新人") == 0)
                                    {
                                        string nickName = content.Remove(0, 5);
                                        AddItemToListViewClient(nickName, fromIp, fromPort);
                                    }
                                    else if (content.IndexOf("我下线了") == 0)
                                    {
                                        RemoveItemFromListViewClient(fromIp, fromPort);
                                    }
                                    else if(content.IndexOf("发送消息")==0)
                                    {
                                        textBoxChat.Text += content.Remove(0, 5) + "\r\n";
                                    }
                                    else if (content.IndexOf("服务器关闭") == 0)
                                    {

                                        _localIP = IPAddress.Parse("0.0.0.0"); _localPort = 0; _localNickName = "";
                                        _serveerIP = IPAddress.Parse("0.0.0.0"); _serverPort = 0;

                                        listViewClient.Items.Clear();
                                        MessageBox.Show(this, "服务器关闭下次再聊吧", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        if (_socketClient != null) _socketClient.Close();
                                        if (threadReceivePacket != null)
                                            threadReceivePacket.Abort();
                                    }
                                    else return;

                                }
                                else
                                    return;
                            }
                        } while (validPacket != "");
                    }
                }
                catch (Exception excep)
                {
                    MessageBox.Show(this, excep.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        //客户端发送点对点数据包到某个客户端
        public void ClientSendPtpPacket(string content,IPAddress toIp,int toPort)
        {
            try
            {
                if(_socketClient!=null &&_socketClient.Connected==true)
                {
                    string sendPacket = "\a" + _localIP.ToString() + "|" + _localPort.ToString() + "|"
                        + toIp.ToString() + "|" + toPort.ToString() + "|" + content + "\t";
                    byte[] buffer = Encoding.UTF8.GetBytes(sendPacket);
                    _socketClient.Send(buffer);
                }
            }
            catch (Exception excep)
            {
                //MessageBox.Show(this, excep.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //客户端发送广播数据包到每个客户端
        public void ClientSendBroadcastPacket(string content)
        {
            try
            {
                if (_socketClient != null && _socketClient.Connected == true)
                {
                    string sendPacket = "\a"+_localIP.ToString() + "|" + _localPort.ToString() + "|"
                        + IPAddress.Parse("255.255.255.255").ToString() + "|" + "0" + "|" + content+"\t";
                    byte[] buffer = Encoding.UTF8.GetBytes(sendPacket);
                    _socketClient.Send(buffer);
                }
            }
            catch (Exception excep)
            {
                MessageBox.Show(this, excep.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void SlicePacket(string originalPacket,out string validPacket,out string leftPacket)
        {
            int headPos = -1,tailPos=-1;
            headPos = originalPacket.IndexOf('\a');
            if(headPos==-1)
            {
                validPacket = "";
                leftPacket = originalPacket;
                return;
            }
            tailPos = originalPacket.IndexOf('\t',headPos);
            if(tailPos==-1)
            {
                validPacket = "";
                leftPacket = originalPacket;
                return;
            }

            validPacket = originalPacket.Substring(headPos + 1, tailPos - headPos - 1);
            leftPacket = originalPacket.Remove(headPos) + originalPacket.Remove(0, tailPos + 1);
        }

        public bool DecodePacket(string packet, out IPAddress fromIp, out int fromPort, out IPAddress toIp, out int toPort, out string content)
        {
            int cnt = 0;
            int[] pos = new int[4];
            for (int i = 0; i < packet.Length; i++)
            {
                if (packet[i] == '|')
                {
                    pos[cnt] = i;
                    cnt++;
                    if (cnt >= 4) break;
                }
            }
            if (cnt == 4)
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
                fromIp = IPAddress.Parse("0.0.0.0");
                fromPort = 0;
                toIp = IPAddress.Parse("0.0.0.0");
                toPort = 0;
                content = "";
                return false;
            }

        }

        private void buttonLoginOut_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show(this,"需要退出大厅吗？","请确认",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                try
                {
                    ClientSendBroadcastPacket("我下线了|" + _localNickName);
                    _localIP = IPAddress.Parse("0.0.0.0");_localPort = 0;_localNickName = "";
                    _serveerIP= IPAddress.Parse("0.0.0.0"); _serverPort=0;

                    listViewClient.Items.Clear();

                    if (_socketClient != null) _socketClient.Close();
                    if (threadReceivePacket != null)
                        threadReceivePacket.Abort();
                }
                catch(Exception excep)
                {
                    MessageBox.Show(this, excep.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void RemoveItemFromListViewClient(IPAddress ip,int port)
        {
            for(int i=0;i<listViewClient.Items.Count;i++)
            {
                if(listViewClient.Items[i].SubItems[1].Text==ip.ToString()&& listViewClient.Items[i].SubItems[2].Text == port.ToString())
                {
                    listViewClient.Items.RemoveAt(i);
                    return ;
                }
            }
        }

        public void AddItemToListViewClient(string nick, IPAddress ip, int port)
        {
            for (int i = 0; i < listViewClient.Items.Count; i++)
            {
                if (listViewClient.Items[i].SubItems[1].Text == ip.ToString() && listViewClient.Items[i].SubItems[2].Text == port.ToString())
                {
                    listViewClient.Items[i].Text=nick;
                    return;
                }
            }

            ListViewItem item = new ListViewItem(nick);
            item.SubItems.Add(ip.ToString());
            item.SubItems.Add(port.ToString());
            listViewClient.Items.Add(item);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(this, "需要退出大厅吗？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
            else 
            {
                try
                {
                    ClientSendBroadcastPacket("我下线了|" + _localNickName);

                    if (_socketClient != null&&_socketClient.Connected==true) _socketClient.Close();
                    if (threadReceivePacket != null)
                        threadReceivePacket.Abort();
                }
                catch (Exception excep)
                {
                    MessageBox.Show(this, excep.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            string str = "发送消息|" +_localNickName +'：'+textBoxMessage.Text.ToString();
            ClientSendBroadcastPacket(str);
        }
    }
}
