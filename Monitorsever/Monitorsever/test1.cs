using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Monitorsever.CommonClass;


namespace Monitorsever
{
    public partial class test1 : Form
    {
        DataCon datacon = new DataCon();
        DataOperate dataoperate = new DataOperate();
        Thread thread1 = null;
        public test1()
        {
            InitializeComponent();
        }
     

        private void button1_Click_1(object sender, EventArgs e)
        {
            string strDPath = Application.StartupPath;
            
            string uid;
            string uidpassword;
            uid=textBox1.Text.ToString();
            uidpassword=textBox2.Text.ToString();

            try { thread1.Abort(); }
            catch (Exception) { }
            IntPtr hwd = panel1.Handle;
            video video1 = new video(hwd,uid,uidpassword);
            thread1 = new Thread(new ThreadStart(video1.getvideo));
            thread1.Start();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlstr = "SELECT    camid,uid,uidpassword  FROM cam WHERE   (userid ='" + comboBox1.Text + "')";
            DataSet ds = dataoperate.getDs(sqlstr, "login_db");
            comboBox2.Items.Clear();
            int a = ds.Tables[0].Rows.Count;
            try
            {
                for (int i = ds.Tables[0].Rows.Count - 1; i >= 0; i--)
                {
                    string n = ds.Tables[0].Rows[i][0].ToString();
                    comboBox2.Items.Add(n);
                }
            }

            catch (Exception)
            {

            }
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
             
            int cam_id = int.Parse(comboBox2.Text);
            string sqlstr = "SELECT  uid, uidpassword,uname FROM cam where userid='" +comboBox1.Text + "'and camid="+cam_id+"";
            DataSet ds = dataoperate.getDs(sqlstr, "login_db");
            try 
            {
                
                
                textBox1.Text = ds.Tables[0].Rows[0][0].ToString();
                textBox2.Text = ds.Tables[0].Rows[0][1].ToString();
                    
           }
            catch(Exception ){}
        }

        private void test1_Load(object sender, EventArgs e)
        {
            string sqlstr = "SELECT    camid,uid,uidpassword  FROM cam WHERE   (userid ='001')";
            DataSet ds = dataoperate.getDs(sqlstr, "login_db");
            comboBox2.Items.Clear();
            int a = ds.Tables[0].Rows.Count;
            try
            {
                for (int i = ds.Tables[0].Rows.Count - 1; i >= 0; i--)
                {
                    string n = ds.Tables[0].Rows[i][0].ToString();
                    comboBox2.Items.Add(n);
                }
            }

            catch (Exception)
            {

            }
        }

        private void test1_closing(object sender, EventArgs e)
        {
            try { thread1.Abort(); }
            catch (Exception) { }
        }
  
    }
}
