/*    此篇代码由温西铭完成     */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace myHomework
{
    public partial class frmChangePwd : Form
    {
        public frmChangePwd()
        {
            InitializeComponent();
        }

        private void buttonOut_Click(object sender, EventArgs e)
        {


            OleDbConnection con;
            string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
            con = new OleDbConnection(constr);
            con.Open();
            //string cstr = "select * from 登录 where 用户名='" + tBID.Text.Trim() + "'and 密码=" + tBPassword.Text.Trim()
            string cstr = "select * from 登录 where 用户名='"+frmIn.Num+"'and 密码="+tBOldPwd.Text.Trim();
            OleDbCommand comm = new OleDbCommand(cstr, con);
            OleDbDataReader dr = comm.ExecuteReader();
            if (dr.Read())
            {
                Form4 fn = new Form4();
                fn.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("密码输入错误请查证！");
                tBOldPwd.Clear();
                
            }









        }

        private void tBOldPwd_TextChanged(object sender, EventArgs e)
        {
            int tmp;
            if (tBOldPwd.Text != "")
            {
                if (!int.TryParse(tBOldPwd.Text, out tmp))
                {
                    MessageBox.Show("密码必须是数字！");
                    tBOldPwd.Clear();
                }
            }
        }
    }
}
