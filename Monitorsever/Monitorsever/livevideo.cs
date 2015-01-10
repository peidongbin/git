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
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace Monitorsever
{
    public partial class livevideo : Form
    {
        private volatile List<VlcPlayer> _listClientSocket = new List<VlcPlayer>();//客户端连接链表
      
        DataCon datacon = new DataCon();
        DataOperate dataoperate = new DataOperate();
        delegate void SetTextCallback(string text);
        string ip;
        int port;
        string uname;
        string userpwd;
        DataSet ds;
        bool[] en = new bool[4];
        Thread thread=null;
        string pluginPath = System.Environment.CurrentDirectory + "\\plugins\\";
        string ip1;
        int port1;
        string uname1;
        string userpwd1;
        bool[] netok=new bool[4];
        bool[] err=new bool[4]; 
         
        public livevideo()
        {

            InitializeComponent();
       


        }

        private void livevideo_Load(object sender, EventArgs e)
        {
            audio1.Text = "静音";
            audio2.Text = "静音";
            audio3.Text = "静音";
            audio4.Text = "静音";
            audio1.Enabled = false;
            audio2.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;

            audio3.Enabled = false;
            audio4.Enabled = false;
            textBox2.Text = "ok";
            load_1.BringToFront();
             
        }
        private void livevideo_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (VlcPlayer sk in _listClientSocket)
            { sk.Stop(); }
          
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            string sqlstr = "SELECT    camip, camport,uname,pwd,camid  FROM cam WHERE   (userid ='" + comboBox1.Text + "')";
            ds = dataoperate.getDs(sqlstr, "cam");
            textBox1.Text = "共查询到" + ds.Tables[0].Rows.Count + "条记录";
            button1.Enabled = true;
            button2.Enabled = true;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            audio1.Text = "静音";
            audio2.Text = "静音";
            audio3.Text = "静音";
            audio4.Text = "静音";
            audio1.Enabled = false;
            audio2.Enabled = false;
            timer1.Enabled = true;

            audio3.Enabled = false;
            audio4.Enabled = false;
            load_1.Visible = false;
            load_2.Visible = false;
            load_3.Visible = false;
            load_4.Visible = false;
            foreach (VlcPlayer sk in _listClientSocket)
            { sk.Stop(); }
            _listClientSocket.Clear();
            IntPtr render_wnd_1 = panel1.Handle;
            IntPtr render_wnd_2 = panel2.Handle;
            IntPtr render_wnd_3 = panel3.Handle;
            IntPtr render_wnd_4 = panel4.Handle;
            if (ds.Tables.Count > 0)
            {
             
               
          
                for (int i = ds.Tables[0].Rows.Count - 1; i >= 0; i--)
                {
                    ip = ds.Tables[0].Rows[i][0].ToString();
                    
                    port = int.Parse(ds.Tables[0].Rows[i][1].ToString());
                  
                    uname = ds.Tables[0].Rows[i][2].ToString();
                  
                    userpwd = ds.Tables[0].Rows[i][3].ToString();
                   
                    string n = ds.Tables[0].Rows[i][4].ToString();
                  
                  
                  

                
                    VlcPlayer vlc_player_ = new VlcPlayer(pluginPath);
              
                    if (n == "1") { vlc_player_.SetRenderWindow((int)render_wnd_1); }
                    if (n == "2") { vlc_player_.SetRenderWindow((int)render_wnd_2); }
                    if (n == "3") { vlc_player_.SetRenderWindow((int)render_wnd_3); }
                    if (n == "4") { vlc_player_.SetRenderWindow((int)render_wnd_4); }
                    vlc_player_.PlayURL("rtsp://" + uname + ":" + userpwd + "@" + ip + ":" + port + "/12");
                    vlc_player_.name = n;
                  
                    _listClientSocket.Add(vlc_player_);//未将对象引用到实例
                   }
                for (int i = 0; i <= 3; i++) { en[i] = false; }
                    foreach (VlcPlayer sk in _listClientSocket)
                    {
                        sk.SetVolume(0);
                        if (sk.name == "1") { en[0] = true; load_1.Visible = true; }
                        if (sk.name == "2") { en[1] = true; load_2.Visible = true; }
                        if (sk.name == "3") { en[2] = true; load_3.Visible = true; }
                        if (sk.name == "4") { en[3] = true; load_4.Visible = true; }
                    }
                    for (int i = 0; i <= 3; i++) 
                    {
                        if (en[0] == false) { nel1.Text = "1号无输入"; } else { audio1.Enabled = true; nel1.Text = "1号输入"; }
                        if (en[1] == false) { nel2.Text = "2号无输入"; } else { audio2.Enabled = true; nel2.Text = "2号输入"; }
                        if (en[2] == false) { nel3.Text = "3号无输入"; } else { audio3.Enabled = true; nel3.Text = "3号输入"; }
                        if (en[3] == false) { nel4.Text = "4号无输入"; } else { audio4.Enabled = true; nel4.Text = "4号输入"; }
                    }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void panel1_DblClick(object sender, EventArgs e)
        {
            panel1.Dock = DockStyle.Fill;
        }

        private void audio1_Click(object sender, EventArgs e)
        {
            if (audio1.Text == "静音")
            {
                audio1.Text = "正常"; 
                foreach (VlcPlayer sk in _listClientSocket)
                {
                   
                    if (sk.name == "1") { sk.SetVolume(50); }

                }
            }
            else
            {
                audio1.Text = "静音"; 
                foreach (VlcPlayer sk in _listClientSocket)
                {

                    if (sk.name == "1") { sk.SetVolume(0); }

                }
            }
           
        }
        private void audio2_Click(object sender, EventArgs e)
        {
            if (audio2.Text == "静音")
            {
                audio2.Text = "正常";
                foreach (VlcPlayer sk in _listClientSocket)
                {

                    if (sk.name == "2") { sk.SetVolume(50); }

                }
            }
            else
            {
                audio2.Text = "静音"; 

                foreach (VlcPlayer sk in _listClientSocket)
                {

                    if (sk.name == "2") { sk.SetVolume(0); }

                }
            }

        }
        private void audio3_Click(object sender, EventArgs e)
        {
            if (audio3.Text == "静音")
            {
                audio3.Text = "正常";
                foreach (VlcPlayer sk in _listClientSocket)
                {

                    if (sk.name == "3") { sk.SetVolume(50); }

                }
            }
            else
            {
                audio3.Text = "静音"; 

                foreach (VlcPlayer sk in _listClientSocket)
                {

                    if (sk.name == "3") { sk.SetVolume(0); }

                }
            }

        }
        private void audio4_Click(object sender, EventArgs e)
        {
            if (audio4.Text == "静音")
            {
                audio4.Text = "正常";
                foreach (VlcPlayer sk in _listClientSocket)
                {

                    if (sk.name == "4") { sk.SetVolume(50); }

                }
            }
            else
            {
                audio4.Text = "静音"; 

                foreach (VlcPlayer sk in _listClientSocket)
                {

                    if (sk.name == "4") { sk.SetVolume(0); }

                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            try
            {
                foreach (VlcPlayer sk in _listClientSocket)
                { sk.Stop(); }
            }
            catch(Exception){}
            audio1.Enabled = false;
            audio2.Enabled = false;

            audio3.Enabled = false;
            audio4.Enabled = false;


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string strDPath = Application.StartupPath;
          
              this.thread =
                new Thread(new ThreadStart(this.testcam));

            this.thread.Start();
            if ((err[0] || err[1] || err[2] || err[3]) == false) { textBox2.Text = "ok"; }
            if (err[0]) { load_1.Image = Image.FromFile(strDPath + "\\pic\\loading.gif"); textBox2.Text = "1err"; } else { load_1.Image = Image.FromFile(strDPath + "\\pic\\pic.jpg"); }
            if (err[1]) { load_2.Image = Image.FromFile(strDPath + "\\pic\\loading.gif"); textBox2.Text = textBox2.Text + "2err"; } else { load_2.Image = Image.FromFile(strDPath + "\\pic\\pic.jpg"); }
            if (err[2]) { load_3.Image = Image.FromFile(strDPath + "\\pic\\loading.gif"); textBox2.Text = textBox2.Text + "3err"; } else { load_3.Image = Image.FromFile(strDPath + "\\pic\\pic.jpg"); }
            if (err[3]) { load_4.Image = Image.FromFile(strDPath + "\\pic\\loading.gif"); textBox2.Text = textBox2.Text + "4err"; } else { load_4.Image = Image.FromFile(strDPath + "\\pic\\pic.jpg"); }
                for (int i = ds.Tables[0].Rows.Count - 1; i >= 0; i--)
            {
                ip = ds.Tables[0].Rows[i][0].ToString();

                port = int.Parse(ds.Tables[0].Rows[i][1].ToString());

                uname = ds.Tables[0].Rows[i][2].ToString();

                userpwd = ds.Tables[0].Rows[i][3].ToString();
                int n = int.Parse(ds.Tables[0].Rows[i][4].ToString());
                foreach (VlcPlayer sk in _listClientSocket)
                {
                    if(sk.name==n.ToString())
                    {
                        if ((err[n-1]) && (netok[n-1]))
                        {
                            sk.PlayURL("rtsp://" + uname + ":" + userpwd + "@" + ip + ":" + port + "/12");
                            
                            err[n-1] = false;
                        }
                    }

                }
               
            
        }
                  

        }



        private void testcam()
        {

            for (int i = ds.Tables[0].Rows.Count - 1; i >= 0; i--)
            {
                ip1 = ds.Tables[0].Rows[i][0].ToString();

                port1 = int.Parse(ds.Tables[0].Rows[i][1].ToString());

                

                IPEndPoint ip = new IPEndPoint(IPAddress.Parse(ds.Tables[0].Rows[0][0].ToString()), int.Parse(ds.Tables[0].Rows[0][1].ToString()));
                Socket Sockettest;
                Sockettest = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                try
                {

                    Sockettest.Connect(ip);
                    netok[int.Parse(ds.Tables[0].Rows[i][4].ToString())-1] = true;
                    Sockettest.Close();
                }
                catch (Exception ex)
                {
                    
                    err[int.Parse(ds.Tables[0].Rows[i][4].ToString())-1] = true;
                    netok[int.Parse(ds.Tables[0].Rows[i][4].ToString())-1] = false;
                    Sockettest.Close();
                  

                }
            }
            Thread.CurrentThread.Abort();
        }
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.textBox2.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.textBox2.Text = text;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
      
    }
}
