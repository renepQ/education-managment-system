/*    学生选课部分由温西铭完成，其余部分由邹俊完成     */
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
    public partial class frmstudent : Form
    {
        
        public frmstudent()
        {   
            InitializeComponent();
        }
        DataSet myds;
        OleDbConnection con;

        //选课部分
        
        private void buttonSerch_Click(object sender, EventArgs e)
        {
            string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
            con = new OleDbConnection(constr);
            if (comboBox1.Text == "  —请选择—" && comboBox2.Text == "  —请选择—")
            {
                MessageBox.Show("请输入查询条件！");
            }
            else if (comboBox1.Text == "  —请选择—" && comboBox2.Text != "  —请选择—")
            {
                string sql = "select 课程编号,课程名称,教师姓名,学分 from 课程,教师 where 课程.教师编号=教师.教师编号 and 教师姓名='" + comboBox2.Text + "'";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(sql, con);
                myds = new DataSet();
                myada1.Fill(myds);
                dataGridView1.DataSource = myds.Tables[0];
            }
            else if (comboBox2.Text == "  —请选择—" && comboBox1.Text != "  —请选择—")
            {
                string sql = "select 课程编号,课程名称,教师姓名,学分 from 课程,教师 where 课程.教师编号=教师.教师编号 and 课程名称='" + comboBox1.Text + "'";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(sql, con);
                myds = new DataSet();
                myada1.Fill(myds);
                dataGridView1.DataSource = myds.Tables[0];
            }
            else
            {
                string sql = "select 课程编号,课程名称,教师姓名,学分 from 课程,教师 where 课程.教师编号=教师.教师编号 and 课程名称='" + comboBox1.Text + "' and 教师姓名='" + comboBox2.Text + "'";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(sql, con);
                myds = new DataSet();
                myada1.Fill(myds);
                dataGridView1.DataSource = myds.Tables[0];
            }

            string SQL2 = "select 课程编号 from 成绩 where 学号='" + frmIn.Num+"'"; 
            DataSet myds2 = new DataSet();
            OleDbDataAdapter adper2 = new OleDbDataAdapter(SQL2, con);
            adper2.Fill(myds2);
            for (int i = 0; i < myds.Tables[0].Rows.Count; i++)
            {
                for (int j = 0; j < myds2.Tables[0].Rows.Count; j++)
                    if (myds.Tables[0].Rows[i][0].ToString() == myds2.Tables[0].Rows[j][0].ToString())
                    {
                        dataGridView1.Rows[i].Cells[0].ReadOnly = true;
                        dataGridView1.Rows[i].Cells[0].Value = true;
                    }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            refresh();
        }

        
        void refresh()
        {
            string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
            con = new OleDbConnection(constr);
            string SQL = "select 课程编号,课程名称,教师姓名,学分 from 课程,教师 where 课程.教师编号=教师.教师编号";
            myds = new DataSet();
            OleDbDataAdapter adper = new OleDbDataAdapter(SQL, con);
            adper.Fill(myds);
            dataGridView1.DataSource = myds.Tables[0];
            string SQL2 = "select 课程编号 from 成绩 where 学号='"+frmIn.Num+"'";
            DataSet myds2 = new DataSet();
            OleDbDataAdapter adper2 = new OleDbDataAdapter(SQL2, con);
            adper2.Fill(myds2);
            for (int j = 0; j < myds2.Tables[0].Rows.Count; j++)
            {
                for (int i = 0; i < myds.Tables[0].Rows.Count; i++)
                    if (myds.Tables[0].Rows[i][0].ToString() == myds2.Tables[0].Rows[j][0].ToString())
                    {
                        dataGridView1.Rows[i].Cells[0].ReadOnly = true;
                        dataGridView1.Rows[i].Cells[0].Value = true;
                    }
            }


        }
        private void button2_Click(object sender, EventArgs e)
        {
            int j = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if ((bool)dataGridView1.Rows[i].Cells[0].EditedFormattedValue == true && dataGridView1.Rows[i].Cells[0].ReadOnly == false)
                    j++;
            }
            if (j == 0)
            {
                MessageBox.Show("请选择课程！");
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if ((bool)dataGridView1.Rows[i].Cells[0].EditedFormattedValue == true && dataGridView1.Rows[i].Cells[0].ReadOnly == false)
                    {
                        string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
                        string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;

                        OleDbConnection con = new OleDbConnection(constr);
                        con.Open();
                        string strselect = "select 教师编号 from 教师 where 教师姓名='" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "'";
                        OleDbCommand inst = new OleDbCommand(strselect, con);
                        string num = inst.ExecuteScalar().ToString();
                        string strInsert = " INSERT INTO 成绩(学号,课程编号) values ('"+frmIn.Num+"','" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "')";
                        inst = new OleDbCommand(strInsert, con);
                        inst.ExecuteNonQuery();

                    }

                }
                MessageBox.Show("选课成功！");
                refresh();
            }


        }
        //查询教师
        //这里get到combobox的text进行查询
        private void btnChkTch_Click(object sender, EventArgs e)
        {
            string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
            OleDbConnection con = new OleDbConnection(constr);
            string mysql = "select 教师姓名,性别,联系方式 from 教师 where 教师姓名='" + cbTchName.Text + "'";
            OleDbDataAdapter adpter = new OleDbDataAdapter(mysql, con);
            DataSet myds = new DataSet();
            adpter.Fill(myds);
            dataGridViewChkTch.DataSource = myds.Tables[0];

        }

        private void tcStudent_Selected(object sender, TabControlEventArgs e)
        {
            // 查询教师
            if (e.TabPage == tbCheckTch) 
            {
                OleDbConnection mycon;
                string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
                string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
                mycon = new OleDbConnection(constr);
                string mysql = "select 教师姓名 from 教师 ";
                OleDbCommand mycom = new OleDbCommand(mysql, mycon);
                mycon.Open();
                OleDbDataReader myreader = mycom.ExecuteReader();
                cbTchName.Items.Clear();
                while (myreader.Read())
                {
                    cbTchName.Items.Add(myreader[0].ToString());
                }
                myreader.Close();
                myreader.Dispose();

            }
         //已选课程删除



            if (e.TabPage == tbCheckScrCrs) 
            {
                DataSet myds;
                OleDbConnection con;
                OleDbDataAdapter myada1;
                string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
                string constr = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" + mypath;
                con = new OleDbConnection(constr);
                string mysql = "select 成绩.课程编号,课程.教师编号,教师.教师姓名,课程.课程名称,成绩.分数 from 课程,成绩,教师 where 成绩.课程编号=课程.课程编号 and 课程.教师编号=教师.教师编号 and 成绩.学号='" + frmIn.Num + "'and 是否评分=0";
                myada1 = new OleDbDataAdapter(mysql, con);
                myds = new DataSet();
                myada1.Fill(myds);
                dataGridViewChkCrsScr.DataSource = myds.Tables[0].DefaultView;
                con.Close();
            }
            if (e.TabPage == tbChooseScr)
            {
                string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
                string constr = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" + mypath;
                con = new OleDbConnection(constr);
                string SQL2 = "select 课程编号 from 成绩 where 学号='" + frmIn.Num+"'";
                DataSet myds2 = new DataSet();
                OleDbDataAdapter adper2 = new OleDbDataAdapter(SQL2, con);
                adper2.Fill(myds2);
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < myds2.Tables[0].Rows.Count; j++)
                    {

                        if (dataGridView1.Rows[i].Cells[1].ToString() == myds2.Tables[0].Rows[j][0].ToString())
                        {
                            dataGridView1.Rows[i].Cells[0].ReadOnly = true;
                            dataGridView1.Rows[i].Cells[0].Value = true;
                            break;
                        }
                    }
                }
                refresh();
                
                string SQL = "select 课程名称 from 课程";
                OleDbCommand mycom = new OleDbCommand(SQL, con);
                con.Open();
                comboBox1.Items.Clear();
                OleDbDataReader myreader = mycom.ExecuteReader();
                while (myreader.Read())
                {
                    comboBox1.Items.Add(myreader[0].ToString());
                }
                comboBox1.Items.Add("  —请选择—");
                SQL = "select 教师姓名 from 教师";
                mycom = new OleDbCommand(SQL, con);
                comboBox2.Items.Clear();
                myreader = mycom.ExecuteReader();
                while (myreader.Read())
                {
                    comboBox2.Items.Add(myreader[0].ToString());
                }
                myreader.Close();
                myreader.Dispose();
                comboBox2.Items.Add("  —请选择—");
                 
            }
            if (e.TabPage == tbStudent)
            {
                OleDbConnection con;
                OleDbDataAdapter myada1;
                string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
                string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
                con = new OleDbConnection(constr);
                string strSle = "select 学生姓名,班级,专业,联系方式,民族,出生年月 from 学生 where 学号='"+frmIn.Num+"'";
                myada1 = new OleDbDataAdapter(strSle, con);
                myds = new DataSet();
                myada1.Fill(myds);
                textBox7.Text = myds.Tables[0].Rows[0]["学生姓名"].ToString();
                textBox3.Text = myds.Tables[0].Rows[0]["班级"].ToString();
                textBox4.Text = myds.Tables[0].Rows[0]["专业"].ToString();
                textBox8.Text = myds.Tables[0].Rows[0]["民族"].ToString();
                textBox9.Text = myds.Tables[0].Rows[0]["出生年月"].ToString();
                textBox5.Text = myds.Tables[0].Rows[0]["联系方式"].ToString();
                textBox6.Text = frmIn.Num;
            }
            // 已通过和未通过
            if (e.TabPage == tbCheckScr)
            {
                OleDbConnection con;
                OleDbDataAdapter myada1,myada2;
                string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
                string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
                con = new OleDbConnection(constr);
                con.Open();
                string SrcOK = "select 成绩.课程编号,课程.课程名称,课程.教师编号,教师.教师姓名,成绩.分数 from 成绩,课程,教师 where 成绩.学号='" + frmIn.Num + "' and 成绩.分数>=60 and 成绩.课程编号=课程.课程编号 and 课程.教师编号=教师.教师编号";
                string SrcNO = "select 成绩.课程编号,课程.课程名称,课程.教师编号,教师.教师姓名,成绩.分数 from 成绩,课程,教师 where 成绩.学号='" + frmIn.Num + "' and 成绩.分数<60 and 成绩.课程编号=课程.课程编号 and 课程.教师编号=教师.教师编号";
                string SrcAll = "select 课程.学分 from 成绩,课程 where 成绩.学号='" + frmIn.Num + "' and 成绩.分数>=60 and 成绩.课程编号=课程.课程编号 ";
                myada1 = new OleDbDataAdapter(SrcOK, con);
                myada2 = new OleDbDataAdapter(SrcNO, con);
                OleDbCommand getValueCom=new OleDbCommand(SrcAll,con);
                OleDbDataReader getValueReader=getValueCom.ExecuteReader();
                int score = 0;
                while (getValueReader.Read())
                {
                    string ui = getValueReader[0].ToString();
                    int i = Convert.ToInt32(ui);
                    score = score + i;
                }
                label16.Text = "通过课程总学分：" + score;
                myds = new DataSet();
                DataSet myds2 = new DataSet();
                DataSet myds3 = new DataSet();
                myada1.Fill(myds);
                myada2.Fill(myds2);
                dataGridView2.DataSource = myds.Tables[0].DefaultView;
                dataGridView3.DataSource = myds2.Tables[0].DefaultView;
                con.Close();
            }

        }

        private void dataGridViewChkCrsScr_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = dataGridViewChkCrsScr.CurrentRow.Index;
            textBox1.Text = dataGridViewChkCrsScr.Rows[a].Cells["课程编号"].Value.ToString();
            textBox2.Text = dataGridViewChkCrsScr.Rows[a].Cells["课程名称"].Value.ToString();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DataSet myds;
            OleDbDataAdapter myada1;
            string strDelete = "DELETE FROM 成绩 WHERE 课程编号='" + textBox1.Text + "'and 学号='" + frmIn.Num+"'";
            string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;

            OleDbConnection con = new OleDbConnection(constr);
            con.Open();
            OleDbCommand inst = new OleDbCommand(strDelete, con);
            inst.ExecuteNonQuery();
            string mysql = "select 成绩.课程编号,课程.教师编号,课程.课程名称,教师.教师姓名 from 课程,成绩,教师 where 成绩.课程编号=课程.课程编号 and 成绩.学号='" + frmIn.Num+"'";
            myada1 = new OleDbDataAdapter(mysql, con);
            myds = new DataSet();
            myada1.Fill(myds);
            dataGridViewChkTch.DataSource = myds.Tables[0].DefaultView;
            con.Close();
        }

        private void frmstudent_Load(object sender, EventArgs e)
        {
            OleDbConnection con;
            OleDbDataAdapter myada1;
            string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
            con = new OleDbConnection(constr);
            string strSle = "select 学生姓名,班级,专业,联系方式,民族,出生年月 from 学生 where 学号='" + frmIn.Num + "'";
            myada1 = new OleDbDataAdapter(strSle, con);
            DataSet myds = new DataSet();
            myada1.Fill(myds);
            textBox7.Text = myds.Tables[0].Rows[0]["学生姓名"].ToString();
            textBox3.Text = myds.Tables[0].Rows[0]["班级"].ToString();
            textBox4.Text = myds.Tables[0].Rows[0]["专业"].ToString();
            textBox8.Text = myds.Tables[0].Rows[0]["民族"].ToString();
            textBox9.Text = myds.Tables[0].Rows[0]["出生年月"].ToString();
            textBox5.Text = myds.Tables[0].Rows[0]["联系方式"].ToString();
            textBox6.Text = frmIn.Num;
            //load
            string SQL = "select 课程编号,课程名称,教师姓名,学分 from 课程,教师 where 课程.教师编号=教师.教师编号";
             myds = new DataSet();
            OleDbDataAdapter adper = new OleDbDataAdapter(SQL, con);
            adper.Fill(myds);
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = myds.Tables[0];
            string SQL2 = "select 课程编号 from 成绩 where 学号='" + frmIn.Num + "'";
            DataSet myds2 = new DataSet();
            OleDbDataAdapter adper2 = new OleDbDataAdapter(SQL2, con);
            adper2.Fill(myds2);
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < myds2.Tables[0].Rows.Count; j++)
                {

                    if (dataGridView1.Rows[i].Cells[1].ToString() == myds2.Tables[0].Rows[j][0].ToString())
                    {
                        dataGridView1.Rows[i].Cells[0].ReadOnly = true;
                        dataGridView1.Rows[i].Cells[0].Value = true;
                        break;
                    }
                }
            }
            refresh();

             SQL = "select 课程名称 from 课程";
            OleDbCommand mycom = new OleDbCommand(SQL, con);
            con.Open();
            comboBox1.Items.Clear();
            OleDbDataReader myreader = mycom.ExecuteReader();
            while (myreader.Read())
            {
                comboBox1.Items.Add(myreader[0].ToString());
            }
            comboBox1.Items.Add("  —请选择—");
            SQL = "select 教师姓名 from 教师";
            mycom = new OleDbCommand(SQL, con);
            comboBox2.Items.Clear();
            myreader = mycom.ExecuteReader();
            while (myreader.Read())
            {
                comboBox2.Items.Add(myreader[0].ToString());
            }
            myreader.Close();
            myreader.Dispose();
            comboBox2.Items.Add("  —请选择—");


        }

     //修改密码

        private void button3_Click(object sender, EventArgs e)
        {
            frmChangePwd pwc = new frmChangePwd();
            pwc.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.Close();
            frmIn welcome = new frmIn();
            welcome.Show();
        }

        

        

        

       

        

        


      
    }
}
