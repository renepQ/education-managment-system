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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void insertLsn_Click(object sender, EventArgs e)
        {
            string mypath = Application.StartupPath + "\\DatabaseC#.accdb";
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mypath;
            OleDbConnection con = new OleDbConnection(constr);
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
            String strUpdate = "UPDATE 课程 SET 课程名称='";
            strUpdate += tbLsn2.Text + "',教师编号='";
            strUpdate += comboBox16.Text + "',学分='"+tbLsn4.Text+"' WHERE 课程编号='";
            strUpdate += tbLsn1.Text + "'";
            con.Open();
            OleDbCommand inst = new OleDbCommand(strUpdate, con);
            inst.ExecuteNonQuery();
            inst.ExecuteNonQuery();
            MessageBox.Show("修改成功！");
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
