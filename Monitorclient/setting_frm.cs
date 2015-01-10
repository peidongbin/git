using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Monitorclient.CommonClass;

namespace Monitorclient
{
    public partial class setting_frm : Form
    {
        DataCon datacon = new DataCon();
        DataOperate dataoperate = new DataOperate();
        public setting_frm()
        {
            InitializeComponent();
        }

        private void but_save_Click(object sender, EventArgs e)
        {
            if ((txt_ip.Text == "") | (txt_port.Text == "")) { MessageBox.Show("请输入正确的信息"); }
            else
            { 
            string save_setting = "update setting set  serverip='" + txt_ip.Text + "'  where id=1";

            DataSet Save = dataoperate.getDs(save_setting, "setting");
            string save_setting1 = "update setting set  serverport='" + txt_port.Text + "'  where id=1";

            DataSet Save1 = dataoperate.getDs(save_setting1, "setting");
            }   

        }
    }
}
