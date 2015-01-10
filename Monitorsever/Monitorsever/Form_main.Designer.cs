namespace Monitorsever
{
    partial class Form_main
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtServerInfo = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.选项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出程序ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.录入人员管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设备信息录入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统日志ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.视频ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开存储文件夹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询视频ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelmain = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.listClient = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.threadtrick = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.panelmain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtServerInfo
            // 
            this.txtServerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtServerInfo.Location = new System.Drawing.Point(3, 17);
            this.txtServerInfo.Name = "txtServerInfo";
            this.txtServerInfo.ReadOnly = true;
            this.txtServerInfo.Size = new System.Drawing.Size(239, 80);
            this.txtServerInfo.TabIndex = 1;
            this.txtServerInfo.Text = "";
            this.txtServerInfo.TextChanged += new System.EventHandler(this.txtServerInfo_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选项ToolStripMenuItem,
            this.管理ToolStripMenuItem,
            this.视频ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(957, 25);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // 选项ToolStripMenuItem
            // 
            this.选项ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem,
            this.退出程序ToolStripMenuItem});
            this.选项ToolStripMenuItem.Name = "选项ToolStripMenuItem";
            this.选项ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.选项ToolStripMenuItem.Text = "选项";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.设置ToolStripMenuItem.Text = "设置";
            this.设置ToolStripMenuItem.Click += new System.EventHandler(this.设置ToolStripMenuItem_Click);
            // 
            // 退出程序ToolStripMenuItem
            // 
            this.退出程序ToolStripMenuItem.Name = "退出程序ToolStripMenuItem";
            this.退出程序ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.退出程序ToolStripMenuItem.Text = "退出程序";
            this.退出程序ToolStripMenuItem.Click += new System.EventHandler(this.退出程序ToolStripMenuItem_Click);
            // 
            // 管理ToolStripMenuItem
            // 
            this.管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.录入人员管理ToolStripMenuItem,
            this.设备信息录入ToolStripMenuItem,
            this.系统日志ToolStripMenuItem});
            this.管理ToolStripMenuItem.Name = "管理ToolStripMenuItem";
            this.管理ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.管理ToolStripMenuItem.Text = "管理";
            // 
            // 录入人员管理ToolStripMenuItem
            // 
            this.录入人员管理ToolStripMenuItem.Name = "录入人员管理ToolStripMenuItem";
            this.录入人员管理ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.录入人员管理ToolStripMenuItem.Text = "客户端管理";
            this.录入人员管理ToolStripMenuItem.Click += new System.EventHandler(this.录入人员管理ToolStripMenuItem_Click);
            // 
            // 设备信息录入ToolStripMenuItem
            // 
            this.设备信息录入ToolStripMenuItem.Name = "设备信息录入ToolStripMenuItem";
            this.设备信息录入ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.设备信息录入ToolStripMenuItem.Text = "设备管理";
            this.设备信息录入ToolStripMenuItem.Click += new System.EventHandler(this.设备信息录入ToolStripMenuItem_Click);
            // 
            // 系统日志ToolStripMenuItem
            // 
            this.系统日志ToolStripMenuItem.Name = "系统日志ToolStripMenuItem";
            this.系统日志ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.系统日志ToolStripMenuItem.Text = "系统日志";
            this.系统日志ToolStripMenuItem.Click += new System.EventHandler(this.系统日志ToolStripMenuItem_Click);
            // 
            // 视频ToolStripMenuItem
            // 
            this.视频ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开存储文件夹ToolStripMenuItem,
            this.查询视频ToolStripMenuItem,
            this.testToolStripMenuItem});
            this.视频ToolStripMenuItem.Name = "视频ToolStripMenuItem";
            this.视频ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.视频ToolStripMenuItem.Text = "视频";
            // 
            // 打开存储文件夹ToolStripMenuItem
            // 
            this.打开存储文件夹ToolStripMenuItem.Name = "打开存储文件夹ToolStripMenuItem";
            this.打开存储文件夹ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.打开存储文件夹ToolStripMenuItem.Text = "打开存储文件夹";
            this.打开存储文件夹ToolStripMenuItem.Click += new System.EventHandler(this.打开存储文件夹ToolStripMenuItem_Click);
            // 
            // 查询视频ToolStripMenuItem
            // 
            this.查询视频ToolStripMenuItem.Name = "查询视频ToolStripMenuItem";
            this.查询视频ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.查询视频ToolStripMenuItem.Text = "查询视频";
            this.查询视频ToolStripMenuItem.Click += new System.EventHandler(this.查询视频ToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.testToolStripMenuItem.Text = "实时观看";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // panelmain
            // 
            this.panelmain.Controls.Add(this.dataGridView1);
            this.panelmain.Location = new System.Drawing.Point(22, 39);
            this.panelmain.Name = "panelmain";
            this.panelmain.Size = new System.Drawing.Size(631, 473);
            this.panelmain.TabIndex = 21;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(631, 473);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Controls.Add(this.listClient);
            this.groupBox1.Location = new System.Drawing.Point(687, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 140);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "客户端列表";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("宋体", 12F);
            this.richTextBox1.Location = new System.Drawing.Point(3, 17);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(242, 120);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged_1);
            // 
            // listClient
            // 
            this.listClient.FormattingEnabled = true;
            this.listClient.ItemHeight = 12;
            this.listClient.Location = new System.Drawing.Point(6, 17);
            this.listClient.Name = "listClient";
            this.listClient.Size = new System.Drawing.Size(34, 28);
            this.listClient.TabIndex = 16;
            this.listClient.Visible = false;
            this.listClient.SelectedIndexChanged += new System.EventHandler(this.listClient_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtServerInfo);
            this.groupBox2.Location = new System.Drawing.Point(690, 200);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 100);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "系统消息";
            // 
            // threadtrick
            // 
            this.threadtrick.Dock = System.Windows.Forms.DockStyle.Fill;
            this.threadtrick.Font = new System.Drawing.Font("宋体", 8F);
            this.threadtrick.Location = new System.Drawing.Point(3, 17);
            this.threadtrick.Name = "threadtrick";
            this.threadtrick.ReadOnly = true;
            this.threadtrick.Size = new System.Drawing.Size(243, 156);
            this.threadtrick.TabIndex = 2;
            this.threadtrick.Text = "";
            this.threadtrick.TextChanged += new System.EventHandler(this.threadtrick_TextChanged_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.threadtrick);
            this.groupBox3.Location = new System.Drawing.Point(693, 323);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(249, 176);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "正在进行的录制";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 5000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 524);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelmain);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form_main";
            this.Text = "主界面";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelmain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RichTextBox txtServerInfo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 选项ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出程序ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 录入人员管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设备信息录入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统日志ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 视频ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开存储文件夹ToolStripMenuItem;
        private System.Windows.Forms.Panel panelmain;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem 查询视频ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox threadtrick;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox listClient;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
    }
}

