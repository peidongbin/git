//连接数据库


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;



namespace Monitorclient.CommonClass
{
    class DataCon
    {
        public  OleDbConnection getCon()
        {
            string strDPath = Application.StartupPath;
            string strDataSource = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
                + strDPath.Substring(0, strDPath.LastIndexOf("\\")).Substring(0, strDPath.Substring(0, strDPath.LastIndexOf("\\")).LastIndexOf("\\")) + "\\db\\monitor.mdb";
            OleDbConnection oledbCon = new OleDbConnection(strDataSource);
            return oledbCon;
        }
    }
}
