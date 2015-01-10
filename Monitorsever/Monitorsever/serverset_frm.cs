using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Monitorsever.CommonClass;
using System.Data.OleDb;
using System.IO;    
namespace Monitorsever
{
    public partial class serverset_frm : Form
    {
        DataCon datacon = new DataCon();
        DataOperate dataoperate = new DataOperate();
        public serverset_frm()
        {
            InitializeComponent();
        }

        private void serverset_frm_Load(object sender, EventArgs e)
        {
            string get_setting = "SELECT  path FROM setting ";
            DataSet setting = dataoperate.getDs(get_setting, "setting");
            text_path.Text = setting.Tables[0].Rows[0][0].ToString();
            textBox1.Text = "当前视频总大小"+GetDirectoryLength(text_path.Text)+"KB";

        }

        private void button1_Click(object sender, EventArgs e)
        {
      
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            
            if (ofd.ShowDialog() == DialogResult.OK)
            {

                text_path.Text = ofd.SelectedPath;
            }
        }

        private void but_save_Click(object sender, EventArgs e)
        {
            string save_setting = "update setting set  path='"+ text_path.Text+"' where id=1";

            DataSet Save = dataoperate.getDs(save_setting, "setting");
            this.Close();
        }

        private void text_path_TextChanged(object sender, EventArgs e)
        {

        }
        public static long GetDirectoryLength(string dirPath)
        {
         
            if (!Directory.Exists(dirPath))
                return 0;
            long len = 0;

            //定义一个DirectoryInfo对象
            DirectoryInfo di = new DirectoryInfo(dirPath);

            //通过GetFiles方法,获取di目录中的所有文件的大小
            foreach (FileInfo fi in di.GetFiles())
            {
                len += fi.Length;
            }

            //获取di中所有的文件夹,并存到一个新的对象数组中,以进行递归
            DirectoryInfo[] dis = di.GetDirectories();
            if (dis.Length > 0)
            {
                for (int i = 0; i < dis.Length; i++)
                {
                    len += GetDirectoryLength(dis[i].FullName);
                }
            }
            return len;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
      
    }
}
