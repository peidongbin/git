using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monitorsever
{
    public struct uidstate
    {
        public string uid;
        public bool connected;
        public int session;
        public int avindex;

    }

    class buildlist
    {

        static private volatile List<uidstate> uidlist = new List<uidstate>();
        public static int adduid(string uidstring,int uidsession,int avindex)
        {
            int n = uidlist.Count;
            if (n > 0)
            {
                int i;
                for (i = 0; i <= n; i++)
                {
                    if (uidlist[i].uid == uidstring) { uidlist.Remove(uidlist[i]); break; }

                }
            }
            uidstate statetemp=new uidstate();
            statetemp.uid = uidstring;
            statetemp.session = uidsession;
            statetemp.connected = true;
            statetemp.avindex = avindex;
            uidlist.Add(statetemp);
           
            return 1;
        }
 
  
        public static int getsession(string uidstring)
        {
            foreach (uidstate s1 in uidlist)
            {
                if (s1.uid == uidstring)
                {
                    return s1.session;
                }
            }
            return -1;
        }
        public static int getavindex(string uidstring)
        {
            foreach (uidstate s1 in uidlist)
            {
                if (s1.uid == uidstring)
                {
                    return s1.avindex;
                }
            }
            return -1;
        }

        
    }
}
