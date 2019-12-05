namespace myHomework
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox16 = new System.Windows.Forms.ComboBox();
            this.insertLsn = new System.Windows.Forms.Button();
            this.tbLsn4 = new System.Windows.Forms.TextBox();
            this.tbLsn2 = new System.Windows.Forms.TextBox();
            this.tbLsn1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox16
            // 
            this.comboBox16.FormattingEnabled = true;
            this.comboBox16.Location = new System.Drawing.Point(229, 178);
            this.comboBox16.Name = "comboBox16";
            this.comboBox16.Size = new System.Drawing.Size(88, 26);
            this.comboBox16.TabIndex = 22;
            // 
            // insertLsn
            // 
            this.insertLsn.Location = new System.Drawing.Point(150, 292);
            this.insertLsn.Name = "insertLsn";
            this.insertLsn.Size = new System.Drawing.Size(88, 42);
            this.insertLsn.TabIndex = 21;
            this.insertLsn.Text = "确定";
            this.insertLsn.UseVisualStyleBackColor = true;
            this.insertLsn.Click += new System.EventHandler(this.insertLsn_Click);
            // 
            // tbLsn4
            // 
            this.tbLsn4.Location = new System.Drawing.Point(229, 237);
            this.tbLsn4.Name = "tbLsn4";
            this.tbLsn4.Size = new System.Drawing.Size(68, 28);
            this.tbLsn4.TabIndex = 20;
            // 
            // tbLsn2
            // 
            this.tbLsn2.Location = new System.Drawing.Point(229, 117);
            this.tbLsn2.Name = "tbLsn2";
            this.tbLsn2.Size = new System.Drawing.Size(102, 28);
            this.tbLsn2.TabIndex = 19;
            // 
            // tbLsn1
            // 
            this.tbLsn1.Location = new System.Drawing.Point(229, 65);
            this.tbLsn1.Name = "tbLsn1";
            this.tbLsn1.ReadOnly = true;
            this.tbLsn1.Size = new System.Drawing.Size(62, 28);
            this.tbLsn1.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(104, 186);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 18);
            this.label10.TabIndex = 17;
            this.label10.Text = "授课教师：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(104, 240);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 18);
            this.label11.TabIndex = 16;
            this.label11.Text = "课程学分：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(104, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 18);
            this.label12.TabIndex = 15;
            this.label12.Text = "课程号：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(104, 127);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 18);
            this.label13.TabIndex = 14;
            this.label13.Text = "课程名称：";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 367);
            this.Controls.Add(this.comboBox16);
            this.Controls.Add(this.insertLsn);
            this.Controls.Add(this.tbLsn4);
            this.Controls.Add(this.tbLsn2);
            this.Controls.Add(this.tbLsn1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Name = "Form3";
            this.Text = "修改";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button insertLsn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.ComboBox comboBox16;
        public System.Windows.Forms.TextBox tbLsn4;
        public System.Windows.Forms.TextBox tbLsn2;
        public System.Windows.Forms.TextBox tbLsn1;
    }
}