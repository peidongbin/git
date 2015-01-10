namespace Monitorsever
{
    partial class userset_frm
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
            this.userview = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.but_add = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.userview)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // userview
            // 
            this.userview.AllowUserToAddRows = false;
            this.userview.AllowUserToDeleteRows = false;
            this.userview.AllowUserToResizeColumns = false;
            this.userview.AllowUserToResizeRows = false;
            this.userview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userview.Location = new System.Drawing.Point(0, 0);
            this.userview.Name = "userview";
            this.userview.ReadOnly = true;
            this.userview.RowHeadersVisible = false;
            this.userview.RowTemplate.Height = 23;
            this.userview.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.userview.Size = new System.Drawing.Size(200, 177);
            this.userview.TabIndex = 0;
            this.userview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.userview);
            this.panel1.Location = new System.Drawing.Point(21, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 177);
            this.panel1.TabIndex = 1;
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
            this.comboBox1.Location = new System.Drawing.Point(255, 59);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(255, 109);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 21);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // but_add
            // 
            this.but_add.Location = new System.Drawing.Point(255, 154);
            this.but_add.Name = "but_add";
            this.but_add.Size = new System.Drawing.Size(121, 23);
            this.but_add.TabIndex = 4;
            this.but_add.Text = "更改";
            this.but_add.UseVisualStyleBackColor = true;
            this.but_add.Click += new System.EventHandler(this.but_add_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(255, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "分院编号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "密码";
            // 
            // userset_frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 226);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.but_add);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.panel1);
            this.Name = "userset_frm";
            this.Text = "用户管理";
            this.Load += new System.EventHandler(this.userset_frm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userview)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView userview;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button but_add;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}