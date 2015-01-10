namespace Monitorsever
{
    partial class serverset_frm
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
            this.but_select = new System.Windows.Forms.Button();
            this.text_path = new System.Windows.Forms.TextBox();
            this.but_save = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // but_select
            // 
            this.but_select.Location = new System.Drawing.Point(281, 21);
            this.but_select.Name = "but_select";
            this.but_select.Size = new System.Drawing.Size(75, 23);
            this.but_select.TabIndex = 0;
            this.but_select.Text = "选择文件夹";
            this.but_select.UseVisualStyleBackColor = true;
            this.but_select.Click += new System.EventHandler(this.button1_Click);
            // 
            // text_path
            // 
            this.text_path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_path.Location = new System.Drawing.Point(26, 21);
            this.text_path.Name = "text_path";
            this.text_path.ReadOnly = true;
            this.text_path.Size = new System.Drawing.Size(217, 21);
            this.text_path.TabIndex = 1;
            this.text_path.TextChanged += new System.EventHandler(this.text_path_TextChanged);
            // 
            // but_save
            // 
            this.but_save.Location = new System.Drawing.Point(281, 74);
            this.but_save.Name = "but_save";
            this.but_save.Size = new System.Drawing.Size(75, 23);
            this.but_save.TabIndex = 2;
            this.but_save.Text = "保存并退出";
            this.but_save.UseVisualStyleBackColor = true;
            this.but_save.Click += new System.EventHandler(this.but_save_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(26, 76);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(217, 21);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // serverset_frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 128);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.but_save);
            this.Controls.Add(this.text_path);
            this.Controls.Add(this.but_select);
            this.Name = "serverset_frm";
            this.Text = "设置";
            this.Load += new System.EventHandler(this.serverset_frm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_select;
        private System.Windows.Forms.TextBox text_path;
        private System.Windows.Forms.Button but_save;
        private System.Windows.Forms.TextBox textBox1;
    }
}