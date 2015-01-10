using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Monitorsever.CommonClass;

namespace Monitorsever
{
    public partial class userset_frm : Form
    {
        DataCon datacon = new DataCon();
        DataOperate dataoperate = new DataOperate();
        public userset_frm()
        {
            InitializeComponent();
        }

        private void userset_frm_Load(object sender, EventArgs e)
        {
            usersearch();
            comboBox1.Text = "001";
  
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void usersearch()
        {
            string getlist = "SELECT  loginname,pwd FROM login_db ";
            DataSet videolist = dataoperate.getDs(getlist, "login_db");

            userview.DataSource = videolist.Tables[0];
            userview.Columns[0].HeaderText = "分院编号";
            userview.Columns[0].Width = 100;
            userview.Columns[1].HeaderText = "密码";
            userview.Columns[1].Width = 100;

            
            
        }

        private void but_add_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "")) { MessageBox.Show("请输入密码！"); }
            else
            {
                //try
                //{
                    string sqlstr = " update login_db set pwd='" + textBox1.Text + "' where loginname='" + comboBox1.Text + "'";
                    DataSet ds = dataoperate.getDs(sqlstr, "login_db");
                //}
                //catch(Exception){}

             }
            usersearch();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
