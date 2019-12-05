/*     此篇代码由汪嘉宝完成     */
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
    public partial class frmTeacher : Form
    {
        public frmTeacher()
        {
            InitializeComponent();
        }

        private void tbCheckInput_Click(object sender, EventArgs e)
        {

        }

        private void tbTeacher_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmTeacher_Load(object sender, EventArgs e)
        {
            OleDbConnection con;
            OleDbDataAdapter myada1;
            string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
            con = new OleDbConnection(constr);
            string strSle = "select 教师姓名,性别,联系方式,出生年月 from 教师 where 教师编号='" + frmIn.Num + "'";
            myada1 = new OleDbDataAdapter(strSle, con);
            DataSet myds = new DataSet();
            myada1.Fill(myds);
            label17.Text=textBox2.Text = myds.Tables[0].Rows[0]["教师姓名"].ToString();
            textBox3.Text = myds.Tables[0].Rows[0]["性别"].ToString();
            textBox4.Text = myds.Tables[0].Rows[0]["出生年月"].ToString();
            textBox5.Text = myds.Tables[0].Rows[0]["联系方式"].ToString();
            textBox1.Text = frmIn.Num;

        }

        private void tcTeacher_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == tbTeacher)
            {
                OleDbConnection con;
                OleDbDataAdapter myada1;
                string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
                string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
                con = new OleDbConnection(constr);
                string strSle = "select 教师姓名,性别,联系方式,出生年月 from 教师 where 教师编号='" + frmIn.Num + "'";
                myada1 = new OleDbDataAdapter(strSle, con);
                DataSet myds = new DataSet();
                myada1.Fill(myds);
                textBox2.Text = myds.Tables[0].Rows[0]["教师姓名"].ToString();
                textBox3.Text = myds.Tables[0].Rows[0]["性别"].ToString();
                textBox4.Text = myds.Tables[0].Rows[0]["出生年月"].ToString();
                textBox5.Text = myds.Tables[0].Rows[0]["联系方式"].ToString();
                textBox1.Text = frmIn.Num;

            }
            if (e.TabPage == tbCheckInput)
            {
                cbName.Items.Clear();
                OleDbConnection con;
                OleDbDataAdapter myada1;
                string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
                string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
                con = new OleDbConnection(constr);
                string strSle = "select 课程名称 from 课程 where 教师编号='" + frmIn.Num + "'";
                OleDbCommand cmd = new OleDbCommand(strSle, con);
                con.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cbName.Items.Add(reader[0]);
                }

            }
        }
        public string b = "";
        private void cbName_TextChanged(object sender, EventArgs e)
        {
            OleDbConnection con;
            OleDbDataAdapter myada1;
            string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
            con = new OleDbConnection(constr);
            string strSle = "select 课程编号 from 课程 where 课程名称='" + cbName.Text.ToString() + "' and 教师编号='" + frmIn.Num + "'";
            OleDbCommand cmd = new OleDbCommand(strSle, con);
            con.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                b = reader[0].ToString();
            }

            strSle = "select 成绩.课程编号,课程名称,成绩.学号,学生姓名,分数  from 成绩,课程,学生 where 成绩.课程编号='" + b + "' and 成绩.课程编号=课程.课程编号 and 成绩.学号=学生.学号";
            myada1 = new OleDbDataAdapter(strSle, con);
            DataSet myds = new DataSet();
            myada1.Fill(myds);
            dataGridViewScr.DataSource = myds.Tables[0];
            strSle = "select 成绩.学号 from 成绩 where 课程编号='" + b + "'";
            cmd = new OleDbCommand(strSle, con);
            reader = cmd.ExecuteReader();
            comboBox1.Items.Clear();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader[0]);
            }

        }
     
        private void dataGridViewScr_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string a = dataGridViewScr.CurrentRow.Cells["学号"].Value.ToString();
            OleDbConnection con;
            OleDbDataAdapter myada1;
            string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
            con = new OleDbConnection(constr);
            string strSle = "select 学生姓名,班级,专业,联系方式,民族,出生年月 from 学生 where 学号='" + a + "'";
            myada1 = new OleDbDataAdapter(strSle, con);
            DataSet myds = new DataSet();
            myada1.Fill(myds);
            textBox7.Text = myds.Tables[0].Rows[0]["学生姓名"].ToString();
            textBox10.Text = myds.Tables[0].Rows[0]["班级"].ToString();
            textBox8.Text = myds.Tables[0].Rows[0]["民族"].ToString();
            textBox9.Text = myds.Tables[0].Rows[0]["专业"].ToString();
            textBox11.Text = myds.Tables[0].Rows[0]["联系方式"].ToString();
            comboBox1.Text = a;
            textBox12.Text = myds.Tables[0].Rows[0]["学生姓名"].ToString();
            textBox6.Text = a;
            strSle = "select 分数 from 成绩 where 学号='" + a + "' and 课程编号='" + b + "'";
            con.Open();
            OleDbCommand cmd = new OleDbCommand(strSle, con);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                tbInputScr.Text = reader[0].ToString();
            }
           

        }
        int JIAOSHI;
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                 JIAOSHI= Convert.ToInt32(tbInputScr.Text);
            }catch(Exception ex)
            {
                MessageBox.Show("请输入0——100之间数字！");
                tbInputScr.Clear();
                return;
            }
            if (JIAOSHI > 100 || JIAOSHI < 0)
            {
                MessageBox.Show("请输入0——100之间的数！");
                return;
            }
            bool result = false;
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                if (comboBox1.Items[i].ToString() == comboBox1.Text)
                {
                    result = true;
                    break;
                }
            }
            if (result == false)
            {
                MessageBox.Show("该学生不存在!");
                return;
            }
            OleDbConnection con;
            OleDbDataAdapter myada1;
            string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
            con = new OleDbConnection(constr);
            con.Open();
            string sql2 = "update 成绩 set 分数=" + tbInputScr.Text + ",是否评分=1 where 学号='" + comboBox1.Text + "' and 课程编号='" + b + "'";
            OleDbCommand cmd = new OleDbCommand(sql2, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("添加或修改成功！");
            string strSle = "select 成绩.课程编号,课程名称,成绩.学号,学生姓名,分数  from 成绩,课程,学生 where 成绩.课程编号='" + b + "' and 成绩.课程编号=课程.课程编号 and 成绩.学号=学生.学号";
            myada1 = new OleDbDataAdapter(strSle, con);
            DataSet myds = new DataSet();
            myada1.Fill(myds);
            dataGridViewScr.DataSource = myds.Tables[0];
        }

        private void comboBox1_TextChanged_1(object sender, EventArgs e)
        {
            OleDbConnection con;
            OleDbDataAdapter myada1;
            string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
            con = new OleDbConnection(constr);
            con.Open();
            string sql = "select 学生姓名 from 学生 where 学号='" + comboBox1.Text + "'";
            OleDbCommand cmd = new OleDbCommand(sql, con);
            OleDbDataReader reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                
                textBox12.Text = reader[0].ToString();
            }
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmChangePwd pwc = new frmChangePwd();
            pwc.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Close();
            frmIn welcome = new frmIn();
            welcome.Show();
        }

        


    }
}