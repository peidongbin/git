namespace TestForUpdateConnectionClient
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtServerIp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSendMessage = new System.Windows.Forms.RichTextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtLocalAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtReceivedMsg = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.txtServerPort);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtServerIp);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(543, 74);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "服务器信息";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(431, 21);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(104, 44);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtServerPort
            // 
            this.txtServerPort.Location = new System.Drawing.Point(356, 34);
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(59, 29);
            this.txtServerPort.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "端口号：";
            // 
            // txtServerIp
            // 
            this.txtServerIp.Location = new System.Drawing.Point(135, 34);
            this.txtServerIp.Name = "txtServerIp";
            this.txtServerIp.Size = new System.Drawing.Size(138, 29);
            this.txtServerIp.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器地址：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSendMessage);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.btnSendMessage);
            this.groupBox2.Location = new System.Drawing.Point(12, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(467, 356);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "消息发送";
            // 
            // txtSendMessage
            // 
            this.txtSendMessage.Location = new System.Drawing.Point(12, 29);
            this.txtSendMessage.Name = "txtSendMessage";
            this.txtSendMessage.Size = new System.Drawing.Size(315, 321);
            this.txtSendMessage.TabIndex = 1;
            this.txtSendMessage.Text = "";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(333, 152);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(125, 77);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "清除消息";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Enabled = false;
            this.btnSendMessage.Location = new System.Drawing.Point(333, 69);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(125, 77);
            this.btnSendMessage.TabIndex = 0;
            this.btnSendMessage.Text = "发送";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtLocalAddress);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(563, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(304, 74);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "本地信息";
            // 
            // txtLocalAddress
            // 
            this.txtLocalAddress.Location = new System.Drawing.Point(105, 34);
            this.txtLocalAddress.Name = "txtLocalAddress";
            this.txtLocalAddress.ReadOnly = true;
            this.txtLocalAddress.Size = new System.Drawing.Size(190, 29);
            this.txtLocalAddress.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "本地信息：";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtReceivedMsg);
            this.groupBox4.Location = new System.Drawing.Point(485, 93);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(382, 356);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "消息接收";
            // 
            // txtReceivedMsg
            // 
            this.txtReceivedMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReceivedMsg.Location = new System.Drawing.Point(3, 25);
            this.txtReceivedMsg.Name = "txtReceivedMsg";
            this.txtReceivedMsg.ReadOnly = true;
            this.txtReceivedMsg.Size = new System.Drawing.Size(376, 328);
            this.txtReceivedMsg.TabIndex = 1;
            this.txtReceivedMsg.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 461);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtServerPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtServerIp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox txtSendMessage;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtLocalAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox txtReceivedMsg;
        private System.Windows.Forms.Button btnClear;
    }
}

