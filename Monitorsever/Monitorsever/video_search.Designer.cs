namespace Monitorsever
{
    partial class video_search
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.video = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.butdel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.end_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.begin_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.userid = new System.Windows.Forms.ComboBox();
            this.rst = new System.Windows.Forms.Button();
            this.videoname = new System.Windows.Forms.TextBox();
            this.search = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.video)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.video);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 428);
            this.panel1.TabIndex = 2;
            // 
            // video
            // 
            this.video.AllowUserToAddRows = false;
            this.video.AllowUserToDeleteRows = false;
            this.video.AllowUserToResizeColumns = false;
            this.video.AllowUserToResizeRows = false;
            this.video.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.video.Dock = System.Windows.Forms.DockStyle.Fill;
            this.video.Location = new System.Drawing.Point(0, 0);
            this.video.Name = "video";
            this.video.ReadOnly = true;
            this.video.RowHeadersVisible = false;
            this.video.RowTemplate.Height = 23;
            this.video.Size = new System.Drawing.Size(800, 428);
            this.video.TabIndex = 0;
            this.video.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.video_CellContentClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.butdel);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.userid);
            this.panel3.Controls.Add(this.rst);
            this.panel3.Controls.Add(this.videoname);
            this.panel3.Controls.Add(this.search);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(818, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(198, 428);
            this.panel3.TabIndex = 14;
            // 
            // butdel
            // 
            this.butdel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.butdel.Location = new System.Drawing.Point(22, 390);
            this.butdel.Name = "butdel";
            this.butdel.Size = new System.Drawing.Size(163, 23);
            this.butdel.TabIndex = 14;
            this.butdel.Text = "全选并且删除";
            this.butdel.UseVisualStyleBackColor = false;
            this.butdel.Click += new System.EventHandler(this.butdel_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.end_dateTimePicker);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.begin_dateTimePicker);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(13, 164);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 100);
            this.panel2.TabIndex = 1;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(10, 78);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "确认时间";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // end_dateTimePicker
            // 
            this.end_dateTimePicker.Location = new System.Drawing.Point(66, 49);
            this.end_dateTimePicker.Name = "end_dateTimePicker";
            this.end_dateTimePicker.Size = new System.Drawing.Size(128, 21);
            this.end_dateTimePicker.TabIndex = 12;
            this.end_dateTimePicker.Value = new System.DateTime(2000, 5, 1, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "起始时间";
            // 
            // begin_dateTimePicker
            // 
            this.begin_dateTimePicker.Location = new System.Drawing.Point(62, 8);
            this.begin_dateTimePicker.Name = "begin_dateTimePicker";
            this.begin_dateTimePicker.Size = new System.Drawing.Size(128, 21);
            this.begin_dateTimePicker.TabIndex = 11;
            this.begin_dateTimePicker.Value = new System.DateTime(2000, 5, 1, 0, 0, 0, 0);
            this.begin_dateTimePicker.ValueChanged += new System.EventHandler(this.begin_dateTimePicker_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "截止时间";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "请选择分院";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Info;
            this.textBox1.Location = new System.Drawing.Point(13, 336);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(178, 21);
            this.textBox1.TabIndex = 13;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // userid
            // 
            this.userid.DropDownHeight = 120;
            this.userid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userid.DropDownWidth = 80;
            this.userid.FormattingEnabled = true;
            this.userid.IntegralHeight = false;
            this.userid.Items.AddRange(new object[] {
            "001",
            "002",
            "003",
            "004",
            "005"});
            this.userid.Location = new System.Drawing.Point(91, 33);
            this.userid.Name = "userid";
            this.userid.Size = new System.Drawing.Size(80, 20);
            this.userid.TabIndex = 0;
            this.userid.SelectedIndexChanged += new System.EventHandler(this.userid_SelectedIndexChanged);
            // 
            // rst
            // 
            this.rst.Location = new System.Drawing.Point(110, 281);
            this.rst.Name = "rst";
            this.rst.Size = new System.Drawing.Size(75, 23);
            this.rst.TabIndex = 10;
            this.rst.Text = "重置";
            this.rst.UseVisualStyleBackColor = true;
            this.rst.Click += new System.EventHandler(this.rst_Click);
            // 
            // videoname
            // 
            this.videoname.Location = new System.Drawing.Point(74, 97);
            this.videoname.Name = "videoname";
            this.videoname.Size = new System.Drawing.Size(100, 21);
            this.videoname.TabIndex = 3;
            this.videoname.TextChanged += new System.EventHandler(this.videoname_TextChanged);
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(17, 281);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(75, 23);
            this.search.TabIndex = 9;
            this.search.Text = "查询";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "病人编号";
            // 
            // video_search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 452);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "video_search";
            this.Text = "视频查询";
            this.Load += new System.EventHandler(this.video_search_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.video)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView video;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DateTimePicker end_dateTimePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker begin_dateTimePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox userid;
        private System.Windows.Forms.Button rst;
        private System.Windows.Forms.TextBox videoname;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butdel;
    }
}