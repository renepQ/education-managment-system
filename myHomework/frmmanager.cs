/*      此篇代码为温西铭、郭天乐合作完成     */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections;

namespace myHomework
{
    public partial class frmManager : Form
    {
        int id;
        OleDbConnection con;
        public frmManager()
        {
            InitializeComponent();
        }






        private void frmManager_Load(object sender, EventArgs e)
        {
            this.Size = new Size(650, 550);

        }



        //以下为管理学生信息的标签
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {

            //添加学生信息的页面
            if (e.TabPage == tabPage1)
            {
                riqi.CustomFormat = "yyyy-MM-dd";

                string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
                string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
                con = new OleDbConnection(constr);
                string mysql = "select 学号,学生姓名,班级,联系方式,密码,民族,出生年月 from 学生,登录 where 学生.学号=登录.用户名";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
                DataSet myds = new DataSet();
                myada1.Fill(myds);
                dataGridViewStu.DataSource = myds.Tables[0].DefaultView;
                con.Close();
            }
            //查询学生信息 页面
            if (e.TabPage == tabPage2)
            {
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();
                string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
                string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
                con = new OleDbConnection(constr);
                //学号查询
                string SQL = "select 学号 from 学生";
                OleDbCommand mycom = new OleDbCommand(SQL, con);
                con.Open();
                OleDbDataReader myreader = mycom.ExecuteReader();
                while (myreader.Read())
                {
                    comboBox1.Items.Add(myreader[0]);
                }
                comboBox1.Items.Add("输入/选择");
                // 学生姓名查询
                SQL = "select 学生姓名 from 学生";
                mycom = new OleDbCommand(SQL, con);
                myreader = mycom.ExecuteReader();
                while (myreader.Read())
                {
                    bool False = false;
                    string value = myreader[0].ToString();
                    for (int i = 0; i < comboBox2.Items.Count; i++)
                    {
                        if (comboBox2.Items[i].ToString() == value) False = true;
                    }

                    if (False == false)
                        comboBox2.Items.Add(value);

                }
                comboBox2.Items.Add("输入/选择");
                //班级查询
                SQL = "select 班级 from 学生";
                mycom = new OleDbCommand(SQL, con);
                myreader = mycom.ExecuteReader();

                while (myreader.Read())
                {
                    bool False = false;
                    string value = myreader[0].ToString();
                    for (int i = 0; i < comboBox3.Items.Count; i++)
                    {
                        if (comboBox3.Items[i].ToString() == value) False = true;
                    }

                    if (False == false)
                        comboBox3.Items.Add(value);
                }
                comboBox3.Items.Add("输入/选择");
            }
            //删除学生信息页面
            if (e.TabPage == tabPage3)
            {
                string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
                string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
                con = new OleDbConnection(constr);
                string mysql = "select 学号,学生姓名,班级,联系方式,密码,民族,出生年月 from 学生,登录 where 学生.学号=登录.用户名";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
                DataSet myds = new DataSet();
                myada1.Fill(myds);
                dataGridView2.DataSource = myds.Tables[0].DefaultView;
                con.Close();

            }
        }


        //学生增加

        private void insertStu_Click_1(object sender, EventArgs e)
        {
            if (tbStu1.Text == "" || tbStu2.Text == "" || tbStu3.Text == "" || tbStu4.Text == "" || tbStu5.Text == "" || tbStu7.Text == "")
            {
                MessageBox.Show("请输入完整信息！");
                return;
            }

            string strInsert = " INSERT INTO 学生(学号,学生姓名,班级,联系方式,出生年月,民族) VALUES ( '";
            strInsert += tbStu1.Text + "', '";
            strInsert += tbStu2.Text + "', '";
            strInsert += tbStu3.Text + "', ";
            strInsert += tbStu4.Text + ",'";
            strInsert += riqi.Value.Date.ToString("yy-MM-dd") + "','";
            strInsert += tbStu7.Text + "')";
            string strInsert2 = " INSERT INTO 登录(用户名,密码,属性) VALUES ( '";
            strInsert2 += tbStu1.Text + "', " + tbStu5.Text + ",'1')";
            string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
            OleDbConnection con = new OleDbConnection(constr);
            con.Open();
            OleDbCommand inst = new OleDbCommand(strInsert, con);
            try
            {
                inst.ExecuteNonQuery();
                inst = new OleDbCommand(strInsert2, con);
                inst.ExecuteNonQuery();
                MessageBox.Show("添加成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("学号已重复，请查证！");
            }

            string mysql = "select 学号,学生姓名,班级,联系方式,密码,民族,出生年月 from 学生,登录 where 学生.学号=登录.用户名";
            OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
            DataSet myds = new DataSet();
            myada1.Fill(myds);
            dataGridViewStu.DataSource = myds.Tables[0].DefaultView;
            con.Close();
            tbStu1.Clear();
            tbStu2.Clear();
            tbStu3.Clear();
            tbStu4.Clear();
            tbStu5.Clear();
            tbStu7.Clear();

        }

        //学生查询
        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "输入/选择" && comboBox2.Text == "输入/选择" && comboBox3.Text == "输入/选择")
            {
                MessageBox.Show("请输入查询条件！");
            }
            //按学号查询
            if (comboBox1.Text != "输入/选择" && comboBox2.Text == "输入/选择" && comboBox3.Text == "输入/选择")
            {
                string mysql = "select * from 学生 where 学号='" + comboBox1.Text + "'";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
                DataSet myds = new DataSet();
                myada1.Fill(myds);
                dataGridView1.DataSource = myds.Tables[0];
            }
            //按姓名查询
            if (comboBox1.Text == "输入/选择" && comboBox2.Text != "输入/选择" && comboBox3.Text == "输入/选择")
            {
                string mysql = "select * from 学生 where 学生姓名='" + comboBox2.Text + "'";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
                DataSet myds = new DataSet();
                myada1.Fill(myds);
                dataGridView1.DataSource = myds.Tables[0];
            }
            //按班级查询
            if (comboBox1.Text == "输入/选择" && comboBox2.Text == "输入/选择" && comboBox3.Text != "输入/选择")
            {
                string mysql = "select * from 学生 where 班级='" + comboBox3.Text + "'";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
                DataSet myds = new DataSet();
                myada1.Fill(myds);
                dataGridView1.DataSource = myds.Tables[0];
            }

