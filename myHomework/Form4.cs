/*     此篇代码由温西铭完成     */
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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            if (tBNewPwd1.Text == "" )
            {
                MessageBox.Show("密码不允许为空");
            }
            if (tBNewPwd2.Text == "" && tBNewPwd1.Text != "")
            {
                MessageBox.Show("请再次确认密码！");
            }
            else{

            if (tBNewPwd1.Text!= tBNewPwd2.Text)
                MessageBox.Show("两次密码不一致，请确认！");
            else
            {
                OleDbConnection con;
               string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
                string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
                con = new OleDbConnection(constr);
              con.Open();
                OleDbCommand com = new OleDbCommand("update 登录 set 密码=" + tBNewPwd2.Text.Trim() + " where 用户名='" + frmIn.Num + "'", con);
                com.ExecuteNonQuery();
                    MessageBox.Show("密码修改成功");
                    this.Close(); 
               
                con.Close();
                con.Dispose();
            }
            
        }

        }

        private void tBNewPwd1_TextChanged(object sender, EventArgs e)
        {
            int tmp;
            if (tBNewPwd1.Text != "")
            {
                if (!int.TryParse(tBNewPwd1.Text, out tmp))
                {
                    MessageBox.Show("密码必须是数字！");
                    tBNewPwd1.Clear();
                }
            }
        }

        
            }
        }

       
    


