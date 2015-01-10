using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Threading;
using System.Data.OleDb;
using Monitorclient.CommonClass;

namespace Monitorclient
{
    public partial class frm_main : Form
    {
        DataCon datacon = new DataCon();
        DataOperate dataoperate = new DataOperate();
        
        private const int _bufferSize = 4086;//接收缓冲区大小
        private IPEndPoint _ipEndPointServer = null;
        private volatile Socket _tcpSocketClient = null;//客户端socket对象，负责跟服务器通信
        private Thread _receiveMessageThread = null;
        delegate void UpdateReceiveMessage(string str);//代理，更新界面消息
        public frm_main()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            //_tcpSocketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "001";
            txtSendMessage2.Text = "01231";
            btnstop.Enabled = false;
           
            string getserver = "SELECT  serverip,serverport FROM setting ";

            DataSet server = dataoperate.getDs(getserver, "setting");
            txtServerIp.Text = server.Tables[0].Rows[0][0].ToString();
            txtServerPort.Text = server.Tables[0].Rows[0][1].ToString();
            try
            {
                string port = server.Tables[0].Rows[0][1].ToString();
                _ipEndPointServer = new IPEndPoint(IPAddress.Parse(server.Tables[0].Rows[0][0].ToString()), Convert.ToInt32(port));
            }
            catch (Exception E)
            {
                MessageBox.Show("初始化失败：" + E.Message);
                this.Close();
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text.Equals("登录"))
            {
                btnConnect.Enabled = false;
                comboBox1.Enabled = false;
                txtSendMessage1.ReadOnly = true;
                rec_txt.Text = "";
                string getserver = "SELECT  serverip,serverport FROM setting ";

                DataSet server = dataoperate.getDs(getserver, "setting");
                try
                {
                    string port = server.Tables[0].Rows[0][1].ToString();
                    _ipEndPointServer = new IPEndPoint(IPAddress.Parse(server.Tables[0].Rows[0][0].ToString()), Convert.ToInt32(port));
                   
                    _tcpSocketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    _tcpSocketClient.Connect(_ipEndPointServer);
                    txtLocalAddress.Text = _tcpSocketClient.LocalEndPoint.ToString();
                    _receiveMessageThread = new Thread(new ThreadStart(ReceiveMessageThread));
                    _receiveMessageThread.Start();
                    login();//登录
                    btnstart.Enabled = true;
                    //btnstop.Enabled = false ;
                }
                catch (Exception E)
                {
                    //_tcpSocketClient = null;
                    btnstart.Enabled = false;
                    rec_txt.Text = "";
                    btnstop.Enabled = false;
                    comboBox1.Enabled = true;
                    txtSendMessage1.ReadOnly = false;
                    MessageBox.Show("连接服务器失败：" + E.Message);
                    return;
                }
                finally
                {
                    btnConnect.Enabled = true;
                    comboBox1.Enabled = true;
                    txtSendMessage1.ReadOnly = false;
                    
                }
                btnConnect.Text = "断开";
                comboBox1.Enabled = false;
                txtSendMessage1.ReadOnly = true;
            }
            else
            {
                btnConnect.Text = "登录";
                _tcpSocketClient.Close();
                btnstart.Enabled = false;
                rec_txt.Text = "";
                btnstop.Enabled = false;
                comboBox1.Enabled = true;
                txtSendMessage1.ReadOnly = false;
                //_tcpSocketClient = null;
            }
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请输入需要发送的消息内容！");
                return;
            }


            string startstr = comboBox1.Text + ":" + txtSendMessage1.Text + ":" + txtSendMessage2.Text + ":open";
         