            // 按学号和学生姓名查询
            if (comboBox1.Text != "输入/选择" && comboBox2.Text != "输入/选择" && comboBox3.Text == "输入/选择")
            {
                string mysql = "select * from 学生 where 学生姓名='" + comboBox2.Text + "' and 学号='" + comboBox1.Text + "'";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
                DataSet myds = new DataSet();
                myada1.Fill(myds);
                dataGridView1.DataSource = myds.Tables[0];
            }
            // 按学号和班级查询

            if (comboBox1.Text != "输入/选择" && comboBox2.Text == "输入/选择" && comboBox3.Text != "输入/选择")
            {

                string mysql = "select * from 学生 where 学号='" + comboBox1.Text + "'and 班级='" + comboBox3.Text + "'";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
                DataSet myds = new DataSet();
                myada1.Fill(myds);
                dataGridView1.DataSource = myds.Tables[0];
            }

            // 按学生姓名和班级查询
            if (comboBox1.Text == "输入/选择" && comboBox2.Text != "输入/选择" && comboBox3.Text != "输入/选择")
            {
                string mysql = "select * from 学生 where 学生姓名='" + comboBox2.Text + "' and 班级='" + comboBox3.Text + "'";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
                DataSet myds = new DataSet();
                myada1.Fill(myds);
                dataGridView1.DataSource = myds.Tables[0];
            }
            // 按三者同时查询
            if (comboBox1.Text != "输入/选择" && comboBox2.Text != "输入/选择" && comboBox3.Text != "输入/选择")
            {
                string mysql = "select * from 学生 where 学生姓名='" + comboBox2.Text + "'and 学号='" + comboBox1.Text + "'and 班级='" + comboBox3.Text + "'";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
                DataSet myds = new DataSet();
                myada1.Fill(myds);
                dataGridView1.DataSource = myds.Tables[0];
            }

