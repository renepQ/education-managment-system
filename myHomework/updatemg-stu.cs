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
    public partial class Form1 : Form
    { 
       
        
        public Form1()
        {
            InitializeComponent();
        }

        private void tbStu5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        OleDbConnection con;
        private void 确定_Click(object sender, EventArgs e)
        {
            string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
            con = new OleDbConnection(constr);
            string strUpdate = "UPDATE 学生 SET 学生姓名='";
            strUpdate += tbStu2.Text + "',班级='";
            strUpdate += tbStu3.Text + "',联系方式='";
            strUpdate += tbStu4.Text + "',民族='";
            strUpdate += tbStu7.Text + "',出生年月='";
            strUpdate += riqi.Value.Date.ToString("yy-MM-dd") + "' WHERE 学号='";
            strUpdate += tbStu1.Text + "'";
            con.Open();
            OleDbCommand inst = new OleDbCommand(strUpdate, con);
            inst.ExecuteNonQuery();
            MessageBox.Show("修改成功！");
            this.Close();
            

        }
    }
}
