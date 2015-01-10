//服务端主窗体

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using System.Net.Sockets;
using System.Net;
using Monitorsever.CommonClass;
using System.Data.OleDb;
using System.IO;
using System.Runtime.InteropServices;


namespace Monitorsever
{
  

    public partial class Form_main : Form
    {
        server server1 = new server();
        DataCon datacon = new DataCon();
        DataOperate dataoperate = new DataOperate();
        private const int _serverPort = 454;//服务器端口
        private const int _bufferSize = 4086;//接收缓冲区大小
        private volatile Socket _tcpSocketServer = null;//服务器socket对象，负责监听客户端的连接请求
        private volatile List<Socket> _listClientSocket = new List<Socket>();//客户端连接链表
        public volatile List<string> loginlist = new List<string>();
        private volatile List<uidstate> uidlist = new List<uidstate>();
        private Thread _threadAcceptClient = null;//跟主线程同步的线程，负责监听客户端的连接请求
        delegate void DelegateUpdateServerInfo(string str);//代理，更新界面消息
        delegate void DelegateUpdateClientList(object client, int operatroType);//代理，向界面更新客户端
        public Form_main()
        {
            InitializeComponent();
            _tcpSocketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ushort udp = 0;
            string s1 = "m1.iotcplatform.com";
            string s2 = "m2.iotcplatform.com";
            string s3 = "m3.iotcplatform.com";
            string s4 = "m4.iotcplatform.com";
            int n = iotc.IOTC_Initialize(udp, Marshal.StringToHGlobalAnsi(s1), Marshal.StringToHGlobalAnsi(s2), Marshal.StringToHGlobalAnsi(s3), Marshal.StringToHGlobalAnsi(s4));
            if (n == 0 || n == -3)
            { Console.WriteLine("IOTC_Initialize ok" + n); }
            else
            { Console.WriteLine("IOTC_Initialize err=" + n); }
            int i = iotc.avInitialize(8);
            if (i >= 1) { Console.WriteLine("avInitialize ok"); Console.WriteLine("MaxChannelNum=" + i); }
            else { Console.WriteLine("avInitialize err=" + i); }

            string getlist = "SELECT  id,userid,videoname,camid,begintime,endtime,path FROM video order by id desc";

            DataSet videolist = dataoperate.getDs(getlist, "video");
            dataGridView1.DataSource = videolist.Tables[0];
            dataGridView1.Columns[0].HeaderText = "序号";
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[1].HeaderText = "分院编号";
            dataGridView1.Columns[1].Width = 60;
            dataGridView1.Columns[2].HeaderText = "病人编号";
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].HeaderText = "摄像头编号";
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].HeaderText = "开始时间";
            dataGridView1.Columns[4].Width = 120;
            dataGridView1.Columns[5].HeaderText = "结束时间";
            dataGridView1.Columns[5].Width = 120;
            dataGridView1.Columns[6].HeaderText = "视频路径";
            dataGridView1.Columns[6].Width = 125;