            tbStu1.Clear();
            tbStu2.Clear();
            tbStu3.Clear();
            tbStu4.Clear();
            tbStu5.Clear();
            tbStu7.Clear();
            
        }
        //学生删除
        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string strDelete = "DELETE FROM 学生 WHERE 学号='" + dataGridView2.CurrentRow.Cells["学号"].Value.ToString() + "'";
            OleDbCommand inst = new OleDbCommand(strDelete, con);
            int a = inst.ExecuteNonQuery();
            strDelete = "DELETE FROM 登录 WHERE 用户名='" + dataGridView2.CurrentRow.Cells["学号"].Value.ToString() + "'";
            inst = new OleDbCommand(strDelete, con);
            inst.ExecuteNonQuery();
            string mysql = "select 学号,学生姓名,班级,联系方式,密码,民族,出生年月 from 学生,登录 where 学生.学号=登录.用户名";
            OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
            DataSet myds = new DataSet();
            myada1.Fill(myds);
            dataGridView2.DataSource = myds.Tables[0].DefaultView;
            con.Close();
            tbStu1.Clear();
            tbStu2.Clear();
            tbStu3.Clear();
            tbStu4.Clear();
            tbStu5.Clear();
            tbStu7.Clear();


        }
        //新的窗体关闭后，原窗体执行的操作，即修改和更新
        private void frmManager_Activated(object sender, EventArgs e)
        {
            string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
            con = new OleDbConnection(constr);
            
            string mysql = "select 学号,学生姓名,班级,联系方式,密码,民族,出生年月 from 学生,登录 where 学生.学号=登录.用户名";
            OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
            DataSet myds = new DataSet();
            myada1.Fill(myds);
            dataGridView2.DataSource = myds.Tables[0].DefaultView;

            // 更新教师
            mysql = "select 教师编号,教师姓名,联系方式,性别,密码,出生年月 from 教师,登录 where 教师编号=用户名";
            myada1 = new OleDbDataAdapter(mysql, con);
            myds = new DataSet();
            myada1.Fill(myds);
            dataGridView6.DataSource = myds.Tables[0].DefaultView;
           
            // 更新课程

            mysql = "select 课程编号,课程名称,教师姓名,学分 from 教师,课程 where 课程.教师编号=教师.教师编号";
            myada1 = new OleDbDataAdapter(mysql, con);
            myds = new DataSet();
            myada1.Fill(myds);
            dataGridView7.DataSource = myds.Tables[0].DefaultView;

            // 更新选课
            mysql = "select 成绩.学号,学生.学生姓名,成绩.课程编号,课程名称,成绩.分数,教师.教师姓名 from 成绩,教师,学生,课程 where 课程.教师编号=教师.教师编号 and 学生.学号=成绩.学号 and 课程.课程编号=成绩.课程编号";
            myada1 = new OleDbDataAdapter(mysql, con);
            myds = new DataSet();
            myada1.Fill(myds);
            dataGridView8.DataSource = myds.Tables[0].DefaultView;


        }
        //修改按钮
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 update = new Form1();
            update.tbStu1.Text = tb1;
            update.tbStu2.Text = tb2;
            update.tbStu3.Text = tb3;
            update.tbStu4.Text = tb4;
            update.tbStu5.Text = tb5;
            update.riqi.Value = tb6;
            update.tbStu7.Text = tb7;
            update.Show();


        }
        string tb1, tb2, tb3, tb4, tb5, tb7;
        DateTime tb6;
        private void dataGridViewStu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = dataGridView2.CurrentRow.Index;
            tb1 = dataGridView2.Rows[a].Cells["学号"].Value.ToString();
            tb2 = dataGridView2.Rows[a].Cells["学生姓名"].Value.ToString();
            tb3 = dataGridView2.Rows[a].Cells["班级"].Value.ToString();
            tb4 = dataGridView2.Rows[a].Cells["联系方式"].Value.ToString();
            tb5 = dataGridView2.Rows[a].Cells["密码"].Value.ToString();
            tb6 = (DateTime)dataGridView2.Rows[a].Cells["出生年月"].Value;
            tb7 = dataGridView2.Rows[a].Cells["民族"].Value.ToString();

        }

        //以下为教师的标签
        private void tabControl2_Selected(object sender, TabControlEventArgs e)
        {

            //教师标签

            //教师信息增加
            if (e.TabPage == tabPage4)
            {
                string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
                string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
                con = new OleDbConnection(constr);
                string mysql = "select 教师编号,教师姓名,联系方式,性别,密码 from 教师,登录 where 教师编号=用户名";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
                DataSet myds = new DataSet();
                myada1.Fill(myds);
                dataGridViewTch.DataSource = myds.Tables[0].DefaultView;

            }

            //教师信息查询
            if (e.TabPage == tabPage5)
            {
                comboBox5.Items.Clear();
                comboBox4.Items.Clear();
                comboBox6.Items.Clear();
                string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
                string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
                con = new OleDbConnection(constr);
                //教工号
                comboBox5.Items.Add("输入/选择");
                string SQL = "select 教师编号 from 教师";
                OleDbCommand mycom = new OleDbCommand(SQL, con);
                con.Open();
                OleDbDataReader myreader = mycom.ExecuteReader();

                while (myreader.Read())
                {
                    bool False = false;

                    string value = myreader[0].ToString();
                    for (int i = 0; i < comboBox5.Items.Count; i++)
                    {
                        if (comboBox5.Items[i].ToString() == value) False = true;
                    }

                    if (False == false)
                        comboBox5.Items.Add(value);
                }


                // 教师姓名
                comboBox4.Items.Add("输入/选择");
                SQL = "select 教师姓名 from 教师";
                mycom = new OleDbCommand(SQL, con);
                myreader = mycom.ExecuteReader();
                while (myreader.Read())
                {
                    bool False = false;

                    string value = myreader[0].ToString();
                    for (int i = 0; i < comboBox4.Items.Count; i++)
                    {
                        if (comboBox4.Items[i].ToString() == value) False = true;
                    }

                    if (False == false)
                        comboBox4.Items.Add(value);
                }


                //课程
                SQL = "select 课程名称 from 课程 ";
                mycom = new OleDbCommand(SQL, con);
                comboBox6.Items.Add("输入/选择");
                myreader = mycom.ExecuteReader();
                while (myreader.Read())
                {
                    bool False = false;

                    string value = myreader[0].ToString();
                    for (int i = 0; i < comboBox6.Items.Count; i++)
                    {
                        if (comboBox6.Items[i].ToString() == value) False = true;
                    }

                    if (False == false)
                        comboBox6.Items.Add(value);

                }


            }
            //教师信息的删除&修改
            if (e.TabPage == tabPage6)
            {
                string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
                string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
                con = new OleDbConnection(constr);
                string mysql = "select 教师编号,教师姓名,联系方式,性别,密码 from 教师,登录 where 教师编号=用户名";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
                DataSet myds = new DataSet();
                myada1.Fill(myds);
                dataGridView6.DataSource = myds.Tables[0].DefaultView;
                con.Close();
            }
        }

        //教师的insert
        private void insertTch_Click_1(object sender, EventArgs e)
        {

            if (tbTch1.Text == "" || tbTch2.Text == "" || tbTch3.Text == "" || tbTch4.Text == "")
            {
                MessageBox.Show("请输入完整信息！");
                return;
            }

            string strInsert = " INSERT INTO 教师(教师编号,教师姓名,联系方式,性别,出生年月) VALUES ( '";
            strInsert += tbTch1.Text + "', '";
            strInsert += tbTch2.Text + "', '";
            strInsert += tbTch3.Text + "','";
            strInsert += tbTch5.Text + "', '";
            strInsert += teriqi.Value.Date.ToString("yy-MM-dd") + "')";
            string strInsert2 = " INSERT INTO 登录(用户名,密码,属性) VALUES ( '";
            strInsert2 += tbTch1.Text + "', " + tbTch4.Text + ",2)";
            string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;

            con.Open();

            OleDbCommand inst = new OleDbCommand(strInsert, con);
            try
            {
                inst.ExecuteNonQuery();
                inst = new OleDbCommand(strInsert2, con);
                inst.ExecuteNonQuery();
                MessageBox.Show("添加成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("信息重复！");
                return;
            }
            string mysql = "select 教师编号,教师姓名,联系方式,出生年月,性别,密码 from 教师,登录 where 教师编号=用户名";
            OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
            DataSet myds = new DataSet();
            myada1.Fill(myds);
            dataGridViewTch.DataSource = myds.Tables[0];
            con.Close();
            tbTch1.Clear();
            tbTch2.Clear();
            tbTch3.Clear();
            tbTch4.Clear();
            tbTch5.Clear();
        }

        //教师的delete
        private void button7_Click(object sender, EventArgs e)
        {
            string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
            con = new OleDbConnection(constr);
            con.Open();
            string strDelete = "DELETE FROM 教师 WHERE 教师编号='" + dataGridView6.CurrentRow.Cells["教师编号"].Value.ToString() + "'";
            OleDbCommand inst = new OleDbCommand(strDelete, con);
            inst.ExecuteNonQuery();
            strDelete = "DELETE FROM 登录 WHERE 用户名='" + dataGridView6.CurrentRow.Cells["教师编号"].Value.ToString() + "'";
            inst = new OleDbCommand(strDelete, con);
            inst.ExecuteNonQuery();
            string mysql = "select 教师编号,教师姓名,联系方式,性别,密码,出生年月 from 教师,登录 where 教师编号=用户名";
            OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
            DataSet myds = new DataSet();
            myada1.Fill(myds);
            dataGridView6.DataSource = myds.Tables[0].DefaultView;
            con.Close();

        }

        //教师的update

        private void button8_Click(object sender, EventArgs e)
        {
            updatetea update = new updatetea();
            update.textBox7.Text = tea1;
            update.textBox8.Text = tea2;
            update.textBox3.Text = tea3;
            update.textBox2.Text = tea4;
            update.textBox5.Text = tea5;
            update.riqit.Value = b;
            update.Show();

        }
        static public string tea1, tea2, tea3, tea4, tea5;

        DateTime b;
        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = dataGridView6.CurrentRow.Index;
            tea1 = dataGridView6.Rows[a].Cells["教师编号"].Value.ToString();
            tea2 = dataGridView6.Rows[a].Cells["教师姓名"].Value.ToString();
            tea3 = dataGridView6.Rows[a].Cells["性别"].Value.ToString();
            tea4 = dataGridView6.Rows[a].Cells["联系方式"].Value.ToString();
            tea5 = dataGridView6.Rows[a].Cells["密码"].Value.ToString();
            b = (DateTime)dataGridView2.Rows[a].Cells["出生年月"].Value;
        }





        //教师的enqury
        private void button6_Click(object sender, EventArgs e)
        {

            if (comboBox5.Text == "输入/选择" && comboBox4.Text == "输入/选择" && comboBox6.Text == "输入/选择")
            {
                MessageBox.Show("请输入查询条件！");
            }

            //按教工号查询
            if (comboBox5.Text != "输入/选择" && comboBox4.Text == "输入/选择" && comboBox6.Text == "输入/选择")
            {
                string mysql = "select 教师编号,教师姓名,联系方式,性别,密码,出生年月 from 教师,登录 where 教师编号=用户名 and 教师编号='" + comboBox5.Text + "'";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
                DataSet myds = new DataSet();
                myada1.Fill(myds);
                dataGridView3.DataSource = myds.Tables[0];
            }
            //按姓名查询
            if (comboBox5.Text == "输入/选择" && comboBox4.Text != "输入/选择" && comboBox6.Text == "输入/选择")
            {
                string mysql = "select 教师编号,教师姓名,联系方式,性别,密码,出生年月 from 教师,登录 where 教师编号=用户名 and 教师姓名='" + comboBox4.Text + "'";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
                DataSet myds = new DataSet();
                myada1.Fill(myds);
                dataGridView3.DataSource = myds.Tables[0];
            }
           
            //按教授课程查询
            if (comboBox5.Text == "输入/选择" && comboBox4.Text == "输入/选择" && comboBox6.Text != "输入/选择")
            {
                string mysql = "select 教师.教师编号,教师姓名,联系方式,性别,密码,出生年月 from 教师,登录,课程 where 教师.教师编号=用户名 and 课程.课程名称='" + comboBox6.Text + "' and 课程.教师编号=教师.教师编号";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
                DataSet myds = new DataSet();
                myada1.Fill(myds);
                dataGridView3.DataSource = myds.Tables[0];
            }
            
            

            //按教工和教师姓名查询
            if (comboBox5.Text != "输入/选择" && comboBox4.Text != "输入/选择" && comboBox6.Text == "输入/选择")
            {
                string mysql = "select 教师编号,教师姓名,联系方式,性别,密码,出生年月 from 教师,登录 where 教师编号=用户名 and 教师姓名='" + comboBox4.Text + "' and 教师编号='" + comboBox5.Text + "'";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
                DataSet myds = new DataSet();
                myada1.Fill(myds);
                dataGridView3.DataSource = myds.Tables[0];
            }


            //按教工号和教授课程查询
            if (comboBox5.Text != "输入/选择" && comboBox4.Text == "输入/选择" && comboBox6.Text != "输入/选择")
            {
                string mysql = "select 教师.教师编号,教师姓名,联系方式,性别,密码,出生年月 from 教师,登录,课程 where 教师.教师编号='" + comboBox5.Text + "' and 课程名称='" + comboBox6.Text + "' and 课程.教师编号=教师.教师编号 and 教师.教师编号=用户名";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
                DataSet myds = new DataSet();
                myada1.Fill(myds);
                dataGridView3.DataSource = myds.Tables[0];
                   
              
            }
            

            // 按姓名和教授课程查询
            if (comboBox5.Text == "输入/选择" && comboBox4.Text != "输入/选择" && comboBox6.Text != "输入/选择")
            {
                string mysql = "select 教师.教师编号,教师姓名,联系方式,性别,密码,出生年月 from 教师,登录,课程 where 教师姓名='" + comboBox4.Text + "' and 课程名称='" + comboBox6.Text + "' and 课程.教师编号=教师.教师编号 and 教师.教师编号=用户名";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
                DataSet myds = new DataSet();
                myada1.Fill(myds);
                dataGridView3.DataSource = myds.Tables[0];
            }
            // 按三者同时查询
            if (comboBox5.Text != "输入/选择" && comboBox4.Text != "输入/选择" && comboBox6.Text != "输入/选择")
            {
                string mysql = "select 教师.教师编号,教师姓名,联系方式,性别,密码,出生年月 from 教师,登录,课程 where 教师.教师编号=用户名 and 教师.教师姓名='" + comboBox4.Text + "' and 课程.教师编号=教师.教师编号" + " and 教师.教师编号='" + comboBox5.Text + "'and 课程.课程名称='" + comboBox6.Text + "'";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
                DataSet myds = new DataSet();
                myada1.Fill(myds);
                dataGridView3.DataSource = myds.Tables[0];
            }
             


        }

        //以下是课程的标签
        private void tabControl3_Selected(object sender, TabControlEventArgs e)
        {
            //增加
            if (e.TabPage == tabPage7)
            {
                comboBox16.Items.Clear();
                string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
                string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
                con = new OleDbConnection(constr);
                string mysql = "select 课程编号,课程名称,教师姓名,学分 from 教师,课程 where 课程.教师编号=教师.教师编号";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
                DataSet myds = new DataSet();
                myada1.Fill(myds);
                dataGridViewLsn.DataSource = myds.Tables[0].DefaultView;
                string SQL = "select 教师编号 from 教师";
                OleDbCommand mycom = new OleDbCommand(SQL, con);
                con.Open();
                OleDbDataReader myreader = mycom.ExecuteReader();
                while (myreader.Read())
                {
                    comboBox16.Items.Add(myreader[0]);
                }

                con.Close();
            }
            //查询
            if (e.TabPage == tabPage8)
            {

                comboBox8.Items.Clear();
                comboBox7.Items.Clear();
                comboBox9.Items.Clear();
                string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
                string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
                con = new OleDbConnection(constr);
                //课程号
                comboBox8.Items.Add("输入/选择");
                string SQL = "select 课程编号 from 课程";
                OleDbCommand mycom = new OleDbCommand(SQL, con);
                con.Open();
                OleDbDataReader myreader = mycom.ExecuteReader();

                while (myreader.Read())
                {
                    bool False = false;

                    string value = myreader[0].ToString();
                    for (int i = 0; i < comboBox8.Items.Count; i++)
                    {
                        if (comboBox8.Items[i].ToString() == value) False = true;
                    }

                    if (False == false)
                        comboBox8.Items.Add(value);
                }


                // 课程姓名
                comboBox7.Items.Add("输入/选择");
                SQL = "select 课程名称 from 课程";
                mycom = new OleDbCommand(SQL, con);
                myreader = mycom.ExecuteReader();
                while (myreader.Read())
                {
                    bool False = false;

                    string value = myreader[0].ToString();
                    for (int i = 0; i < comboBox7.Items.Count; i++)
                    {
                        if (comboBox7.Items[i].ToString() == value) False = true;
                    }

                    if (False == false)
                        comboBox7.Items.Add(value);
                }


                //教师姓名
                SQL = "select 教师姓名 from 教师 ";
                mycom = new OleDbCommand(SQL, con);
                comboBox9.Items.Add("输入/选择");
                myreader = mycom.ExecuteReader();
                while (myreader.Read())
                {
                    bool False = false;

                    string value = myreader[0].ToString();
                    for (int i = 0; i < comboBox9.Items.Count; i++)
                    {
                        if (comboBox9.Items[i].ToString() == value) False = true;
                    }

                    if (False == false)
                        comboBox9.Items.Add(value);

                }

            }
            //删除&修改
            if (e.TabPage == tabPage9)
            {
                string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
                string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
                con = new OleDbConnection(constr);
                string mysql = "select 课程编号,课程名称,教师姓名,学分 from 教师,课程 where 课程.教师编号=教师.教师编号";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
                DataSet myds = new DataSet();
                myada1.Fill(myds);
                dataGridView7.DataSource = myds.Tables[0].DefaultView;
                con.Close();
            }


        }

        //课程的GridView
        private void dataGridViewLsn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            tea1 = dataGridView7.CurrentRow.Cells["课程编号"].Value.ToString();
            tea2 = dataGridView7.CurrentRow.Cells["课程名称"].Value.ToString();
            tea3 = dataGridView7.CurrentRow.Cells["教师姓名"].Value.ToString();
            tea4 = dataGridView7.CurrentRow.Cells["学分"].Value.ToString();
        }

        //课程的insert
        private void insertLsn_Click_1(object sender, EventArgs e)
        {
            if (tbLsn1.Text == "" || tbLsn2.Text == "" || comboBox16.Text == "" || tbLsn4.Text == "")
            {
                MessageBox.Show("请输入完整信息！");
                return;
            }
            bool result = false;
            for (int i = 0; i < comboBox16.Items.Count; i++)
            {
                if (comboBox16.Items[i].ToString() == comboBox16.Text)
                {
                    result = true;
                    break;
                }
            }
            if (result == false)
            {
                MessageBox.Show("该教师不存在!");
                return;
            }
            //string strInsert = " INSERT INTO 课程(课程编号,课程名称,教师编号,学分) VALUES ('" + this.tbLsn1.Text + "','" + this.tbLsn2.Text + "','" + this.comboBox16.Text + "',2)";
            string strInsert = " INSERT INTO 课程(课程编号,课程名称,教师编号,学分) VALUES ('" + this.tbLsn1.Text + "','" + this.tbLsn2.Text + "','" + this.comboBox16.Text + "'," +tbLsn4.Text + ")";
            string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;

            OleDbConnection con = new OleDbConnection(constr);
            con.Open();
            OleDbCommand inst = new OleDbCommand(strInsert, con);
            try
            {
                inst.ExecuteNonQuery();
                MessageBox.Show("添加成功！");
            }
            catch (Exception e2)
            {
                MessageBox.Show("课程号重复！");
                return;
            }
            mypath = Application.StartupPath + "\\DatabaseC#.accdb";
            constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
            con = new OleDbConnection(constr);
            string mysql = "select 课程编号,课程名称,教师姓名,学分 from 教师,课程 where 课程.教师编号=教师.教师编号";
            OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
            DataSet myds = new DataSet();
            myada1.Fill(myds);
            dataGridViewLsn.DataSource = myds.Tables[0].DefaultView;
        }

        //课程的delete
        private void button9_Click(object sender, EventArgs e)
        {
            string strDelete = "DELETE FROM 课程 WHERE 课程编号='" + dataGridView7.CurrentRow.Cells["课程编号"].Value.ToString() + "'";
            string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;

            OleDbConnection con = new OleDbConnection(constr);
            con.Open();
            OleDbCommand inst = new OleDbCommand(strDelete, con);
            inst.ExecuteNonQuery();
            MessageBox.Show("已删除");
            string mysql = "select 课程编号,课程名称,教师姓名,学分 from 教师,课程 where 课程.教师编号=教师.教师编号";
            OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
            DataSet myds = new DataSet();
            myada1.Fill(myds);
            dataGridView7.DataSource = myds.Tables[0].DefaultView;


        }

        //课程的update
        private void button10_Click(object sender, EventArgs e)
        {
            string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;

            OleDbConnection con = new OleDbConnection(constr);
            con.Open();
            Form3 update = new Form3();
            update.tbLsn1.Text = tea1;
            update.tbLsn2.Text = tea2;
            string SQL = "select 教师编号 from 教师 where 教师姓名='" + tea3 + "'";
            OleDbCommand mycom = new OleDbCommand(SQL, con);
            OleDbDataReader myreader = mycom.ExecuteReader();
            while (myreader.Read())
            {
                tea3 = myreader[0].ToString();
            }
            update.comboBox16.Text = tea3;
            update.tbLsn4.Text = tea4;
            update.Show();
            SQL = "select 教师编号 from 教师";
            mycom = new OleDbCommand(SQL, con);
            myreader = mycom.ExecuteReader();
            while (myreader.Read())
            {
                update.comboBox16.Items.Add(myreader[0]);
            }

        }

        //课程的enqury
        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox8.Text == "输入/选择" && comboBox7.Text == "输入/选择" && comboBox9.Text == "输入/选择")
            {
                MessageBox.Show("请输入查询条件！");
            }
            //按课程号查询
            if (comboBox8.Text != "输入/选择" && comboBox7.Text == "输入/选择" && comboBox9.Text == "输入/选择")
            {
                string mysql = "select 课程.课程编号,课程名称,学分,教师姓名 from 课程,教师 where 课程.教师编号=教师.教师编号 and 课程.课程编号='" + comboBox8.Text + "'";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
                DataSet myds = new DataSet();
                myada1.Fill(myds);
                dataGridView4.DataSource = myds.Tables[0];
            }
            //按课程名查询
            if (comboBox8.Text == "输入/选择" && comboBox7.Text != "输入/选择" && comboBox9.Text == "输入/选择")
            {
                string mysql = "select 课程.课程编号,课程名称,学分,教师姓名 from 课程,教师 where 课程.教师编号=教师.教师编号 and 课程名称='" + comboBox7.Text + "'";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
                DataSet myds = new DataSet();
                myada1.Fill(myds);
                dataGridView4.DataSource = myds.Tables[0];
            }


            //按教师名称查询
            if (comboBox8.Text == "输入/选择" && comboBox7.Text == "输入/选择" && comboBox9.Text != "输入/选择")
            {
                string mysql = "select 课程.课程编号,课程名称,学分,教师姓名 from 课程,教师 where 课程.教师编号=教师.教师编号 and 教师姓名='" + comboBox9.Text + "'";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
                DataSet myds = new DataSet();
                myada1.Fill(myds);
                dataGridView4.DataSource = myds.Tables[0];
            }

            // 按课程号和课程名查询
            if (comboBox8.Text != "输入/选择" && comboBox7.Text != "输入/选择" && comboBox9.Text == "输入/选择")
            {
                string mysql = "select 课程.课程编号,课程名称,学分,教师姓名 from 课程,教师 where 课程.教师编号=教师.教师编号 and 课程.课程编号='" + comboBox8.Text + "'and 课程名称='" + comboBox7.Text + "'";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
                DataSet myds = new DataSet();
                myada1.Fill(myds);
                dataGridView4.DataSource = myds.Tables[0];
            }

            // 按课程号教师名查询
            if (comboBox8.Text != "输入/选择" && comboBox7.Text == "输入/选择" && comboBox9.Text != "输入/选择")
            {
                string mysql = "select 课程.课程编号,课程名称,学分,教师姓名 from 课程,教师 where 课程.教师编号=教师.教师编号 and 教师姓名='" + comboBox9.Text + "' and 课程编号='" + comboBox8.Text + "'";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
                DataSet myds = new DataSet();
                myada1.Fill(myds);
                dataGridView4.DataSource = myds.Tables[0];
            }
            // 按课程名和教师名查询
            if (comboBox8.Text == "输入/选择" && comboBox7.Text != "输入/选择" && comboBox9.Text != "输入/选择")
            {
                string mysql = "select 课程.课程编号,课程名称,学分,教师姓名 from 课程,教师 where 课程.教师编号=教师.教师编号 and  教师姓名='" + comboBox9.Text + "' and 课程名称='" + comboBox7.Text + "'";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
                DataSet myds = new DataSet();
                myada1.Fill(myds);
                dataGridView4.DataSource = myds.Tables[0];
            }
            // 按三者同时查询
            if (comboBox8.Text != "输入/选择" && comboBox7.Text != "输入/选择" && comboBox9.Text != "输入/选择")
            {
                string mysql = "select 课程.课程编号,课程名称,学分,教师姓名 from 课程,教师 where 课程.教师编号=教师.教师编号 and 教师.教师姓名='" + comboBox9.Text + "' and 课程.课程编号='" + comboBox8.Text + "'and 课程.课程名称='" + comboBox7.Text + "'";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
                DataSet myds = new DataSet();
                myada1.Fill(myds);
                dataGridView4.DataSource = myds.Tables[0];
            }

        }


        //以下为选课的标签
        private void tabControl4_Selected(object sender, TabControlEventArgs e)
        {

            //增加页面
            if (e.TabPage == tabPage10)
            {
                string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
                string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
                con = new OleDbConnection(constr);
                string mysql = "select 成绩.学号,学生.学生姓名,成绩.课程编号,课程名称,成绩.分数,教师.教师姓名 from 成绩,教师,学生,课程 where 课程.教师编号=教师.教师编号 and 学生.学号=成绩.学号 and 课程.课程编号=成绩.课程编号";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
                DataSet myds = new DataSet();
                myada1.Fill(myds);
                dataGridViewChs.DataSource = myds.Tables[0].DefaultView;

                string SQL = "select 课程编号 from 课程";
                OleDbCommand mycom = new OleDbCommand(SQL, con);
                con.Open();
                OleDbDataReader myreader = mycom.ExecuteReader();
                while (myreader.Read())
                {

                    comboBox17.Items.Add(myreader[0]);
                }
                SQL = "select 学号 from 学生";
                mycom = new OleDbCommand(SQL, con);

                myreader = mycom.ExecuteReader();
                while (myreader.Read())
                {

                    comboBox19.Items.Add(myreader[0]);
                }
                con.Close();
            }
            //查询页面
            if (e.TabPage == tabPage11)
            {
                comboBox10.Items.Clear();
                comboBox11.Items.Clear();
                comboBox12.Items.Clear();
                comboBox13.Items.Clear();
                string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
                string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
                con = new OleDbConnection(constr);
                //学号
                string SQL = "select 学号 from 学生";
                OleDbCommand mycom = new OleDbCommand(SQL, con);
                con.Open();
                OleDbDataReader myreader = mycom.ExecuteReader();
                while (myreader.Read())
                {
                    comboBox11.Items.Add(myreader[0]);
                }
                comboBox11.Items.Add("选择&输入");
                // 学生姓名
                SQL = "select 学生姓名 from 学生";
                mycom = new OleDbCommand(SQL, con);
                myreader = mycom.ExecuteReader();
                while (myreader.Read())
                {
                    bool False = false;
                    string value = myreader[0].ToString();
                    for (int i = 0; i < comboBox13.Items.Count; i++)
                    {
                        if (comboBox13.Items[i].ToString() == value) False = true;
                    }

                    if (False == false)
                        comboBox13.Items.Add(value);

                }
                comboBox13.Items.Add("选择&输入");
                //课程号
                comboBox10.Items.Add("选择&输入");
                SQL = "select 课程编号 from 课程";
                mycom = new OleDbCommand(SQL, con);
                myreader = mycom.ExecuteReader();

                while (myreader.Read())
                {
                    bool False = false;

                    string value = myreader[0].ToString();
                    for (int i = 0; i < comboBox10.Items.Count; i++)
                    {
                        if (comboBox10.Items[i].ToString() == value) False = true;
                    }

                    if (False == false)
                        comboBox10.Items.Add(value);
                }


                // 课程姓名
                comboBox12.Items.Add("选择&输入");
                SQL = "select 课程名称 from 课程";
                mycom = new OleDbCommand(SQL, con);
                myreader = mycom.ExecuteReader();
                while (myreader.Read())
                {
                    bool False = false;

                    string value = myreader[0].ToString();
                    for (int i = 0; i < comboBox12.Items.Count; i++)
                    {
                        if (comboBox12.Items[i].ToString() == value) False = true;
                    }

                    if (False == false)
                        comboBox12.Items.Add(value);
                }
            }
            //删除&更改页面
            if (e.TabPage == tabPage12)
            {
                string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
                string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
                con = new OleDbConnection(constr);
                string mysql = "select 成绩.学号,学生.学生姓名,成绩.课程编号,课程名称,成绩.分数,教师.教师姓名 from 成绩,教师,学生,课程 where 课程.教师编号=教师.教师编号 and 学生.学号=成绩.学号 and 课程.课程编号=成绩.课程编号";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
                DataSet myds = new DataSet();
                myada1.Fill(myds);
                dataGridView8.DataSource = myds.Tables[0].DefaultView;
                con.Close();
            }





        }




        //选课的GridView
        private void dataGridViewChs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            tea1 = dataGridView8.CurrentRow.Cells["课程编号"].Value.ToString();
            tea2 = dataGridView8.CurrentRow.Cells["学号"].Value.ToString();
            //tea3 = dataGridView8.CurrentRow.Cells["教师编号"].Value.ToString();

        }

        //选课的insert
        private void insertChs_Click_1(object sender, EventArgs e)
        {
            if (comboBox17.Text == "" || comboBox19.Text == "")
            {
                MessageBox.Show("请输入完整信息！");
                return;
            }
            bool kecheng = false;
            for (int i = 0; i < comboBox17.Items.Count; i++)
            {
                if (comboBox17.Items[i].ToString() == comboBox17.Text)
                {
                    kecheng = true;
                    break;
                }
            }
            bool xuehao = false;
            for (int i = 0; i < comboBox19.Items.Count; i++)
            {
                if (comboBox19.Items[i].ToString() == comboBox19.Text)
                {
                    xuehao = true;
                    break;
                }
            }

            if (xuehao == false || kecheng == false)
            {
                MessageBox.Show("没有此学号或课程号，请查证！");
                return;
            }

            string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
            OleDbConnection con = new OleDbConnection(constr);
            con.Open();
            string bianhao = "";
            string strInsert = "select 教师编号 from 课程 where 课程编号='" + comboBox17.Text + "'";
            OleDbCommand inst = new OleDbCommand(strInsert, con);
            OleDbDataReader reader = inst.ExecuteReader();
            while (reader.Read())
            {
                bianhao = reader[0].ToString();
            }

            strInsert = " INSERT INTO 成绩(学号,课程编号,是否评分) VALUES ( '";
            strInsert += comboBox19.Text + "', '";
            strInsert += comboBox17.Text + "',0)";
            mypath = Application.StartupPath + "\\DatabaseC#.accdb";
            constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;


            inst = new OleDbCommand(strInsert, con);
            try
            {
                inst.ExecuteNonQuery();
            }
            catch (Exception ec)
            {
                MessageBox.Show("添加信息重复");
                return;
            }
            string mysql = "select 成绩.学号,学生.学生姓名,成绩.课程编号,课程名称,成绩.分数,教师.教师姓名 from 成绩,教师,学生,课程 where 课程.教师编号=教师.教师编号 and 学生.学号=成绩.学号 and 课程.课程编号=成绩.课程编号"; ;
            OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
            DataSet myds = new DataSet();
            myada1.Fill(myds);
            dataGridViewChs.DataSource = myds.Tables[0];
            MessageBox.Show("添加成功！");
        }

        //选课的delete

        private void button11_Click(object sender, EventArgs e)
        {
            string strDelete = "DELETE FROM 成绩 WHERE 课程编号='" + dataGridView8.CurrentRow.Cells["课程编号"].Value.ToString() + "' and 学号='" + dataGridView8.CurrentRow.Cells["学号"].Value.ToString() + "'";
            string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;

            OleDbConnection con = new OleDbConnection(constr);
            con.Open();
            OleDbCommand inst = new OleDbCommand(strDelete, con);
            inst.ExecuteNonQuery();
            string mysql = "select 成绩.学号,学生.学生姓名,成绩.课程编号,课程名称,成绩.分数,教师.教师姓名 from 成绩,教师,学生,课程 where 课程.教师编号=教师.教师编号 and 学生.学号=成绩.学号 and 课程.课程编号=成绩.课程编号";
            OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
            DataSet myds = new DataSet();
            myada1.Fill(myds);
            dataGridView8.DataSource = myds.Tables[0];

        }

        //选课的update
        private void button12_Click(object sender, EventArgs e)
        {
            string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;

            OleDbConnection con = new OleDbConnection(constr);
            con.Open();
            Form5 update = new Form5();
            update.comboBox17.Text = tea1;
            update.comboBox19.Text = tea2;
            string SQL = "select 课程编号 from 课程 ";
            OleDbCommand mycom = new OleDbCommand(SQL, con);
            OleDbDataReader myreader = mycom.ExecuteReader();
            while (myreader.Read())
            {
                update.comboBox17.Items.Add(myreader[0]);
            }

            SQL = "select 学号 from 学生";
            mycom = new OleDbCommand(SQL, con);
            myreader = mycom.ExecuteReader();
            while (myreader.Read())
            {
                update.comboBox19.Items.Add(myreader[0]);
            }
            update.Show();
        }
        //选课的enqury
        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox10.Text == "选择&输入" && comboBox11.Text == "选择&输入")
            {
                MessageBox.Show("请输入学号或者课程号！");
            }
            //按学号
            if (comboBox10.Text == "选择&输入" && comboBox11.Text != "选择&输入")
            {
                string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
                string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
                con = new OleDbConnection(constr);
                string mysql = "select 成绩.学号,学生.学生姓名,成绩.课程编号,课程名称,成绩.分数,教师.教师姓名 from 成绩,教师,学生,课程 where 课程.教师编号=教师.教师编号 and 学生.学号=成绩.学号 and 课程.课程编号=成绩.课程编号 and 成绩.学号='" + comboBox11.Text + "'";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
                DataSet myds = new DataSet();
                myada1.Fill(myds);
                dataGridView5.DataSource = myds.Tables[0].DefaultView;

            }
            //课程号
            if (comboBox10.Text != "选择&输入" && comboBox11.Text == "选择&输入")
            {
                string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
                string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
                con = new OleDbConnection(constr);
                string mysql = "select 成绩.学号,学生.学生姓名,成绩.课程编号,课程名称,成绩.分数,教师.教师姓名 from 成绩,教师,学生,课程 where 课程.教师编号=教师.教师编号 and 学生.学号=成绩.学号 and 课程.课程编号=成绩.课程编号 and 成绩.课程编号='" + comboBox10.Text + "'";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
                DataSet myds = new DataSet();
                myada1.Fill(myds);
                dataGridView5.DataSource = myds.Tables[0].DefaultView;

            }
            //学号和课程号
            if (comboBox10.Text != "选择&输入" && comboBox11.Text != "选择&输入")
            {
                string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
                string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
                con = new OleDbConnection(constr);
                string mysql = "select 成绩.学号,学生.学生姓名,成绩.课程编号,课程名称,成绩.分数,教师.教师姓名 from 成绩,教师,学生,课程 where 课程.教师编号=教师.教师编号 and 学生.学号=成绩.学号 and 课程.课程编号=成绩.课程编号 and 成绩.课程编号='" + comboBox10.Text + "'and 成绩.学号='" + comboBox11.Text + "'";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
                DataSet myds = new DataSet();
                myada1.Fill(myds);
                dataGridView5.DataSource = myds.Tables[0].DefaultView;

            }

        }

        private void comboBox13_TextChanged(object sender, EventArgs e)
        {
            comboBox11.Items.Clear();
            if (comboBox13.Text == "选择&输入")
            {
                string mypath1 = Application.StartupPath + "\\DatabaseC#.accdb";
                string constr2 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath1;
                con = new OleDbConnection(constr2);
                //学号
                string SQL = "select 学号 from 学生";
                OleDbCommand mycom = new OleDbCommand(SQL, con);
                con.Open();
                OleDbDataReader myreader = mycom.ExecuteReader();
                while (myreader.Read())
                {
                    comboBox11.Items.Add(myreader[0]);
                }
                comboBox11.Items.Add("选择&输入");
                return;

            }
            string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
            con = new OleDbConnection(constr);
            string mysql = "select 学号 from 学生 where 学生姓名='" + comboBox13.Text + "'";
            OleDbCommand com = new OleDbCommand(mysql, con);
            con.Open();
            OleDbDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                comboBox11.Items.Add(reader[0]);
            }

        }

        private void comboBox12_TextChanged(object sender, EventArgs e)
        {
            comboBox10.Items.Clear();
            if (comboBox12.Text == "选择&输入")
            {
                string mypath1 = Application.StartupPath + "\\DatabaseC#.accdb";
                string constr2 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath1;
                con = new OleDbConnection(constr2);
                comboBox10.Items.Add("选择&输入");
                string SQL = "select 课程编号 from 课程";
                OleDbCommand mycom = new OleDbCommand(SQL, con);
                con.Open();
                OleDbDataReader myreader = mycom.ExecuteReader();

                while (myreader.Read())
                {
                    bool False = false;

                    string value = myreader[0].ToString();
                    for (int i = 0; i < comboBox10.Items.Count; i++)
                    {
                        if (comboBox10.Items[i].ToString() == value) False = true;
                    }

                    if (False == false)
                        comboBox10.Items.Add(value);
                }
                return;
            }


                string mypath2 = Application.StartupPath + "\\DatabaseC#.accdb";
                string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath2;
                con = new OleDbConnection(constr);
                string mysql = "select 课程编号 from 课程 where 课程名称='" + comboBox12.Text + "'";
                OleDbCommand com = new OleDbCommand(mysql, con);
                con.Open();
                OleDbDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    comboBox10.Items.Add(reader[0]);
                }

            }

        private void tcManage_Selected(object sender, TabControlEventArgs e)
        {//教师页面
            if (e.TabPage == tbManageTch)
            {
                string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
                string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
                con = new OleDbConnection(constr);
                string mysql = "select 教师编号,教师姓名,联系方式,性别,密码 from 教师,登录 where 教师编号=用户名";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
                DataSet myds = new DataSet();
                myada1.Fill(myds);
                dataGridViewTch.DataSource = myds.Tables[0].DefaultView;

            }
            //课程
            if (e.TabPage == tbManageLsn)
            {
                comboBox16.Items.Clear();
                string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
                string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
                con = new OleDbConnection(constr);
                string mysql = "select 课程编号,课程名称,教师姓名,学分 from 教师,课程 where 课程.教师编号=教师.教师编号";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
                DataSet myds = new DataSet();
                myada1.Fill(myds);
                dataGridViewLsn.DataSource = myds.Tables[0].DefaultView;
                string SQL = "select 教师编号 from 教师";
                OleDbCommand mycom = new OleDbCommand(SQL, con);
                con.Open();
                OleDbDataReader myreader = mycom.ExecuteReader();
                while (myreader.Read())
                {
                    comboBox16.Items.Add(myreader[0]);
                }

                con.Close();
            }
            //选课
            if (e.TabPage == tbManageChs)
            {
                string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
                string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
                con = new OleDbConnection(constr);
                string mysql = "select 成绩.学号,学生.学生姓名,成绩.课程编号,课程名称,成绩.分数,教师.教师姓名 from 成绩,教师,学生,课程 where 课程.教师编号=教师.教师编号 and 学生.学号=成绩.学号 and 课程.课程编号=成绩.课程编号";
                OleDbDataAdapter myada1 = new OleDbDataAdapter(mysql, con);
                DataSet myds = new DataSet();
                myada1.Fill(myds);
                dataGridViewChs.DataSource = myds.Tables[0].DefaultView;

                string SQL = "select 课程编号 from 课程";
                OleDbCommand mycom = new OleDbCommand(SQL, con);
                con.Open();
                OleDbDataReader myreader = mycom.ExecuteReader();
                while (myreader.Read())
                {

                    comboBox17.Items.Add(myreader[0]);
                }
                SQL = "select 学号 from 学生";
                mycom = new OleDbCommand(SQL, con);

                myreader = mycom.ExecuteReader();
                while (myreader.Read())
                {

                    comboBox19.Items.Add(myreader[0]);
                }
                con.Close();
            }
        }

        private void btChangePw_Click(object sender, EventArgs e)
        {
            frmChangePwd pwc = new frmChangePwd();
            pwc.Show();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
            frmIn welcome = new frmIn();
            welcome.Show();
        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        //验证密码框中输入的必须是数字
        private void tbStu5_TextChanged(object sender, EventArgs e)
        {
            int tmp;
            if (!int.TryParse(tbStu5.Text, out tmp))
            {
                MessageBox.Show("密码必须是数字！");
                tbStu5.Clear();
            }
        }

        private void tbTch4_TextChanged(object sender, EventArgs e)
        {
            int tmp;
            if (!int.TryParse(tbStu4.Text, out tmp))
            {
                MessageBox.Show("密码必须是数字！");
                tbStu4.Clear();
            }
        }

        }
    }

        
       

        

       
      

       
      
        
