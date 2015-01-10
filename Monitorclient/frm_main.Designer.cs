namespace Monitorclient
{
    partial class frm_main
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.but_setting = new System.Windows.Forms.Button();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtServerIp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rec_txt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSendMessage2 = new System.Windows.Forms.TextBox();
            this.btnstop = new System.Windows.Forms.Button();
            this.btnstart = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtLocalAddress = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtSendMessage1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.threadtrick = new System.Windows.Forms.RichTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.but_setting);
            this.groupBox1.Controls.Add(this.txtServerPort);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtServerIp);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 377);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(537, 63);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "服务器信息";
            // 
            // but_setting
            // 
            this.but_setting.Location = new System.Drawing.Point(430, 19);
            this.but_setting.Name = "but_setting";
            this.but_setting.Size = new System.Drawing.Size(101, 39);
            this.but_setting.TabIndex = 6;
            this.but_setting.Text = "设置";
            this.but_setting.UseVisualStyleBackColor = true;
            this.but_setting.Click += new System.EventHandler(this.but_setting_Click);
            // 
            // txtServerPort
            // 
            this.txtServerPort.Location = new System.Drawing.Point(351, 26);
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.ReadOnly = true;
            this.txtServerPort.Size = new System.Drawing.Size(59, 29);
            this.txtServerPort.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(264, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "端口号：";
            // 
            // txtServerIp
            // 
            this.txtServerIp.Location = new System.Drawing.Point(89, 25);
            this.txtServerIp.Name = "txtServerIp";
            this.txtServerIp.ReadOnly = true;
            this.txtServerIp.Size = new System.Drawing.Size(150, 29);
            this.txtServerIp.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP地址：";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(318, 36);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(104, 44);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "登录";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.rec_txt);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtSendMessage2);
            this.groupBox2.Controls.Add(this.btnstop);
            this.groupBox2.Controls.Add(this.btnstart);
            this.groupBox2.Location = new System.Drawing.Point(12, 141);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(467, 219);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "视频录制";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 19);
            this.label7.TabIndex = 8;
            this.label7.Text = "录制状态";
            // 
            // rec_txt
            // 
            this.rec_txt.Location = new System.Drawing.Point(106, 130);
            this.rec_txt.Name = "rec_txt";
            this.rec_txt.ReadOnly = true;
            this.rec_txt.Size = new System.Drawing.Size(183, 29);
            this.rec_txt.TabIndex = 7;
            this.rec_txt.TextChanged += new System.EventHandler(this.rec_txt_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 19);
            this.label6.TabIndex = 6;
            this.label6.Text = "病人编号";
            // 
            // txtSendMessage2
            // 
            this.txtSendMessage2.Location = new System.Drawing.Point(106, 58);
            this.txtSendMessage2.Name = "txtSendMessage2";
            this.txtSendMessage2.Size = new System.Drawing.Size(183, 29);
            this.txtSendMessage2.TabIndex = 3;
            this.txtSendMessage2.TextChanged += new System.EventHandler(this.txtSendMessage2_TextChanged);
            // 
            // btnstop
            // 
            this.btnstop.Location = new System.Drawing.Point(319, 127);
            this.btnstop.Name = "btnstop";
            this.btnstop.Size = new System.Drawing.Size(96, 32);
            this.btnstop.TabIndex = 0;
            this.btnstop.Text = "结束";
            this.btnstop.UseVisualStyleBackColor = true;
            this.btnstop.Click += new System.EventHandler(this.btnstop_Click);
            // 
            // btnstart
            // 
            this.btnstart.Enabled = false;
            this.btnstart.Location = new System.Drawing.Point(319, 58);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(96, 32);
            this.btnstart.TabIndex = 0;
            this.btnstart.Text = "开始";
            this.btnstart.UseVisualStyleBackColor = true;
            this.btnstart.Click += new System.EventHandler(this.btnstart_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(150, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "密码";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtLocalAddress);
            this.groupBox3.Location = new System.Drawing.Point(579, 377);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(318, 63);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "本地信息";
            // 
            // txtLocalAddress
            // 
            this.txtLocalAddress.Location = new System.Drawing.Point(18, 24);
            this.txtLocalAddress.Name = "txtLocalAddress";
            this.txtLocalAddress.ReadOnly = true;
            this.txtLocalAddress.Size = new System.Drawing.Size(278, 29);
            this.txtLocalAddress.TabIndex = 1;
            this.txtLocalAddress.TextChanged += new System.EventHandler(this.txtLocalAddress_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 100000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtSendMessage1
            // 
            this.txtSendMessage1.Location = new System.Drawing.Point(159, 51);
            this.txtSendMessage1.Name = "txtSendMessage1";
            this.txtSendMessage1.Size = new System.Drawing.Size(126, 29);
            this.txtSendMessage1.TabIndex = 2;
            this.txtSendMessage1.UseSystemPasswordChar = true;
            this.txtSendMessage1.TextChanged += new System.EventHandler(this.txtSendMessage1_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "001",
            "002",
            "003",
            "004",
            "005"});
            this.comboBox1.Location = new System.Drawing.Point(14, 51);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 27);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.btnConnect);
            this.groupBox4.Controls.Add(this.comboBox1);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.txtSendMessage1);
            this.groupBox4.Location = new System.Drawing.Point(13, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(466, 113);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "登录窗";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "用户名";
            // 
            // threadtrick
            // 
            this.threadtrick.Dock = System.Windows.Forms.DockStyle.Fill;
            this.threadtrick.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.threadtrick.Location = new System.Drawing.Point(3, 25);
            this.threadtrick.Name = "threadtrick";
            this.threadtrick.ReadOnly = true;
            this.threadtrick.Size = new System.Drawing.Size(409, 320);
            this.threadtrick.TabIndex = 3;
            this.threadtrick.Text = "";
            this.threadtrick.TextChanged += new System.EventHandler(this.threadtrick_TextChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.threadtrick);
            this.groupBox5.Location = new System.Drawing.Point(486, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(415, 348);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "服务器状态";
            // 
            // frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 452);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.Name = "frm_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "控制端";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtServerPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtServerIp;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnstart;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtLocalAddress;
        private System.Windows.Forms.Button btnstop;
        private System.Windows.Forms.TextBox txtSendMessage2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox rec_txt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtSendMessage1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox threadtrick;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button but_setting;
        private System.Windows.Forms.Label label1;
    }
}

