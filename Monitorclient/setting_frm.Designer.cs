namespace Monitorclient
{
    partial class setting_frm
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
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.but_save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_ip
            // 
            this.txt_ip.Location = new System.Drawing.Point(117, 31);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(192, 21);
            this.txt_ip.TabIndex = 0;
            // 
            // txt_port
            // 
            this.txt_port.Location = new System.Drawing.Point(117, 81);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(100, 21);
            this.txt_port.TabIndex = 1;
            // 
            // but_save
            // 
            this.but_save.Location = new System.Drawing.Point(234, 81);
            this.but_save.Name = "but_save";
            this.but_save.Size = new System.Drawing.Size(75, 23);
            this.but_save.TabIndex = 2;
            this.but_save.Text = "保存";
            this.but_save.UseVisualStyleBackColor = true;
            this.but_save.Click += new System.EventHandler(this.but_save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP地址";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "端口";
            // 
            // setting_frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 145);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.but_save);
            this.Controls.Add(this.txt_port);
            this.Controls.Add(this.txt_ip);
            this.Name = "setting_frm";
            this.Text = "设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.Button but_save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}