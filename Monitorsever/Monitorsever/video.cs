using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;


namespace Monitorsever
{
    class video
    {
        static double[,] YUV2RGB_CONVERT_MATRIX = new double[3, 3] { { 1, 0, 1.4022 }, { 1, -0.3456, -0.7145 }, { 1, 1.771, 0 } };
        string h264file = ".//bmprs//test.h264";
        private IntPtr hwnd1;
        string zcloud = "";
        string name = "admin";
        string password = "1111111";
        public video(IntPtr hwnd,string uid,string password)
        {
            this.hwnd1 = hwnd;
            this.zcloud = uid;
            this.name = "admin";
            this.password = password;

        }
        public video( string uid, string password,string filepath)
        {
         
            this.zcloud = uid;
            this.name = "admin";
            this.password = password;
            this.h264file = filepath;
        }
        public void getvideo()
        {
            #region MyRegion
           
            FFmpeg.av_register_all();//注册 decodec
            FFmpeg.AVCodec pCodec;
            FFmpeg.AVCodecContext pCodecCtx;
            FFmpeg.AVPicture avpicture;

            IntPtr pCodec_pt; IntPtr pCodecCtx_pt;

            pCodec_pt = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(FFmpeg.AVCodec)));

            pCodec_pt = FFmpeg.avcodec_find_decoder(FFmpeg.CodecID.CODEC_ID_H264);
            pCodec = (FFmpeg.AVCodec)Marshal.PtrToStructure((IntPtr)((UInt32)pCodec_pt), typeof(FFmpeg.AVCodec));
            Console.WriteLine("pCodec id= " + pCodec.id);

