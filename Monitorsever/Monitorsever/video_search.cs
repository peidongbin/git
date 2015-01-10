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
    public partial class video_search : Form
    {
        DataCon datacon = new DataCon();
        DataOperate dataoperate = new DataOperate();
        public video_search()
        {
            InitializeComponent();
        }

        private void video_search_Load(object sender, EventArgs e)
        {
            string getlist = "SELECT  id,userid,videoname,camid,begintime,endtime,path FROM video order by id desc";
            DataSet videolist = dataoperate.getDs(getlist, "video");
            video.DataSource = videolist.Tables[0];

            video.Columns[0].HeaderText = "序号";
            video.Columns[0].Width = 40;
            video.Columns[1].HeaderText = "分院编号";
            video.Columns[1].Width = 80;
            video.Columns[2].HeaderText = "病人编号";
            video.Columns[2].Width = 100;
            video.Columns[3].HeaderText = "摄像头编号";
            video.Columns[3].Width = 120;
            video.Columns[4].HeaderText = "开始时间";
            video.Columns[4].Width = 120;
            video.Columns[5].HeaderText = "结束时间";
            video.Columns[5].Width = 120;
            video.Columns[6].HeaderText = "视频路径";
            video.Columns[6].Width = 140;
            video.AutoGenerateColumns = false;
            DataGridViewButtonColumn dbtEdit = new DataGridViewButtonColumn();
            dbtEdit.Text = "查看";//添加的这列的显示文字，即每行最后一列显示的文字。
            dbtEdit.Name = "buttonEdit";
            dbtEdit.HeaderText = "查看";//列的标题
            dbtEdit.UseColumnTextForButtonValue = true;//上面设置的dlink.Text文字在列中显示
            dbtEdit.Width = 40;
            video.Columns.Add(dbtEdit);//将创建的列添加到UserdataGridView中
            DataGridViewButtonColumn del = new DataGridViewButtonColumn();
            del.Text = "删除";//添加的这列的显示文字，即每行最后一列显示的文字。
            del.Name = "del";
            del.HeaderText = "删除";//列的标题
            del.UseColumnTextForButtonValue = true;//上面设置的dlink.Text文字在列中显示
            del.Width = 40;
            video.Columns.Add(del);//将创建的列添加到UserdataGridView中
            int i = video.RowCount;
            textBox1.Text = "共有" + i + "条记录";

        }

        private void userid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void video_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (video.RowCount > 0)
            {
            if (video.Columns[e.ColumnIndex].Name == "buttonEdit")
            {
                
                    

                    try
                    {
                        string pathtmp = video.Rows[e.RowIndex].Cells[6].Value.ToString();
                        System.Diagnostics.Process.Start(pathtmp);
                    }
                    catch (Exception e1) { MessageBox.Show("找不到此文件，可能已经删除"); }
                    //try   若找不到文件
                }
                if (video.Columns[e.ColumnIndex].Name == "del")
                {
                    string pathtmp1 = video.Rows[e.RowIndex].Cells[6].Value.ToString();

                    
                    string videoid = video.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string delstring = "delete from video where ID=" + videoid + "";
                    try
                    {
                        DataSet videolist = dataoperate.getDs(delstring, "video");

                    }
                    catch { }

                    try
                    {
                        File.Delete(pathtmp1);
                    }
                    catch (IOException e2) { MessageBox.Show("找不到此文件，可能已经删除"); }
                }
                serch();

            }
        }
        private void search_Click(object sender, EventArgs e)
        {
            serch();
        }

        private void videoname_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void begin_dateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }
        private void serch()
        {
            string getlist;
        

            if (userid.Text == "")
            {
                getlist = "SELECT  id,userid,videoname,camid,begintime,endtime,path FROM video order by id desc";
                if (videoname.Text == "")
                {
                    if (checkBox1.Checked)
                    {
                        getlist = "SELECT  id,userid,videoname,camid,begintime,endtime,path FROM video where begintime between #" + begin_dateTimePicker.Value + "# and  #" + end_dateTimePicker.Value + "# order by id desc";
                    }
                    else
                    {
                        getlist = "SELECT  id,userid,videoname,camid,begintime,endtime,path FROM video order by id desc";
                    }
                }
                else
                {
                    if (checkBox1.Checked) { getlist = "SELECT  id,userid,videoname,camid,begintime,endtime,path FROM video where (begintime between #" + begin_dateTimePicker.Value + "# and  #" + end_dateTimePicker.Value + "#)and(videoname='" + videoname.Text + "') order by id desc"; }
                    else
                    {
                        getlist = "SELECT  id,userid,videoname,camid,begintime,endtime,path FROM video where (videoname='" + videoname.Text + "') order by id desc";
                    }
                }
            }
            else
            {
                if (videoname.Text == "")
                {
                    if (checkBox1.Checked) { getlist = "SELECT  id,userid,videoname,camid,begintime,endtime,path FROM video where (begintime between #" + begin_dateTimePicker.Value + "# and  #" + end_dateTimePicker.Value + "#)and(userid='" + userid.Text + "') order by id desc"; }
                    else
                    {
                        getlist = "SELECT  id,userid,videoname,camid,begintime,endtime,path FROM video where(userid='" + userid.Text + "') order by id desc";
                    }
                }
                else
                {
                    if (checkBox1.Checked)
                    {
                        getlist = "SELECT  id,userid,videoname,camid,begintime,endtime,path FROM video where (begintime between #" + begin_dateTimePicker.Value + "# and  #" + end_dateTimePicker.Value + "#) and(videoname='" + videoname.Text + "')and(userid='" + userid.Text + "') order by id desc";
                    }
                    else
                    {
                        getlist = "SELECT  id,userid,videoname,camid,begintime,endtime,path FROM video where(userid='" + userid.Text + "')and(videoname='" + videoname.Text + "') order by id desc";
                    }
                }
            }

            DataSet videolist = dataoperate.getDs(getlist, "video");
            video.DataSource = videolist.Tables[0];
            int i = video.RowCount;
            textBox1.Text = "共有" + i + "条记录";
        }

        private void butdel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("确认删除?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {

                for (int i = video.RowCount; i > 0; i--)
                {
                    string videoid = video.Rows[i - 1].Cells[0].Value.ToString();
                    string pathtmp1 = video.Rows[i-1].Cells[6].Value.ToString();
                    string delstring = "delete from video where ID=" + videoid + "";
                    try
                    {
                        DataSet videolist = dataoperate.getDs(delstring, "video");
                        File.Delete(pathtmp1);

                    }
                    catch { }
                }
                serch();
            }
           
        }

        private void rst_Click(object sender, EventArgs e)
        {
            userid.Text = "001";
            videoname.Text = "";
            checkBox1.Checked = false;


        }

       
    }
}
