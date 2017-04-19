namespace NewClient
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.buttonLoginOut = new System.Windows.Forms.Button();
            this.buttonLogIn = new System.Windows.Forms.Button();
            this.textBoxNickName = new System.Windows.Forms.TextBox();
            this.numericUpDownUpDownServerPort = new System.Windows.Forms.NumericUpDown();
            this.textBoxServerIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewClient = new System.Windows.Forms.ListView();
            this.nickName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.port = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.state = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBoxChat = new System.Windows.Forms.TextBox();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUpDownServerPort)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonSend);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxMessage);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxChat);
            this.splitContainer1.Size = new System.Drawing.Size(722, 515);
            this.splitContainer1.SplitterDistance = 228;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.buttonLoginOut);
            this.splitContainer2.Panel1.Controls.Add(this.buttonLogIn);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxNickName);
            this.splitContainer2.Panel1.Controls.Add(this.numericUpDownUpDownServerPort);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxServerIP);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.listViewClient);
            this.splitContainer2.Size = new System.Drawing.Size(228, 515);
            this.splitContainer2.SplitterDistance = 194;
            this.splitContainer2.TabIndex = 0;
            // 
            // buttonLoginOut
            // 
            this.buttonLoginOut.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonLoginOut.Location = new System.Drawing.Point(117, 141);
            this.buttonLoginOut.Name = "buttonLoginOut";
            this.buttonLoginOut.Size = new System.Drawing.Size(75, 31);
            this.buttonLoginOut.TabIndex = 7;
            this.buttonLoginOut.Text = "退出";
            this.buttonLoginOut.UseVisualStyleBackColor = true;
            this.buttonLoginOut.Click += new System.EventHandler(this.buttonLoginOut_Click);
            // 
            // buttonLogIn
            // 
            this.buttonLogIn.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonLogIn.Location = new System.Drawing.Point(27, 141);
            this.buttonLogIn.Name = "buttonLogIn";
            this.buttonLogIn.Size = new System.Drawing.Size(75, 31);
            this.buttonLogIn.TabIndex = 6;
            this.buttonLogIn.Text = "登录";
            this.buttonLogIn.UseVisualStyleBackColor = true;
            this.buttonLogIn.Click += new System.EventHandler(this.buttonLogIn_Click);
            // 
            // textBoxNickName
            // 
            this.textBoxNickName.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxNickName.Location = new System.Drawing.Point(84, 92);
            this.textBoxNickName.Name = "textBoxNickName";
            this.textBoxNickName.Size = new System.Drawing.Size(120, 29);
            this.textBoxNickName.TabIndex = 5;
            // 
            // numericUpDownUpDownServerPort
            // 
            this.numericUpDownUpDownServerPort.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numericUpDownUpDownServerPort.Location = new System.Drawing.Point(84, 59);
            this.numericUpDownUpDownServerPort.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownUpDownServerPort.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDownUpDownServerPort.Name = "numericUpDownUpDownServerPort";
            this.numericUpDownUpDownServerPort.Size = new System.Drawing.Size(120, 29);
            this.numericUpDownUpDownServerPort.TabIndex = 4;
            this.numericUpDownUpDownServerPort.Value = new decimal(new int[] {
            9000,
            0,
            0,
            0});
            // 
            // textBoxServerIP
            // 
            this.textBoxServerIP.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxServerIP.Location = new System.Drawing.Point(84, 19);
            this.textBoxServerIP.Name = "textBoxServerIP";
            this.textBoxServerIP.Size = new System.Drawing.Size(120, 29);
            this.textBoxServerIP.TabIndex = 3;
            this.textBoxServerIP.Text = "192.168.0.3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(12, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "昵称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "端口：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "地址：";
            // 
            // listViewClient
            // 
            this.listViewClient.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listViewClient.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nickName,
            this.IP,
            this.port,
            this.state});
            this.listViewClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewClient.FullRowSelect = true;
            this.listViewClient.Location = new System.Drawing.Point(0, 0);
            this.listViewClient.Name = "listViewClient";
            this.listViewClient.Size = new System.Drawing.Size(228, 317);
            this.listViewClient.TabIndex = 0;
            this.listViewClient.UseCompatibleStateImageBehavior = false;
            this.listViewClient.View = System.Windows.Forms.View.Details;
            // 
            // nickName
            // 
            this.nickName.Text = "昵称";
            // 
            // IP
            // 
            this.IP.Text = "IP";
            this.IP.Width = 74;
            // 
            // port
            // 
            this.port.Text = "端口";
            this.port.Width = 42;
            // 
            // state
            // 
            this.state.Text = "状态";
            // 
            // textBoxChat
            // 
            this.textBoxChat.Location = new System.Drawing.Point(2, 3);
            this.textBoxChat.Multiline = true;
            this.textBoxChat.Name = "textBoxChat";
            this.textBoxChat.ReadOnly = true;
            this.textBoxChat.Size = new System.Drawing.Size(485, 366);
            this.textBoxChat.TabIndex = 0;
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Location = new System.Drawing.Point(3, 375);
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(391, 137);
            this.textBoxMessage.TabIndex = 1;
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(400, 480);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 2;
            this.buttonSend.Text = "发送";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 515);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUpDownServerPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView listViewClient;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader nickName;
        private System.Windows.Forms.ColumnHeader IP;
        private System.Windows.Forms.ColumnHeader port;
        private System.Windows.Forms.ColumnHeader state;
        private System.Windows.Forms.TextBox textBoxNickName;
        private System.Windows.Forms.NumericUpDown numericUpDownUpDownServerPort;
        private System.Windows.Forms.TextBox textBoxServerIP;
        private System.Windows.Forms.Button buttonLoginOut;
        private System.Windows.Forms.Button buttonLogIn;
        private System.Windows.Forms.TextBox textBoxChat;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxMessage;
    }
}