            _threadAcceptClient = new Thread(new ThreadStart(ServerListnerThread));
            _threadAcceptClient.Start();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            Application.Exit();

        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_tcpSocketServer != null)
            {
                _tcpSocketServer.Close();
                _tcpSocketServer = null;
            }
            foreach (Socket sk in _listClientSocket)
                sk.Close();
            _listClientSocket.Clear();
            _listClientSocket = null;

            Application.Exit();
        }

        private void ServerListnerThread()
        {

            UpdateServerMessage("开始监听线程......");
            try
            {
                _tcpSocketServer.Bind(new IPEndPoint(IPAddress.Any, _serverPort));
                _tcpSocketServer.Listen(10);
            }
            catch (Exception E)
            {
                UpdateServerMessage(E.Message + "：监听线程退出......");
                return;
            }
            while (true)
            {
                try
                {
                    Socket clientSocket = _tcpSocketServer.Accept();
                    _listClientSocket.Add(clientSocket);



                    UpdateServerMessage("接收连接请求：" + clientSocket.RemoteEndPoint.ToString());
                    UpdateClientList(clientSocket, 1);

                    ParameterizedThreadStart parThreadStart = new ParameterizedThreadStart(ReceiveClientMessageThread);
                    Thread receiveMessageThread = new Thread(parThreadStart);
                    receiveMessageThread.Start(clientSocket);
                }
                catch (ObjectDisposedException E)//如果socket已经close，则会引发此异常
                {
                    UpdateServerMessage(E.Message + "：监听线程退出......");
                    break;
                }
                catch (Exception E)
                {
                    //Trace.WriteLine(E.Message + "：监听线程退出......");
                    if (_tcpSocketServer != null)
                        UpdateServerMessage(E.Message + "：监听线程退出......");
                    break;
                }
            }
        }

        private void ReceiveClientMessageThread(object para)
        {
            while (true)
            {
                Socket clientSocket = null;
                try
                {
                    byte[] dataReceived = new byte[_bufferSize];
                    clientSocket = (Socket)para;
                    int numReceived = clientSocket.Receive(dataReceived);
                    if (numReceived == 0)
                    {
                        UpdateServerMessage(clientSocket.RemoteEndPoint.ToString() + " 退出连接");
                        UpdateClientList(clientSocket, 2);
                        break;
                    }
                    string strReceived = Encoding.Unicode.GetString(dataReceived, 0, numReceived);
                    string strsever = server1.messagerecv(strReceived);
                    if (strsever.Contains("end"))
                    {

                        byte[] dataSend = Encoding.Unicode.GetBytes("err0");
                        clientSocket.Send(dataSend);
                        UpdateServerMessage(strsever + "\r\n" + clientSocket.RemoteEndPoint.ToString() + " 退出连接");
                        UpdateClientList(clientSocket, 2);
                        break;
                    }
                    else if (strsever.Contains("login"))
                    {
                        string[] cut = strsever.Split(new char[] { '_', '_' });
                        foreach (string c1 in loginlist)
                        {
                            if (c1.Contains(cut[0]))
                            {
                                byte[] dataSend = Encoding.Unicode.GetBytes("err1");
                                clientSocket.Send(dataSend);
                                UpdateServerMessage(strsever + "\r\n" + clientSocket.RemoteEndPoint.ToString() + " 退出连接");
                                UpdateClientList(clientSocket, 2);
                                break;
                            }
                        }
                        loginlist.Add(strsever + clientSocket.RemoteEndPoint.ToString());
                    }
                    else { UpdateServerMessage(strsever); }


                }
                catch (ObjectDisposedException E)//Socket对象close时触发此异常
                {

                    UpdateServerMessage(clientSocket.RemoteEndPoint.ToString() + " 退出连接：" + E.Message);
                    UpdateClientList(clientSocket, 2);
                    break;
                }
                catch (Exception E)
                {
                    if (clientSocket != null)
                    {
                        try
                        {

                            UpdateServerMessage(clientSocket.RemoteEndPoint.ToString() + " 退出连接：" + E.Message);
                            UpdateClientList(clientSocket, 2);
                        }
                        catch (Exception Ex)
                        {

                            if (_listClientSocket != null)
                                UpdateClientList(null, 3);
                        }
                    }
                    break;//结束接收线程
                }
            }
        }

        private void UpdateServerMessage(string str)// 填充消息框
        {
            if (InvokeRequired)
            {
                Invoke(new DelegateUpdateServerInfo(UpdateServerMessage), str);
            }
            else
            {
                txtServerInfo.Text = str + "\r\n";
                update_severmessage(str + "@" + DateTime.Now.ToString() + "\r\n");
            }
        }

        private void UpdateClientList(object obj, int operatorType)//
        {
            if (InvokeRequired)
            {
                Invoke(new DelegateUpdateClientList(UpdateClientList), obj, operatorType);
            }
            else
            {
                if (obj == null)
                {
                    listClient.Items.Clear();
                    _listClientSocket.Clear();

                    return;
                }
                Socket client = (Socket)obj;
                if (operatorType == 1)//表示添加
                    listClient.Items.Add(client.RemoteEndPoint.ToString());
                else//表示删除
                {
                    for (int i = 0; i < listClient.Items.Count; i++)
                    {
                        string str = (string)listClient.Items[i];
                        if (str.Equals(client.RemoteEndPoint.ToString()))
                        {
                            listClient.Items.RemoveAt(i);
                            _listClientSocket.Remove(client);//

                            break;
                        }
                    }
                }
                listClient.Text = listClient.Items.Count.ToString();
            }
        }






        private void listClient_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtServerInfo_TextChanged(object sender, EventArgs e)
        {

        }

        private void 退出程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Socket sk in _listClientSocket)
                sk.Close();
            _listClientSocket.Clear();
            _tcpSocketServer.Close();
            Environment.Exit(0);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string clientalive = "";
            string str = server1.Thread_trick();

            //string str1 = server1.err_trick();
            //Console.WriteLine("@");
            //Console.WriteLine(str1);
            if (str.Length > 0) { threadtrick.Text = str; }
            else { threadtrick.Text = "无正在进行中的录制\r\n"; }


            foreach (Socket sk in _listClientSocket)
            {
                byte[] dataSend = Encoding.Unicode.GetBytes(threadtrick.Text);
                try
                {
                    sk.Send(dataSend);

                }

                catch (Exception) { }


            }
            foreach (string cl in loginlist)
            {
                bool del = true;
                foreach (Socket sk in _listClientSocket)
                {
                    if (cl.Contains(sk.RemoteEndPoint.ToString())) { del = false; }
                }
                if (del)
                { loginlist.Remove(cl); break; }
            }
            foreach (string cl in loginlist)
            {
                string[] cut = cl.Split(new char[] { '_', '_' });
                clientalive = clientalive + cut[0] + "\r\n";
            }
            richTextBox1.Text = clientalive;


            string getlist = "SELECT  id,userid,videoname,camid,begintime,endtime,path FROM video order by id desc";
            DataSet videolist = dataoperate.getDs(getlist, "video");
            dataGridView1.DataSource = videolist.Tables[0];


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void threadtrick_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void 设备信息录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_camsetting frm_cam = new Form_camsetting();//创建档案管理窗体对象
            frm_cam.ShowDialog();//显示模式窗体
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ;
        }

        private void videoBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void 查询视频ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            video_search frm_video = new video_search();//
            frm_video.Show();//显示模式窗体
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            serverset_frm frm_set = new serverset_frm();//
            frm_set.ShowDialog();//显示模式窗体
        }

        private void 打开存储文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string get_setting = "SELECT  path FROM setting ";
                DataSet setting = dataoperate.getDs(get_setting, "setting");
                string path = setting.Tables[0].Rows[0][0].ToString();
                System.Diagnostics.Process.Start(path);
            }
            catch (Exception) { MessageBox.Show("请检查设置中路径是否正确。。。"); }

        }

        private void 录入人员管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userset_frm frm_user = new userset_frm();//
            frm_user.ShowDialog();//显示模式窗体
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void update_severmessage(string str)
        {

            FileStream filewrite = new FileStream(".\\server.txt", FileMode.Append);
            StreamWriter vw = new StreamWriter(filewrite);
            vw.Write(str);
            vw.Close();

        }

        private void 系统日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {


            try
            {
                System.Diagnostics.Process.Start(".\\server.txt");
            }
            catch (Win32Exception e1) { MessageBox.Show("找不到此文件，可能已经删除"); }
        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void 实时预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            livevideo frm_live = new livevideo();//
            frm_live.Show();//显示模式窗体
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            string str = server1.videotrick();
            if (str != "")
            {
                update_severmessage(str + "@" + DateTime.Now.ToString() + "\r\n");
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            test1 frm_live1 = new test1();//
            frm_live1.Show();//显示模式窗体
        }


     
    }
}