            pCodecCtx_pt = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(FFmpeg.AVCodecContext)));

            pCodecCtx_pt = FFmpeg.avcodec_alloc_context();
            pCodecCtx = (FFmpeg.AVCodecContext)Marshal.PtrToStructure((IntPtr)((UInt32)pCodecCtx_pt), typeof(FFmpeg.AVCodecContext));
            Console.WriteLine("pCodecCtx id= " + pCodecCtx.channels);

            int open_en = FFmpeg.avcodec_open(pCodecCtx_pt, pCodec_pt);
            if (open_en >= 0)
            {
                Console.WriteLine("avcodec_open ok" + open_en);
            }
            else { Console.WriteLine("avcodec_open err " + open_en); }

            /*********************************************************************************************/
            
        retry:

            int  session=Monitorsever.buildlist.getsession(zcloud);
       
            #region 获取截图重点
            string cszAESKey = null;

          
            if (session <0)
            {
              session = iotc.IOTC_Connect_ByUID(Marshal.StringToHGlobalAnsi(zcloud));
             
             
            }
            if (session >= 0) 
            { 
               
           
               
                int ret;
                Console.WriteLine("con uid ok"); Console.WriteLine("session=" + session);

                ulong timeout = 10;
                ulong pnServType = 0; ;

                int avIndex = Monitorsever.buildlist.getavindex(zcloud);
                if (avIndex >= 0) { Console.WriteLine("avchannel =" + avIndex); }
                else {
                    avIndex= iotc.avClientStart(session, Marshal.StringToHGlobalAnsi(name), Marshal.StringToHGlobalAnsi(password), timeout, pnServType, (byte)0); Console.WriteLine("avClientStart err=" + avIndex);

                    Monitorsever.buildlist.adduid(zcloud, session, avIndex);
                }

                string cabIOCtrlData = "0";

                ret = iotc.avSendIOCtrl(avIndex, 0, Marshal.StringToHGlobalAnsi(cabIOCtrlData), 4);
                Console.WriteLine(ret);

                ret = iotc.avSendIOCtrl(avIndex, 0x01FF, Marshal.StringToHGlobalAnsi(cabIOCtrlData), 4);
                Console.WriteLine(ret);
                ret = iotc.avSendIOCtrl(avIndex, 0x0300, Marshal.StringToHGlobalAnsi(cabIOCtrlData), 4);

                byte[] framebuf = new byte[40000];
                byte[] info = new byte[1000];
                int re_num = 0;
                int begin = 0;
                uint pnFrameIdx = 0;
                while (true)
                {

                    int data_len = iotc.avRecvFrameData(avIndex, ref   framebuf[0], 40000, ref   info[0], 10000, ref pnFrameIdx);//接收h264数据
                    if (data_len < 0)
                    {

                        if (begin == 1)
                        {
                            re_num++;
                            if (re_num == 100)
                            {
                                re_num = 0;
                                iotc.avClientStop(session);

                                goto retry;
                            }
                        }



                    }
                    Console.WriteLine("data_len  " + data_len);
                    if (data_len >= 1)
                    {
                     


                        begin = 1;
                        re_num = 0;
                        Console.WriteLine("data_len  " + data_len);

                        byte[] imgData = new byte[data_len];
                        for (int j = 0; j < data_len; j++)
                        {
                            imgData[j] = framebuf[j];
                        }
                    //FileStream filewrite;
                    //create: try
                    //    {
                    //        filewrite = new FileStream(h264file, FileMode.Append);
                    //    }
                    //       catch (DirectoryNotFoundException) { Directory.CreateDirectory(h264file); goto create; }
                    //    BinaryWriter sw = new BinaryWriter(filewrite);//二进制流写入方式非常重要
                    //    sw.Write(imgData);
                    //    sw.Close();
                        IntPtr imgData_pt = Marshal.AllocHGlobal(data_len);
                        Marshal.Copy(imgData, 0, imgData_pt, data_len);

                        IntPtr yuvdata = Marshal.AllocHGlobal(200);
                        int decode_result = 0;


                        int len = FFmpeg.avcodec_decode_video(pCodecCtx_pt, yuvdata, ref decode_result, imgData_pt, data_len);

                        pCodecCtx = (FFmpeg.AVCodecContext)Marshal.PtrToStructure((IntPtr)((UInt32)pCodecCtx_pt), typeof(FFmpeg.AVCodecContext));




                        if (len > 0)
                        {


                            avpicture = (FFmpeg.AVPicture)Marshal.PtrToStructure((IntPtr)((UInt32)yuvdata), typeof(FFmpeg.AVPicture));
                            byte[] data = new byte[avpicture.linesize[0] * pCodecCtx.height * 2];
                            int imgSize = pCodecCtx.width * pCodecCtx.height;
                            int frameSize = imgSize + (imgSize >> 1);
                            byte[] yuvframe = new byte[frameSize];
                            byte[] rgbframe = new byte[3 * imgSize];

                            Marshal.Copy(avpicture.data[0], data, 0, avpicture.linesize[0] * pCodecCtx.height);//前面的项目中参数也是错误的要更正 
                            Marshal.Copy(avpicture.data[1], data, (pCodecCtx.width + 32) * pCodecCtx.height, avpicture.linesize[1] * (pCodecCtx.height / 2));
                            Marshal.Copy(avpicture.data[2], data, (pCodecCtx.width + 32) * pCodecCtx.height * 5 / 4, avpicture.linesize[1] * (pCodecCtx.height / 2));

                            for (int l = 0; l < pCodecCtx.height; l++) { Array.Copy(data, l * (pCodecCtx.width + 32), yuvframe, l * pCodecCtx.width, pCodecCtx.width); }
                            for (int l = 0; l < (pCodecCtx.height / 2); l++) { Array.Copy(data, (pCodecCtx.width + 32) * pCodecCtx.height + l * (pCodecCtx.width + 32) / 2, yuvframe, imgSize + l * (pCodecCtx.width / 2), (pCodecCtx.width / 2)); }
                            for (int l = 0; l < (pCodecCtx.height / 2); l++) { Array.Copy(data, (pCodecCtx.width + 32) * pCodecCtx.height * 5 / 4 + l * (pCodecCtx.width + 32) / 2, yuvframe, imgSize * 5 / 4 + l * (pCodecCtx.width / 2), (pCodecCtx.width / 2)); }

                            ConvertYUV2RGB(yuvframe, rgbframe, pCodecCtx.width, pCodecCtx.height);
                            int yu = pCodecCtx.width * 3 % 4;
                            int bytePerLine = 0;
                            yu = yu != 0 ? 4 - yu : yu;
                            bytePerLine = pCodecCtx.width * 3 + yu;
                            byte[] bmpdata = new byte[bytePerLine * pCodecCtx.height];


                            MemoryStream ms1 = new MemoryStream();
                            #region 将RGb数据写入bmp位图流ctrl + K+S
                            byte[] identifier = new byte[2] { (byte)'B', (byte)'M' };
                            ms1.Write(identifier, 0, 2);
                            byte[] bytes0 = new byte[4];
                            ms1.Write(intToBytes(bytePerLine * pCodecCtx.height + 54), 0, 4);
                            ms1.Write(bytes0, 0, 4);
                            ms1.Write(intToBytes(54), 0, 4);
                            ms1.Write(intToBytes(40), 0, 4);
                            ms1.Write(intToBytes(pCodecCtx.width), 0, 4);
                            ms1.Write(intToBytes(pCodecCtx.height), 0, 4);
                            byte[] bytes1 = new byte[4] { 0x10, 0x00, 0x18, 0x00 };
                            ms1.Write(bytes1, 0, 4);
                            ms1.Write(bytes0, 0, 4);
                            ms1.Write(intToBytes(bytePerLine * pCodecCtx.height), 0, 4);
                            ms1.Write(bytes0, 0, 4);
                            ms1.Write(bytes0, 0, 4);
                            ms1.Write(bytes0, 0, 4);
                            ms1.Write(bytes0, 0, 4);
                            byte[] bgrdata = new byte[bytePerLine * pCodecCtx.height];
                            int gIndex = pCodecCtx.width * pCodecCtx.height;
                            int bIndex = gIndex * 2;

                            for (int y = pCodecCtx.height - 1, j = 0; y >= 0; y--, j++)
                            {
                                for (int x = 0, o = 0; x < pCodecCtx.width; x++)
                                {
                                    bgrdata[y * bytePerLine + o++] = rgbframe[bIndex + j * pCodecCtx.width + x];    // B
                                    bgrdata[y * bytePerLine + o++] = rgbframe[gIndex + j * pCodecCtx.width + x];    // G
                                    bgrdata[y * bytePerLine + o++] = rgbframe[j * pCodecCtx.width + x];  // R
                                }
                            }

                            ms1.Write(bgrdata, 0, bgrdata.Length);
                            #endregion


                            Bitmap bm = (Bitmap)Image.FromStream(ms1);
                            Size s = new Size();
                            s.Height = 300;
                            s.Width = 100;
                            Bitmap bm1 = new Bitmap(Image.FromStream(ms1), s);

                            Graphics g = Graphics.FromHwnd(this.hwnd1);

                            g.DrawImage(bm, 1, 1);
                            Thread.Sleep(50);
                            bm.Dispose();

                        }
                        else { Console.WriteLine("Con err =" + session); }
                    }
                    
                    //Thread.Sleep(1000);
                    //在此处关闭session资源
                }
            #endregion

                int ack = iotc.avDeInitialize();
                if (ack == 0) { Console.WriteLine("avDeInitialize"); }
                ack = iotc.IOTC_DeInitialize();
                if (ack == 0) { Console.WriteLine("IOTC_DeInitialize"); }
            }
            #endregion

        }
        public void recordvideo()
        {
            #region MyRegion

          

       

            /*********************************************************************************************/

        retry:

            int session = Monitorsever.buildlist.getsession(zcloud);

            #region 获取截图重点
            string cszAESKey = null;


            if (session < 0)
            {
                session = iotc.IOTC_Connect_ByUID(Marshal.StringToHGlobalAnsi(zcloud));


            }
            if (session >= 0)
            {



                int ret;
                Console.WriteLine("con uid ok"); Console.WriteLine("session=" + session);

                ulong timeout = 10;
                ulong pnServType = 0; ;

                int avIndex = Monitorsever.buildlist.getavindex(zcloud);
                if (avIndex >= 0) { Console.WriteLine("avchannel =" + avIndex); }
                else
                {
                    avIndex = iotc.avClientStart(session, Marshal.StringToHGlobalAnsi(name), Marshal.StringToHGlobalAnsi(password), timeout, pnServType, (byte)0); Console.WriteLine("avClientStart err=" + avIndex);

                    Monitorsever.buildlist.adduid(zcloud, session, avIndex);
                }

                string cabIOCtrlData = "0";

                ret = iotc.avSendIOCtrl(avIndex, 0, Marshal.StringToHGlobalAnsi(cabIOCtrlData), 4);
                Console.WriteLine(ret);

                ret = iotc.avSendIOCtrl(avIndex, 0x01FF, Marshal.StringToHGlobalAnsi(cabIOCtrlData), 4);
                Console.WriteLine(ret);
                ret = iotc.avSendIOCtrl(avIndex, 0x0300, Marshal.StringToHGlobalAnsi(cabIOCtrlData), 4);

                byte[] framebuf = new byte[40000];
                byte[] info = new byte[1000];
                int re_num = 0;
                int begin = 0;
                uint pnFrameIdx = 0;
                while (true)
                {

                    int data_len = iotc.avRecvFrameData(avIndex, ref   framebuf[0], 40000, ref   info[0], 10000, ref pnFrameIdx);//接收h264数据
                    if (data_len < 0)
                    {

                        if (begin == 1)
                        {
                            re_num++;
                            if (re_num == 100)
                            {
                                re_num = 0;
                                iotc.avClientStop(session);

                                goto retry;
                            }
                        }



                    }
                    Console.WriteLine("data_len  " + data_len);
                    if (data_len >= 1)
                    {



                        begin = 1;
                        re_num = 0;
                        Console.WriteLine("data_len  " + data_len);

                        byte[] imgData = new byte[data_len];
                        for (int j = 0; j < data_len; j++)
                        {
                            imgData[j] = framebuf[j];
                        }
                        FileStream filewrite;
                    create: try
                        {
                            filewrite = new FileStream(h264file, FileMode.Append);
                        }
                        catch (DirectoryNotFoundException) { Directory.CreateDirectory(h264file); goto create; }
                        BinaryWriter sw = new BinaryWriter(filewrite);//二进制流写入方式非常重要
                        sw.Write(imgData);
                        sw.Close();
                  

                 




            
                    }

                    Thread.Sleep(100);
                    //在此处关闭session资源
                }
            #endregion

                int ack = iotc.avDeInitialize();
                if (ack == 0) { Console.WriteLine("avDeInitialize"); }
                ack = iotc.IOTC_DeInitialize();
                if (ack == 0) { Console.WriteLine("IOTC_DeInitialize"); }
            }
            #endregion

        }

          

      
        /// <summary>
        ///     获取编码信息
        /// </summary>
        /// <param name="mimeType"></param>
        /// <returns></returns>
        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        /// <summary>
        ///     将int类型转换成字节数组
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] intToBytes(int value)
        {
            byte[] src = new byte[4];
            src[3] = (byte)((value >> 24) & 0xFF);
            src[2] = (byte)((value >> 16) & 0xFF);
            src[1] = (byte)((value >> 8) & 0xFF);
            src[0] = (byte)(value & 0xFF);
            return src;
        }

        /// <summary>
        ///     将YUV420P转换为RGB24
        /// </summary>
        /// <param name="yuvFrame"></param>
        /// <param name="rgbFrame"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        static void ConvertYUV2RGB(byte[] yuvFrame, byte[] rgbFrame, int width, int height)
        {//rgb24
            int uIndex = width * height;
            int vIndex = uIndex + ((width * height) >> 2);
            int gIndex = width * height;
            int bIndex = gIndex * 2;

            int temp = 0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // R分量
                    temp = (int)(yuvFrame[y * width + x] + (yuvFrame[vIndex + (y / 2) * (width / 2) + x / 2] - 128) * YUV2RGB_CONVERT_MATRIX[0, 2]);
                    rgbFrame[y * width + x] = (byte)(temp < 0 ? 0 : (temp > 255 ? 255 : temp));

                    // G分量
                    temp = (int)(yuvFrame[y * width + x] + (yuvFrame[uIndex + (y / 2) * (width / 2) + x / 2] - 128) * YUV2RGB_CONVERT_MATRIX[1, 1] + (yuvFrame[vIndex + (y / 2) * (width / 2) + x / 2] - 128) * YUV2RGB_CONVERT_MATRIX[1, 2]);
                    rgbFrame[gIndex + y * width + x] = (byte)(temp < 0 ? 0 : (temp > 255 ? 255 : temp));

                    // B分量
                    temp = (int)(yuvFrame[y * width + x] + (yuvFrame[uIndex + (y / 2) * (width / 2) + x / 2] - 128) * YUV2RGB_CONVERT_MATRIX[2, 1]);
                    rgbFrame[bIndex + y * width + x] = (byte)(temp < 0 ? 0 : (temp > 255 ? 255 : temp));
                }
            }

        }
    }
}
