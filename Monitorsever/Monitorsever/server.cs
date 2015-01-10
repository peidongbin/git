//处理接收到客户端消息


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monitorsever.CommonClass;
using System.Data;
using System.Threading;
using video;
using System.Data.OleDb;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.IO;

namespace Monitorsever
{
    class server
    {


        List<Thread> listThread = new List<Thread>(10);
        private volatile List<VlcPlayer> _listClientSocket = new List<VlcPlayer>();//客户端连接链表
        DataCon datacon = new DataCon();
        DataOperate dataoperate = new DataOperate();
        bool[] err = new bool[10];
      
        bool[] netok = new bool[10];
        Thread thread=null;
       
        string pluginPath = System.Environment.CurrentDirectory + "\\plugins\\";
        string pathmain = null;
       public string messagerecv(string recvstr)
        {
            string[] mss = recvstr.Split(new char[] { ':', ':' });
            string userID = mss[0];
            Console.WriteLine(userID);
            string pwd = mss[1];
            string videoID = mss[2];
            string videocmd = mss[3];
            string servermessage = "无效操作";
           


            if (videocmd.Equals("open"))
            {
                int camid;
                string uid;
                string uidpassword;

                string sqlstr = "SELECT    camid,uid,uidpassword  FROM cam WHERE     (userid ='" + userID + "')";

                DataSet ds = dataoperate.getDs(sqlstr, "cam");
                if (ds.Tables.Count > 0)
                {
                    Console.WriteLine(ds.Tables[0].Rows.Count);//获得数据库userid对应的 行数 及对应相机数
                    servermessage = null;
                    string get_setting = "SELECT  path FROM setting ";
                    DataSet setting = dataoperate.getDs(get_setting, "setting");
                    pathmain = setting.Tables[0].Rows[0][0].ToString();
                    for (int i = ds.Tables[0].Rows.Count - 1; i >= 0; i--)
                    {
                        camid = int.Parse(ds.Tables[0].Rows[i][0].ToString());

                        uid = ds.Tables[0].Rows[i][1].ToString();

                        uidpassword = ds.Tables[0].Rows[i][2].ToString();

                     
                        string nowtime = DateTime.Now.ToString();

                        string timestr = DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss");
                        string filename = videoID + "_" + camid.ToString() + "_" + timestr + ".h264";
                        string mp4filename = videoID + "_" + camid.ToString() + "_" + timestr + ".mp4";
                        string path = pathmain + "\\" + userID + "\\" + mp4filename;
                        //路径检查
                        if (!System.IO.Directory.Exists(pathmain + "\\" + userID + "\\"))//判断文件夹存在  
                        {
                            Console.WriteLine("路径不存在");
                            System.IO.Directory.CreateDirectory(pathmain + "\\" + userID + "\\");
                        }
                        string sqlString = "insert into video(userid,videoname,begintime,path,camid) values ('" + userID + "','" + videoID + "','" + nowtime + "','" + path + "','" + camid.ToString() + "') ;";
                        DataSet ds1 = dataoperate.getDs(sqlString, "video");

                        video video1 = new video(uid, uidpassword, pathmain + "\\" + userID + "\\" + filename);

                        Thread thread = new Thread(new ThreadStart(video1.recordvideo));
                        thread.Name = userID + "#" + videoID + "#" + camid.ToString() + "#" + nowtime + "#" + camid.ToString() + "#" + uid ;
                        listThread.Add(thread);
                        thread.IsBackground = true;

                        thread.Start();


                        if (servermessage == null) { servermessage = userID + "用户" + videoID + "摄像头" + camid.ToString() + "开始录制"; }
                        else
                        {
                            servermessage = servermessage + "\r\n" + userID + "用户" + videoID + "摄像头" + camid.ToString() + "开始录制";
                        }
                    }



                }


            }
            if (videocmd.Equals("close"))
            {


                    servermessage = null;

                    for (int i = 0; i < 4; i++)
                    {
                        foreach (Thread tempThread in listThread)
                        {

                            if (tempThread.Name.Contains(userID + "#" + videoID + "#" + i))
                            {



                                string[] cut = tempThread.Name.Split(new char[] { '#', '#' });
                                DateTime begintime = Convert.ToDateTime(cut[3]);
                                string nowtime = DateTime.Now.ToString();
                                //err[int.Parse(cut[4])] = false;
                                string updatestr = "update video set endtime='" + nowtime + "' where userid='" + userID + "' and begintime=#" + begintime + "# ";
                                DataSet ds2 = dataoperate.getDs(updatestr, "video");
                                if (servermessage == null)
                                { servermessage = userID + "用户" + videoID + "第" + i + "文件结束录制"; }
                                else
                                { servermessage = servermessage + "\r\n" + userID + "用户" + videoID + "第" + i + "文件结束录制"; }


                                tempThread.Abort();
                                listThread.Remove(tempThread);
                                string begingtimestr = begintime.ToString("yyyy_MM_dd_hh_mm_ss");
                                string filename = videoID + "_" + i.ToString() + "_" + begingtimestr + ".h264";

                                string fullfilename = pathmain + "\\" + userID + "\\" + filename;
                                string[] s = fullfilename.Split(new char[] { '.' });
                                mp4box(fullfilename, "10", s[0] + ".mp4");

                                break;
                            }
                        }
                    }
             
            }
       
            if (videocmd.Equals("R&Q"))
            {


                string strSql = "select * from login_db where loginname='" + userID + "' and pwd='" + pwd + "'";
                DataSet ds = dataoperate.getDs(strSql, "login_db");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    servermessage = userID + "_login";

                }
                else
                {
                    servermessage = userID + "_end";
                }
            }
            return servermessage;

        }
        public string Thread_trick()
        {
            string alive = "";
            foreach (Thread tempThread in listThread)
            {


                alive = alive + tempThread.Name + "_正在录制\r\n";

            }
            return alive;
        }
        public string err_trick()
        {
            string errmsg = "";
            foreach (VlcPlayer sk in _listClientSocket)
            {
                sk.SetVolume(21);

                errmsg = errmsg + sk.GetVolume() + "\r\n";

            }
            return errmsg;
        }
        public string videotrick()
        {
            string str="";
            this.thread =
                new Thread(new ThreadStart(this.testcam));
            
            this.thread.Start();
            //if ((err[0] || err[1] || err[2] || err[3] || err[4] || err[5] || err[6] || err[7] || err[8] || err[9] ) == false) { str = "ok"; }
            if (err[0]) { str= "cam1err"; }
            if (err[1]) { str = str + "cam2err"; }
            if (err[2]) { str = str + "cam3err"; } 
            if (err[3]) { str = str + "cam4err"; }
            if (err[4]) { str = str + "cam5err"; }
            if (err[5]) { str = str + "cam6err"; }
            if (err[6]) { str = str + "cam7err"; }
            if (err[7]) { str = str + "cam8err"; }
            if (err[8]) { str = str + "cam9err"; }
            if (err[9]) { str = str + "cam10err"; }

        
        
                foreach (VlcPlayer sk in _listClientSocket)
                {
                    string[] cut = sk.name.Split(new char[] { '#', '#' });
             
                        if ((err[int.Parse(cut[4])]) && (netok[int.Parse(cut[4])]))
                        {
                            sk.Stop();
                            _listClientSocket.Remove(sk);
                            DateTime begintime = Convert.ToDateTime(cut[3]);
                            string timestr = DateTime.Now.ToString("hh_mm_ss");
                            string beginstr = begintime.ToString("yyyy_MM_dd_hh_mm_ss");
                            string path = pathmain + "\\" + cut[0] + "\\" + cut[1] + "#" + cut[2] + "#" + beginstr + "#" + timestr + ".mp4";

                            //VlcPlayer vlc_player_ = new VlcPlayer(pluginPath, "E:\\DCIM\\004\\" + cut[1] + "#" + cut[2] + "#" + cut[3] + "1.mp4");
                            VlcPlayer vlc_player_ = new VlcPlayer(pluginPath, path);

                            vlc_player_.name = sk.name;
                            vlc_player_.PlayURL("rtsp://" + cut[7] + ":" + cut[8] + "@" + cut[5] + ":" + cut[6] + "/12");

                            _listClientSocket.Add(vlc_player_);
                           
                            err[int.Parse(cut[4])] = false;
                         break;
                        }
                    }
                return str;

        }
        private void testcam()
        {
            try
            {
                foreach (VlcPlayer sk in _listClientSocket)
                {
                    string[] cut = sk.name.Split(new char[] { '#', '#' });



                    IPEndPoint ip = new IPEndPoint(IPAddress.Parse(cut[5]), int.Parse(cut[6]));
                    Socket Sockettest;
                    Sockettest = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    try
                    {

                        Sockettest.Connect(ip);
                        netok[int.Parse(cut[4])] = true;
                        Sockettest.Close();
                    }
                    catch (SocketException ex)
                    {

                        err[int.Parse(cut[4])] = true;
                        netok[int.Parse(cut[4])] = false;
                        Sockettest.Close();


                    }
                }
                Thread.CurrentThread.Abort();
            }
            catch (Exception e) { }
        }
        private void mp4box(string h264filename, string fps, string mp4filename)
        {


            Process myProcess = new Process();

            try
            {
                myProcess.StartInfo.UseShellExecute = false;
                string str = System.Environment.CurrentDirectory;
                myProcess.StartInfo.FileName = str + "/mp4box.exe";
                myProcess.StartInfo.Arguments = " -add " + h264filename + ":fps=" + fps + " -new " + mp4filename;
                myProcess.StartInfo.CreateNoWindow = true;

                myProcess.Start();
                myProcess.WaitForExit();
                File.Delete(h264filename);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
