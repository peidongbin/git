using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Monitorsever.CommonClass;
using System.Data.OleDb;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Monitorsever
{
    public partial class Form_camsetting : Form
    {
        DataCon datacon = new DataCon();
        DataOperate dataoperate = new DataOperate();
        delegate void SetTextCallback(string text);
        delegate void SetbtnCallback(bool n);
        Thread thread = null;
       
        public Form_camsetting()
        {

            InitializeComponent();
        }


        private void camview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (camview.RowCount > 0)
            {
                if (camview.Columns[e.ColumnIndex].Name == "del")
                {


                    string id = camview.Rows[e.RowIndex].Cells[5].Value.ToString();
                    string delstring = "delete from cam where ID=" + id + "";
                    try
                    {
                        DataSet camlist = dataoperate.getDs(delstring, "cam");

                    }
                    catch { }
                    camseach();

                }
            }




        }

        private void Form_camsetting_Load(object sender, EventArgs e)
        {
        
            textBox3.Text = "admin";
            textBox4.Text = "123456";
            camseach();
            camview.AutoGenerateColumns = false;
          
            DataGridViewButtonColumn del = new DataGridViewButtonColumn();
            del.Text = "删除";//添加的这列的显示文字，即每行最后一列显示的文字。
            del.Name = "del";
            del.HeaderText = "删除";//列的标题
            del.UseColumnTextForButtonValue = true;//上面设置的dlink.Text文字在列中显示
            del.Width = 40;
            camview.Columns.Add(del);//将创建的列添加到UserdataGridView中}
           
            //btnsave.Enabled = false;
        }









        private void btnsave_Click(object sender, EventArgs e)
        {
          
            
            for (int i = 1; i <= 10; i++)
            {
                string getlist = "SELECT  num FROM cam where num=" + i.ToString();
                DataSet ds0 = dataoperate.getDs(getlist, "video");
                if (ds0.Tables[0].Rows.Count <= 0)
                {
                    string sqlString = "insert into cam(uid,uidpassword,userid,camid,num) values ('" + textBox3.Text + "','" + textBox4.Text + "','" + groupnum.Text + "','" + textBox5.Text + "','" + i.ToString() + "') ;";
                    DataSet ds1 = dataoperate.getDs(sqlString, "video");
                    camseach();
                    break;
                }
            }
           
        }

        private void gropnum_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void camseach()
        {
            string getlist = "SELECT  num,uid,uidpassword,userid,camid,id FROM cam ";
            DataSet videolist = dataoperate.getDs(getlist, "cam");

            camview.DataSource = videolist.Tables[0];
            camview.Columns[0].HeaderText = "序号";
            camview.Columns[0].Width = 50;
            camview.Columns[1].HeaderText = "摄像头UID";
            camview.Columns[1].Width = 150;

            camview.Columns[2].HeaderText = "摄像头密码";
            camview.Columns[2].Width = 100;
            camview.Columns[3].HeaderText = "所属分院";
            camview.Columns[3].Width = 100;
            camview.Columns[4].HeaderText = "摄像头编号";
            camview.Columns[4].Width = 100;
            camview.Columns[5].HeaderText = "主键id";
            camview.Columns[5].Width = 75;
           
           
        }
      

        private void Setbtn(bool n)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.btnsave.InvokeRequired)
            {
                SetbtnCallback d = new SetbtnCallback(Setbtn);
                this.Invoke(d, new object[] { n });
            }
            else
            {
                ////this.btnsave.Enabled = n;
            }
        }


       
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //btnsave.Enabled = false;
          
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //btnsave.Enabled = false;
       

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //btnsave.Enabled = false;
         


        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //btnsave.Enabled = false;
          


        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}