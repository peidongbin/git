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

namespace TestForUpdateConnectionClient
{
    public partial class Form1 : Form
    {
        private const int _serverPort = 8989;//服务器端口
        private const int _bufferSize = 4086;//接收缓冲区大小
        private IPEndPoint _ipEndPointServer = null;
        private volatile Socket _tcpSocketClient = null;//客户端socket对象，负责跟服务器通信
        private Thread _receiveMessageThread = null;
        delegate void UpdateReceiveMessage(string str);//代理，更新界面消息
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            //_tcpSocketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtServerIp.Text = "127.0.0.1";
            try
            {
                IPHostEntry ipHost = Dns.Resolve(txtServerIp.Text);
                IPAddress ipAddressServer = ipHost.AddressList[0];
                txtServerPort.Text = _serverPort.ToString();
                //IPAddress ipAddressServer = IPAddress.Parse(txtServerIp.Text);
                _ipEndPointServer = new IPEndPoint(ipAddressServer, Convert.ToInt32(txtServerPort.Text));
            }
            catch (Exception E)
            {
                MessageBox.Show("初始化失败：" + E.Message);
                this.Close();
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text.Equals("连接"))
            {
                btnConnect.Enabled = false;
                try
                {
                    IPHostEntry ipHost = Dns.Resolve(txtServerIp.Text);
                    IPAddress ipAddressServer = ipHost.AddressList[0];
                    txtServerPort.Text = _serverPort.ToString();
                    _ipEndPointServer = new IPEndPoint(ipAddressServer, Convert.ToInt32(txtServerPort.Text));
                    _tcpSocketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    _tcpSocketClient.Connect(_ipEndPointServer);
                    txtLocalAddress.Text = _tcpSocketClient.LocalEndPoint.ToString();
                    _receiveMessageThread = new Thread(new ThreadStart(ReceiveMessageThread));
                    _receiveMessageThread.Start();
                    btnSendMessage.Enabled = true;
                }
                catch (Exception E)
                {
                    //_tcpSocketClient = null;
                    btnSendMessage.Enabled = false;
                    MessageBox.Show("连接服务器失败：" + E.Message);
                    return;
                }
                finally
                {
                    btnConnect.Enabled = true;
                }
                btnConnect.Text = "断开";
            }
            else
            {
                btnConnect.Text = "连接";
                _tcpSocketClient.Close();
                btnSendMessage.Enabled = false;
                //_tcpSocketClient = null;
            }
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (txtSendMessage.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请输入需要发送的消息内容！");
                return;
            }
            byte[] dataSend = Encoding.Unicode.GetBytes(txtSendMessage.Text);
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
                        btnConnect.Text = "连接";
                        btnSendMessage.Enabled = false;
                        break;
                    }
                    string strReceived = Encoding.Unicode.GetString(dataReceived, 0, numReceived);
                    //Trace.WriteLine("收到" + _tcpSocketClient.RemoteEndPoint.ToString() + "消息" + numReceived.ToString() + "字节：" + strReceived);
                    AddReceiveMessage("收到" + _tcpSocketClient.RemoteEndPoint.ToString() + "消息" + numReceived.ToString() + "字节：" + strReceived);
                }
                catch (SocketException E)
                {
                    Trace.WriteLine(E.Message + "：异常退出连接");
                    if (_tcpSocketClient != null)
                    {
                        _tcpSocketClient = null;
                        btnConnect.Text = "连接";
                        btnSendMessage.Enabled = false;
                    }
                    break;
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message);
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtReceivedMsg.Text = string.Empty;
        }

        private void AddReceiveMessage(string str)
        {
            if (InvokeRequired)
            {
                Invoke(new UpdateReceiveMessage(AddReceiveMessage), str);
            }
            else
            {
                txtReceivedMsg.Text = txtReceivedMsg.Text + str + "\r\n";
            }
        }
    }
}