/*    此篇代码由郭天乐完成     */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace myHomework
{
    public partial class updatetea : Form
    {
        public updatetea()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
            OleDbConnection  con = new OleDbConnection(constr);
            String strUpdate = "UPDATE 教师 SET 教师姓名='";
            strUpdate += textBox8.Text + "',性别='";
            strUpdate += textBox3.Text + "',联系方式='";
            strUpdate += textBox2.Text + "',出生年月='";
            strUpdate += riqit.Value.ToString("yy-MM-dd") + "' WHERE 教师编号='";
            strUpdate += textBox7.Text+"'";
            con.Open();
            OleDbCommand inst = new OleDbCommand(strUpdate, con);
            inst.ExecuteNonQuery();
            inst.ExecuteNonQuery();
            MessageBox.Show("修改成功！");
            this.Close();
        }
    }
}
