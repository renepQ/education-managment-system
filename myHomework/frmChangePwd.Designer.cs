namespace myHomework
{
    partial class frmChangePwd
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
            this.tBOldPwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOut = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tBOldPwd
            // 
            this.tBOldPwd.Font = new System.Drawing.Font("宋体", 10F);
            this.tBOldPwd.Location = new System.Drawing.Point(216, 157);
            this.tBOldPwd.Name = "tBOldPwd";
            this.tBOldPwd.PasswordChar = '*';
            this.tBOldPwd.Size = new System.Drawing.Size(170, 30);
            this.tBOldPwd.TabIndex = 23;
            this.tBOldPwd.TextChanged += new System.EventHandler(this.tBOldPwd_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 11F);
            this.label1.Location = new System.Drawing.Point(107, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 22);
            this.label1.TabIndex = 19;
            this.label1.Text = "旧密码";
            // 
            // buttonOut
            // 
            this.buttonOut.Location = new System.Drawing.Point(216, 241);
            this.buttonOut.Name = "buttonOut";
            this.buttonOut.Size = new System.Drawing.Size(110, 34);
            this.buttonOut.TabIndex = 18;
            this.buttonOut.Text = "确定";
            this.buttonOut.UseVisualStyleBackColor = true;
            this.buttonOut.Click += new System.EventHandler(this.buttonOut_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 18);
            this.label2.TabIndex = 24;
            this.label2.Text = "请输入原始密码：";
            // 
            // frmChangePwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 416);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tBOldPwd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOut);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmChangePwd";
            this.Text = "修改密码";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tBOldPwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOut;
        private System.Windows.Forms.Label label2;
    }
}