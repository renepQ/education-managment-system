/*   此篇代码为温西铭、邹俊合作完成    */
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
   
    public partial class frmIn : Form
    {
        frmstudent stu;
        frmManager mge;
        frmTeacher tea;
        static public string Num;
        
        public frmIn()
        {
            InitializeComponent();
        }


        private void buttonIn_Click(object sender, EventArgs e)
        {

            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\DatabaseC#.accdb";
            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();
            if (tBID.Text == "" && tBPassword.Text != "")
                MessageBox.Show("请输入用户名");
            if (tBPassword.Text == "" && tBID.Text != "")
                MessageBox.Show("请输入密码");
            if (tBID.Text == "" && tBPassword.Text == "")
                MessageBox.Show("请输入用户名和密码");
            else
            {
                if (rBStu.Checked == false && rBMG.Checked == false && rBTch.Checked == false)
                    MessageBox.Show("请选择登录身份");
                else
                {

                    if (rBStu.Checked == true)
                    {
                        string cstr = "select * from 登录 where 用户名='" + tBID.Text.Trim() + "'and 密码=" + tBPassword.Text.Trim()+"and 属性=1";
                        OleDbCommand comm = new OleDbCommand(cstr, conn);
                        OleDbDataReader dr = comm.ExecuteReader();
                        if (dr.Read())
                        {
                            Num = tBID.Text.Trim();
                            this.Hide();
                            stu = new frmstudent();
                            string SQL = "select 课程编号,课程名称,教师姓名,学分 from 课程,教师 where 课程.教师编号=教师.教师编号";
                            DataSet myds = new DataSet();
                            OleDbDataAdapter adper = new OleDbDataAdapter(SQL, conn);
                            adper.Fill(myds);
                            stu.dataGridView1.AllowUserToAddRows = false;
                            stu.dataGridView1.DataSource = myds.Tables[0];
                            stu.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("用户名或密码输入错误，请重新输入！");
                            tBID.Text = "";
                            tBPassword.Text = "";
                        }
                    }
                    if (rBMG.Checked == true)
                    {
                        string cstr = "select * from 登录 where 用户名='" + tBID.Text.Trim() + "'and 密码=" + tBPassword.Text.Trim()+"and 属性=3";
                        OleDbCommand comm = new OleDbCommand(cstr, conn);
                        OleDbDataReader dr = comm.ExecuteReader();
                        if (dr.Read())
                        {
                            Num = tBID.Text.Trim();
                            this.Hide();
                            mge = new frmManager();
                            string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
                            constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
                            OleDbConnection con = new OleDbConnection(constr);
                            string mysql = "select 学号,学生姓名,班级,联系方式,密码,民族,出生年月 from 学生,登录 where 学生.学号=登录.用户名";
                            OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
                            DataSet myds = new DataSet();
                            myada1.Fill(myds);
                            mge.dataGridViewStu.DataSource = myds.Tables[0].DefaultView;
                            mge.ShowDialog();
                            
                        }
                        else
                        {
                            MessageBox.Show("用户名或密码输入错误，请重新输入！");
                            tBID.Text = "";
                            tBPassword.Text = "";
                        }
                    }
                    if (rBTch.Checked == true)
                    {
                        string cstr = "select * from 登录 where 用户名='" + tBID.Text.Trim() + "'and 密码=" + tBPassword.Text.Trim() + "and 属性=2";
                        OleDbCommand comm = new OleDbCommand(cstr, conn);
                        OleDbDataReader dr = comm.ExecuteReader();
                        if (dr.Read())
                        {
                            Num = tBID.Text.Trim();
                            this.Hide();
                            tea = new frmTeacher();
                            tea.ShowDialog();
                            
                        }
                        else
                        {
                            MessageBox.Show("用户名或密码输入错误，请重新输入！");
                            tBID.Text = "";
                            tBPassword.Text = "";
                        }
                    }
                     
                }
            }
        }

        private void frmIn_Load(object sender, EventArgs e)
        {

        }

        private void rBMG_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tBPassword_TextChanged(object sender, EventArgs e)
        {
            int tmp;
            if(tBPassword.Text!="")
            {
            if (!int.TryParse(tBPassword.Text, out tmp))
            {
                MessageBox.Show("密码必须是数字！");
                tBPassword.Clear();
            }
            }
        }

        
       
    }
}
