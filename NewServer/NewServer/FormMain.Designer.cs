namespace NewServer
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelClientCount = new System.Windows.Forms.Label();
            this.comboBoxServerIP = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.listViewClient = new System.Windows.Forms.ListView();
            this.昵称 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.端口 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.状态 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewPaket = new System.Windows.Forms.ListView();
            this.Packet = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonStartListen = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(26, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器IP地址：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(26, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "监听的端口号：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(26, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "在线客户端列表：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(26, 341);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "数据包列表：";
            // 
            // labelClientCount
            // 
            this.labelClientCount.AutoSize = true;
            this.labelClientCount.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelClientCount.Location = new System.Drawing.Point(506, 121);
            this.labelClientCount.Name = "labelClientCount";
            this.labelClientCount.Size = new System.Drawing.Size(153, 22);
            this.labelClientCount.TabIndex = 4;
            this.labelClientCount.Text = "客户端数量：0";
            // 
            // comboBoxServerIP
            // 
            this.comboBoxServerIP.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxServerIP.FormattingEnabled = true;
            this.comboBoxServerIP.Location = new System.Drawing.Point(185, 13);
            this.comboBoxServerIP.Name = "comboBoxServerIP";
            this.comboBoxServerIP.Size = new System.Drawing.Size(316, 27);
            this.comboBoxServerIP.TabIndex = 5;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numericUpDown1.Location = new System.Drawing.Point(185, 60);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(89, 29);
            this.numericUpDown1.TabIndex = 6;
            this.numericUpDown1.Value = new decimal(new int[] {
            9000,
            0,
            0,
            0});
            // 
            // listViewClient
            // 
            this.listViewClient.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.昵称,
            this.IP,
            this.端口,
            this.状态});
            this.listViewClient.Location = new System.Drawing.Point(30, 158);
            this.listViewClient.Name = "listViewClient";
            this.listViewClient.Size = new System.Drawing.Size(666, 162);
            this.listViewClient.TabIndex = 7;
            this.listViewClient.UseCompatibleStateImageBehavior = false;
            this.listViewClient.View = System.Windows.Forms.View.Details;
            // 
            // 昵称
            // 
            this.昵称.Text = "昵称";
            this.昵称.Width = 67;
            // 
            // IP
            // 
            this.IP.Text = "IP";
            this.IP.Width = 83;
            // 
            // 端口
            // 
            this.端口.Text = "端口";
            this.端口.Width = 104;
            // 
            // 状态
            // 
            this.状态.Text = "状态";
            this.状态.Width = 134;
            // 
            // listViewPaket
            // 
            this.listViewPaket.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Packet});
            this.listViewPaket.Location = new System.Drawing.Point(30, 380);
            this.listViewPaket.Name = "listViewPaket";
            this.listViewPaket.Size = new System.Drawing.Size(666, 169);
            this.listViewPaket.TabIndex = 8;
            this.listViewPaket.UseCompatibleStateImageBehavior = false;
            this.listViewPaket.View = System.Windows.Forms.View.Details;
            // 
            // Packet
            // 
            this.Packet.Text = "数据包";
            this.Packet.Width = 569;
            // 
            // buttonStartListen
            // 
            this.buttonStartListen.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonStartListen.Location = new System.Drawing.Point(401, 45);
            this.buttonStartListen.Name = "buttonStartListen";
            this.buttonStartListen.Size = new System.Drawing.Size(100, 44);
            this.buttonStartListen.TabIndex = 9;
            this.buttonStartListen.Text = "开始监听";
            this.buttonStartListen.UseVisualStyleBackColor = true;
            this.buttonStartListen.Click += new System.EventHandler(this.buttonStartListen_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonExit.Location = new System.Drawing.Point(596, 45);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(100, 44);
            this.buttonExit.TabIndex = 10;
            this.buttonExit.Text = "退出程序";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 561);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonStartListen);
            this.Controls.Add(this.listViewPaket);
            this.Controls.Add(this.listViewClient);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.comboBoxServerIP);
            this.Controls.Add(this.labelClientCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "聊天室-服务器端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelClientCount;
        private System.Windows.Forms.ComboBox comboBoxServerIP;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ListView listViewClient;
        private System.Windows.Forms.ListView listViewPaket;
        private System.Windows.Forms.Button buttonStartListen;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.ColumnHeader 昵称;
        private System.Windows.Forms.ColumnHeader IP;
        private System.Windows.Forms.ColumnHeader 端口;
        private System.Windows.Forms.ColumnHeader 状态;
        private System.Windows.Forms.ColumnHeader Packet;
    }
}

