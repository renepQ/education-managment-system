namespace myHomework
{
    partial class Form4
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
            this.tBNewPwd2 = new System.Windows.Forms.TextBox();
            this.tBNewPwd1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonYes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tBNewPwd2
            // 
            this.tBNewPwd2.Font = new System.Drawing.Font("宋体", 10F);
            this.tBNewPwd2.Location = new System.Drawing.Point(191, 164);
            this.tBNewPwd2.Name = "tBNewPwd2";
            this.tBNewPwd2.PasswordChar = '*';
            this.tBNewPwd2.Size = new System.Drawing.Size(170, 30);
            this.tBNewPwd2.TabIndex = 30;
            // 
            // tBNewPwd1
            // 
            this.tBNewPwd1.Font = new System.Drawing.Font("宋体", 10F);
            this.tBNewPwd1.Location = new System.Drawing.Point(191, 97);
            this.tBNewPwd1.Name = "tBNewPwd1";
            this.tBNewPwd1.PasswordChar = '*';
            this.tBNewPwd1.Size = new System.Drawing.Size(170, 30);
            this.tBNewPwd1.TabIndex = 29;
            this.tBNewPwd1.TextChanged += new System.EventHandler(this.tBNewPwd1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("黑体", 11F);
            this.label3.Location = new System.Drawing.Point(44, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 22);
            this.label3.TabIndex = 28;
            this.label3.Text = "确认新密码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("黑体", 11F);
            this.label2.Location = new System.Drawing.Point(65, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 22);
            this.label2.TabIndex = 27;
            this.label2.Text = "新密码";
            // 
            // buttonYes
            // 
            this.buttonYes.Location = new System.Drawing.Point(123, 236);
            this.buttonYes.Name = "buttonYes";
            this.buttonYes.Size = new System.Drawing.Size(110, 34);
            this.buttonYes.TabIndex = 26;
            this.buttonYes.Text = "确认";
            this.buttonYes.UseVisualStyleBackColor = true;
            this.buttonYes.Click += new System.EventHandler(this.buttonYes_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 357);
            this.Controls.Add(this.tBNewPwd2);
            this.Controls.Add(this.tBNewPwd1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonYes);
            this.Name = "Form4";
            this.Text = "Form4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tBNewPwd2;
        private System.Windows.Forms.TextBox tBNewPwd1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonYes;
    }
}