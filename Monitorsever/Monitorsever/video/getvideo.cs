
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Threading;



namespace video
{
    class getvideo
    {
        private string name;
        private string password;
        private string camhost;
        private int camport;
        private string videopath;
        private string videoname;
        public  getvideo(string host, int port, string uname, string pwd, string Path, string filename)
        {
            this.name = uname;
            this.password = pwd;
            this.camhost = host;
            this.camport = port;
            this.videopath = Path;
            this.videoname = filename;
        }
        public void con()
        {
            sPAM_S PAM_S = new sPAM_S();
            string uname = this.name;
            string pwd = this.password;
            string host = this.camhost;
            int port = this.camport;
            string path = this.videopath;
            string filename = this.videoname;

            PAM_S.Setaddr(uname, pwd, host, port, path, filename);
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(host), port);
            Console.WriteLine("conect begin");
            Console.WriteLine("ip " + host);
            Console.WriteLine("port " + port);
            Console.WriteLine("user " + uname);
            Console.WriteLine("pwd " + pwd);


            Socket camSocket;
            int i=0;

           con: 
                camSocket = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
           try
           {
               reqsend(PAM_S, camSocket, ip);
           }
           catch (Exception ex)
           {
               i++;
               Console.WriteLine("restar\r\n" + this.videopath + this.videoname + "第" + i + "次尝试1");

               Thread.Sleep(5000);
               if (i < 20)
               {
                   goto con;
               }
           }
            
            Console.WriteLine("sendover");

            try
            {
                responsecmd(PAM_S, camSocket, ip);
            }
            catch (Exception ex)
            {
                i++;
                Console.WriteLine("restar\r\n"+ this.videopath + this.videoname +"第" + i + "次尝试2");
                Thread.Sleep(5000);
                if (i < 20)
                {
                    goto con;
                }
            }
            try
            {
                videobegin(PAM_S, camSocket, ip);
            }
            catch (Exception ex)
            {
                i++;
                Console.WriteLine("restar\r\n" + this.videopath + this.videoname + "第" + i + "次尝试3");
                Thread.Sleep(5000);
                if (i < 20)
                {
                    goto con;
                }
            }
           
            
            
            try
            {
                savefile(PAM_S, camSocket, ip);
            }
            catch (Exception ex) 
            {
                i++;
                Console.WriteLine("restar\r\n" + this.videopath + this.videoname + "第" + i + "次尝试4");
                Thread.Sleep(5000);
                if (i < 20)
                {
                    goto con;
                }
            }




        }
        private static int reqsend(sPAM_S pParam, Socket Socket1, IPEndPoint ip)
        {


            string content = "Cseq: 1\r\nTransport: RTP/AVP/TCP;unicast;interleaved=0-1\r\n";
            string outBufferStr = "GET http://" + pParam.getIp() + ":" + pParam.getPort() + "/livestream/12?action=play&media=video HTTP/1.1\r\n"
                + "User-Agent: HiIpcam/V100R003 VodClient/1.0.0\r\n"
                + "Connection: Keep-Alive\r\n"
                + "Cache-Control: no-cache\r\n"
                + "Authorization: " + pParam.getuname() + " " + pParam.getPword() + "\r\n"
                + "Content-Length: " + content.Length + "\r\n"//???
                + "\r\n"
                + content;

            if (IsConnected(Socket1, ip))
            {



                Byte[] outBuffer = Encoding.ASCII.GetBytes(outBufferStr);

                while (true)
                {

                    int ret;
                    try
                    {
                        ret = Socket1.Send(outBuffer, outBuffer.Length, 0);
                    }
                    catch (SocketException e)
                    { throw new Exception("my exception"); }

                    if (ret < 0)
                    {
                        Console.WriteLine("send cmd err");
                        return -1;
                    }
                    else
                    {
                        return 0;
                        break;
                    }
                }

            }
            return 0;
        }

        private static int responsecmd(sPAM_S pParam, Socket Socket1, IPEndPoint ip)
        {


            while (true)
            {
                byte[] buf = new byte[256];
                try
                {
                    int a = Socket1.Receive(buf);
                }
                catch (SocketException e3) { throw new Exception("my exception"); }
                string bufstr = Encoding.ASCII.GetString(buf);

                if (bufstr.Contains("200 OK"))
                {
                    Console.WriteLine("校验 OK");

                    if (bufstr.Contains("m=video"))
                    {
                        int n1 = bufstr.IndexOf("m=video");
                        string videoformat = bufstr.Substring(n1 + 22, 8);

                        Console.WriteLine("wight/high: " + videoformat);
                        if (bufstr.Contains("m=audio"))
                        {
                            int n2 = bufstr.IndexOf("m=audio");
                            string audioformat = bufstr.Substring(n2 + 10, 5);

                            Console.WriteLine("audio: " + audioformat);
                            if (bufstr.Contains("Transport"))
                            {
                                int n3 = bufstr.IndexOf("Transport");
                                string Transport = bufstr.Substring(n3 + 10, 55);

                                Console.WriteLine("Transport: " + Transport);


                                return 0;


                            }


                        }


                    }
                    return 1;


                }
            }
        }


