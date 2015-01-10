using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime;
using System.Runtime.InteropServices;
using System.Security;


namespace Monitorsever
{
    class iotc
    {

        [DllImport("avformat.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void av_register_all();
        [DllImport("IOTCAPIs.dll", EntryPoint = "IOTC_Lan_Search", CallingConvention = CallingConvention.Cdecl)]
        
        

        public static extern int IOTC_Lan_Search(IntPtr ptArray, int ArrayLen, int time);

        [DllImport("IOTCAPIs.dll", EntryPoint = "IOTC_Connect_ByUID", CallingConvention = CallingConvention.Cdecl)]
        
        public static extern int IOTC_Connect_ByUID(IntPtr ptArray);

        [DllImport("IOTCAPIs.dll", EntryPoint = "IOTC_Connect_ByUID2", CallingConvention = CallingConvention.Cdecl)]
        
        public static extern int IOTC_Connect_ByUID2(IntPtr ptArray, IntPtr ptArray1, int a);

        [DllImport("IOTCAPIs.dll", EntryPoint = "IOTC_Get_Version", CallingConvention = CallingConvention.Cdecl)]
        

        public static extern void IOTC_Get_Version(out ulong ver);
        [DllImport("IOTCAPIs.dll", EntryPoint = "IOTC_Initialize", CallingConvention = CallingConvention.Cdecl)]
        
        public static extern int IOTC_Initialize(ushort udpport, IntPtr s1, IntPtr s2, IntPtr s3, IntPtr s4);


        [DllImport("IOTCAPIs.dll", EntryPoint = "IOTC_Initialize", CallingConvention = CallingConvention.Cdecl)]
        
        public static extern int IOTC_Session_Read(int sesionID, IntPtr s1, IntPtr s2, IntPtr s3);




        [DllImport("IOTCAPIs.dll", EntryPoint = "IOTC_Session_Channel_ON", CallingConvention = CallingConvention.Cdecl)]
        
        public static extern int IOTC_Session_Channel_ON(int sessionid, byte nIOTCChannelID);
        [DllImport("IOTCAPIs.dll", EntryPoint = "IOTC_Session_Get_Free_Channel", CallingConvention = CallingConvention.Cdecl)]
        
        public static extern int IOTC_Session_Get_Free_Channel(int nIOTCSessionID);

        [DllImport("IOTCAPIs.dll", EntryPoint = "IOTC_DeInitialize", CallingConvention = CallingConvention.Cdecl)]
        
        public static extern int IOTC_DeInitialize();



        [DllImport("AVApis.dll", EntryPoint = "avInitialize", CallingConvention = CallingConvention.Cdecl)]
        
        public static extern int avInitialize(int nMaxChannelNum);

        [DllImport("AVApis.dll", EntryPoint = "avClientStart", CallingConvention = CallingConvention.Cdecl)]
        
        public static extern int avClientStart(int sessionid, IntPtr cszViewAccount, IntPtr cszViewPassword, ulong timeout, ulong sese, byte nIOTCChannelID);

        [DllImport("AVApis.dll", EntryPoint = "avDeInitialize", CallingConvention = CallingConvention.Cdecl)]
        
        public static extern int avDeInitialize();


        [DllImport("AVApis.dll", EntryPoint = "avRecvFrameData2", CallingConvention = CallingConvention.Cdecl)]

        public static extern int avRecvFrameData2(int nAVChannelID, ref byte abFrameData, int nFrameDataMaxSize, ref int pnActualFrameSize, ref int pnExpectedFrameSize, ref byte abFrameInfo, int nFrameInfoMaxSize, ref int pnActualFrameInfoSize, ref uint pnFrameIdx);

        [DllImport("AVApis.dll", EntryPoint = "avRecvFrameData", CallingConvention = CallingConvention.Cdecl)]
        
        public static extern int avRecvFrameData(int nAVChannelID, ref byte abFrameData, int nFrameDataMaxSize, ref byte abFrameInfo, int nFrameInfoMaxSize, ref uint pnFrameIdx);


        [DllImport("AVApis.dll", EntryPoint = "avClientStop", CallingConvention = CallingConvention.Cdecl)]
        
        public static extern void avClientStop(int nAVChannelID);

        [DllImport("AVApis.dll", EntryPoint = "avGetAVApiVer", CallingConvention = CallingConvention.Cdecl)]
        
        public static extern int avGetAVApiVer();


        [DllImport("AVApis.dll", EntryPoint = "avSendIOCtrl", CallingConvention = CallingConvention.Cdecl)]
        
        public static extern int avSendIOCtrl(int nAVChannelID, int IOCtrlType, IntPtr cabIOCtrlData, int IOCtrlDataSize);



    }
}