            byte[] dataSend = Encoding.Unicode.GetBytes(startstr);
            try
            {
                _tcpSocketClient.Send(dataSend);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message + "发送消息失败！");
                return;
            }
        }

        private void ReceiveMessageThread()
        {
            while (true)
            {
                try
                {
                    byte[] dataReceived = new byte[_bufferSize];
                    int numReceived = _tcpSocketClient.Receive(dataReceived);
                    if (numReceived == 0)
                    {
                        //MessageBox.Show("关闭连接！");
                        //_tcpSocketClient = null;
                        btnConnect.Text = "登录";
                        btnstart.Enabled = false;
                        rec_txt.Text = "";
                        btnstop.Enabled = false;
                        comboBox1.Enabled = true;
                        txtSendMessage1.ReadOnly = false;
                        break;
                    }
                    string strReceived = Encoding.Unicode.GetString(dataReceived, 0, numReceived);
                    //Trace.WriteLine("收到" + _tcpSocketClient.RemoteEndPoint.ToString() + "消息" + numReceived.ToString() + "字节：" + strReceived);
                   // AddReceiveMessage("收到" + _tcpSocketClient.RemoteEndPoint.ToString() + "消息" + numReceived.ToString() + "字节：" + strReceived);
                   
                    if (strReceived.Contains(comboBox1.Text + "#" + txtSendMessage2.Text + "#")) 
                    { 
                        if (comboBox1.Text.Length > 0 && txtSendMessage2.Text.Length > 0) 
                            {
                                AddReceiveMessage("正在录制"); btnstart.Enabled = false; btnstop.Enabled = true;
                            } 
                    }
                    else if (strReceived.Contains("err0")) 
                    {
                        btnConnect.Text = "登录";
                        btnstart.Enabled = false;
                        rec_txt.Text = "";
                        btnstop.Enabled = false;
                        threadtrick.Text = "未连接";
                        txtLocalAddress.Text = "未连接";
                        MessageBox.Show("连接出现问题,请检查用户名及密码!");
                        comboBox1.Enabled = true;
                        txtSendMessage1.ReadOnly = false;
                    }
                    else if (strReceived.Contains("err1"))
                    {
                        btnConnect.Text = "登录";
                        btnstart.Enabled = false;
                        rec_txt.Text = "";
                        btnstop.Enabled = false;
                        threadtrick.Text = "未连接";
                        txtLocalAddress.Text = "未连接";
                        MessageBox.Show("连接出现问题,用户已登录！");
                        comboBox1.Enabled = true;
                        txtSendMessage1.ReadOnly = false;
                    }
                    else { AddReceiveMessage(""); btnstart.Enabled = true;
                    btnstop.Enabled = false;
                    }
                    if (strReceived.Contains("err")==false) threadtrick.Text = strReceived;

                }
                catch (SocketException E)
                {
                    Trace.WriteLine(E.Message + "：异常退出连接");
                    if (_tcpSocketClient != null)
                    {
                        _tcpSocketClient = null;
                        btnConnect.Text = "登录";
                        btnstart.Enabled = false;
                        rec_txt.Text = "";
                        btnstop.Enabled = false;
                        comboBox1.Enabled = true;
                        txtSendMessage1.ReadOnly = false;
                    }
                    break;
                }
                catch (Exception E)
                {
                   
                    continue;
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_tcpSocketClient != null)
            {
                _tcpSocketClient.Close();
                _tcpSocketClient = null;
            }
        }

        private void btnstop_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请输入需要发送的消息内容！");
                return;
            }


            string startstr = comboBox1.Text + ":" + txtSendMessage1.Text + ":" + txtSendMessage2.Text + ":close";
         
            byte[] dataSend = Encoding.Unicode.GetBytes(startstr);
            try
            {
                _tcpSocketClient.Send(dataSend);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message + "发送消息失败！");
                return;
            }
        }

        private void AddReceiveMessage(string str)
        {
            if (InvokeRequired)
            {
                Invoke(new UpdateReceiveMessage(AddReceiveMessage), str);
            }
            else
            {
                rec_txt.Text =  str + "\r\n";
            }
        }

        private void txtSendMessage1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            login();
        }

        private void rec_txt_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void threadtrick_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtSendMessage0_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSendMessage2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void login()
        {
            if (comboBox1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请输入需要发送的消息内容！");
                return;
            }


            string startstr = comboBox1.Text + ":" + txtSendMessage1.Text + ":" + txtSendMessage2.Text + ":R&Q";

            byte[] dataSend = Encoding.Unicode.GetBytes(startstr);
            try
            {
                _tcpSocketClient.Send(dataSend);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message + "发送消息失败！");
                return;
            }
        }

        private void txtLocalAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void but_setting_Click(object sender, EventArgs e)
        {
            setting_frm frm_set = new setting_frm();//
            frm_set.ShowDialog();//显示模式窗体
            string getserver = "SELECT  serverip,serverport FROM setting ";

            DataSet server = dataoperate.getDs(getserver, "setting");
            txtServerIp.Text = server.Tables[0].Rows[0][0].ToString();
            txtServerPort.Text = server.Tables[0].Rows[0][1].ToString();
        }
    }
}