        private static void videobegin(sPAM_S pParam, Socket Socket1, IPEndPoint ip)
        {
            byte[] buf = new byte[1];
            byte[] buf2 = new byte[4];
            int i = 1;
            while (true)
            {
                int ret;
                try
                {
                    ret = Socket1.Receive(buf, 1, 0);
                    i = i + ret;
                }
                catch (SocketException e4) { throw new Exception("my exception"); }
                if (ret < 0)
                {
                    Console.WriteLine("send cmd err");
                    break;
                  
                }
                else
                {
                    buf2[0] = buf2[1];
                    buf2[1] = buf2[2];
                    buf2[2] = buf2[3];
                    buf2[3] = buf[0];
                    string bufstr = Encoding.ASCII.GetString(buf2);
                    if (bufstr == "\r\n\r\n")
                    {

                        Console.WriteLine("video begin");
                        break;
                    }
                    else if (i > 255) { break; }

                }
            }
        }
        private static byte[] ReceiveData(Socket socket, int size)
        {
            int total = 0;     //收到的总的字节数
            int dataleft = size;    //剩余的字节数

            byte[] data = new byte[size];  //接收数据的数组
            int rece = 0;      //收到的字节数
            //循环接收数据
            while (total < size)
            {
                rece = socket.Receive(data, total, dataleft, SocketFlags.None);
                //如果收到的字节数为0，那么说明连接断开，返回空的字节数组
                if (rece == 0)
                {
                    break;
                }
                total += rece;     //收到的字节数长度++
                dataleft -= rece;     //剩余的字节数--

            }
            return data;      //返回
        }
        private static void savefile(sPAM_S pParam, Socket Socket1, IPEndPoint ip)
        {



            string fileName = pParam.getpath() + pParam.getfilename();
            while (true)
            {
                FileStream filewrite;
            create: try
                {

                    filewrite = new FileStream(fileName, FileMode.Append);
                }
                catch (Exception)
                {
                    Directory.CreateDirectory(pParam.getpath()); goto create; Console.WriteLine("3");
                }
                BinaryWriter sw = new BinaryWriter(filewrite);//二进制流写入方式非常重要

                
                byte[] buf = ReceiveData(Socket1, 20);

                byte[] payloadLen_b = { 0, 0, 0, 0 };
                payloadLen_b[3] = buf[4];
                payloadLen_b[2] = buf[5];
                payloadLen_b[1] = buf[6];
                payloadLen_b[0] = buf[7];
                int payloadLen = BitConverter.ToInt32(payloadLen_b, 0);

                if (payloadLen < 12) { throw new Exception("my exception"); }
               // Console.WriteLine("payload_Len： " + (payloadLen - 12));
                //byte[] time_samp = { 5, 6, 7, 8 };
                //time_samp[3] = buf[12];
                //time_samp[2] = buf[13];
                //time_samp[1] = buf[14];
                //time_samp[0] = buf[15];
                //int timesamp = BitConverter.ToInt32(time_samp, 0);
                //Console.WriteLine("timesamp： " + timesamp);


                byte[] video1 = ReceiveData(Socket1, payloadLen - 12);
               
                try { sw.Write(video1); }
                catch (System.IO.IOException)
                {


                    {


                        throw new Exception("my exception");
                    }

                }
                finally
                {
                    sw.Close();
                }
             

            }
        }

        private class sPAM_S
        {
            public static string Uname;
            public string getuname() { return Uname; }

            public static string Pword;
            public string getPword() { return Pword; }

            public static string Ip;
            public string getIp() { return Ip; }

            public static int Port;
            public int getPort() { return Port; }
            //public static int Socket;
            //public static int state;

            public static string path = ".\\video\\";
            public string getpath() { return path; }

            public static string filename = DateTime.Now.ToString("yyyy_MM_dd_hh_mm") + ".h264";
            public string getfilename() { return filename; }
            public void Setaddr(string myuname, string mypword, string myip, int myport,string mypath,string myfilename)
            {

                Uname = myuname;
                Pword = mypword;
                Ip = myip;
                Port = myport;
                path = mypath;
                filename = myfilename;
            }

        }

        private static bool IsConnected(Socket sc, IPEndPoint ip)
        {
            int i = 1;
            bool isconnect = false;
        connect:
            try
            {
                sc.Connect(ip);
            }
            catch (SocketException)
            {
                i++;
                isconnect = false;
                Console.WriteLine("conect err\r\nconect again");
                if (i < 100)
                {
                    goto connect;
                }
               
            }
            isconnect = true;
            return isconnect;
        }
    }
}
