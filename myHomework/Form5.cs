/*     此篇代码由温西铭完成      */
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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void insertChs_Click(object sender, EventArgs e)
        {

            //删除原来记录
            string strDelete = "DELETE FROM 成绩 WHERE 课程编号='" + frmManager.tea1 + "'and 学号='" + frmManager.tea2 + "'";
            string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;

            OleDbConnection con = new OleDbConnection(constr);
            con.Open();
            OleDbCommand inst = new OleDbCommand(strDelete, con);
            inst.ExecuteNonQuery();
            bool result1 = false;
            for (int i = 0; i < comboBox17.Items.Count; i++)
            {
                if (comboBox17.Items[i].ToString() == comboBox17.Text)
                {
                    result1 = true;
                    break;
                }
            }
           bool result2 = false;
            for (int i = 0; i < comboBox19.Items.Count; i++)
            {
                if (comboBox19.Items[i].ToString() == comboBox19.Text)
                {
                    result2= true;
                    break;
                }
            }
           if(result1==false||result2==false)
           {
               MessageBox.Show("课程或学生不存在，请查证！");
               return;
            }
            //添加
           string bianhao = "";
           string strInsert = "select 教师编号 from 课程 where 课程编号='" + comboBox17.Text + "'";
             inst = new OleDbCommand(strInsert, con);
           OleDbDataReader reader = inst.ExecuteReader();
           while (reader.Read())
           {
               bianhao = reader[0].ToString();
           }

           strInsert = " INSERT INTO 成绩(学号,课程编号) VALUES ( '";
           strInsert += comboBox19.Text + "','";
           strInsert += comboBox17.Text + "')";
           inst = new OleDbCommand(strInsert, con);
           try
           {
               inst.ExecuteNonQuery();
           }
           catch (Exception ec)
           {
               MessageBox.Show("信息重复！");
               return;
           }
            MessageBox.Show("修改成功！");
            this.Close();
        }
    }
}
