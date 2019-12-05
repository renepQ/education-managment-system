namespace myHomework
{
    partial class frmIn
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIn));
            this.labelID = new System.Windows.Forms.Label();
            this.labelPW = new System.Windows.Forms.Label();
            this.tBID = new System.Windows.Forms.TextBox();
            this.tBPassword = new System.Windows.Forms.TextBox();
            this.buttonIn = new System.Windows.Forms.Button();
            this.buttonOut = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.rBStu = new System.Windows.Forms.RadioButton();
            this.rBTch = new System.Windows.Forms.RadioButton();
            this.rBMG = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.BackColor = System.Drawing.Color.Transparent;
            this.labelID.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelID.Location = new System.Drawing.Point(177, 172);
            this.labelID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(82, 24);
            this.labelID.TabIndex = 0;
            this.labelID.Text = "用户名";
            // 
            // labelPW
            // 
            this.labelPW.AutoSize = true;
            this.labelPW.BackColor = System.Drawing.Color.Transparent;
            this.labelPW.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPW.Location = new System.Drawing.Point(187, 247);
            this.labelPW.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPW.Name = "labelPW";
            this.labelPW.Size = new System.Drawing.Size(58, 24);
            this.labelPW.TabIndex = 1;
            this.labelPW.Text = "密码";
            // 
            // tBID
            // 
            this.tBID.Location = new System.Drawing.Point(304, 165);
            this.tBID.Margin = new System.Windows.Forms.Padding(4);
            this.tBID.Name = "tBID";
            this.tBID.Size = new System.Drawing.Size(178, 28);
            this.tBID.TabIndex = 2;
            // 
            // tBPassword
            // 
            this.tBPassword.Location = new System.Drawing.Point(304, 243);
            this.tBPassword.Margin = new System.Windows.Forms.Padding(4);
            this.tBPassword.Name = "tBPassword";
            this.tBPassword.PasswordChar = '*';
            this.tBPassword.Size = new System.Drawing.Size(178, 28);
            this.tBPassword.TabIndex = 3;
            this.tBPassword.TextChanged += new System.EventHandler(this.tBPassword_TextChanged);
            // 
            // buttonIn
            // 
            this.buttonIn.Location = new System.Drawing.Point(182, 398);
            this.buttonIn.Margin = new System.Windows.Forms.Padding(4);
            this.buttonIn.Name = "buttonIn";
            this.buttonIn.Size = new System.Drawing.Size(128, 45);
            this.buttonIn.TabIndex = 4;
            this.buttonIn.Text = "登录";
            this.buttonIn.UseVisualStyleBackColor = true;
            this.buttonIn.Click += new System.EventHandler(this.buttonIn_Click);
            // 
            // buttonOut
            // 
            this.buttonOut.Location = new System.Drawing.Point(382, 398);
            this.buttonOut.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOut.Name = "buttonOut";
            this.buttonOut.Size = new System.Drawing.Size(128, 45);
            this.buttonOut.TabIndex = 5;
            this.buttonOut.Text = "取消";
            this.buttonOut.UseVisualStyleBackColor = true;
            this.buttonOut.Click += new System.EventHandler(this.buttonOut_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("华文新魏", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTitle.Location = new System.Drawing.Point(39, 44);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(608, 73);
            this.labelTitle.TabIndex = 9;
            this.labelTitle.Text = "欢迎来到教务系统";
            // 
            // rBStu
            // 
            this.rBStu.AutoSize = true;
            this.rBStu.BackColor = System.Drawing.Color.Transparent;
            this.rBStu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rBStu.Location = new System.Drawing.Point(181, 318);
            this.rBStu.Name = "rBStu";
            this.rBStu.Size = new System.Drawing.Size(69, 22);
            this.rBStu.TabIndex = 10;
            this.rBStu.TabStop = true;
            this.rBStu.Text = "学生";
            this.rBStu.UseVisualStyleBackColor = false;
            // 
            // rBTch
            // 
            this.rBTch.AutoSize = true;
            this.rBTch.BackColor = System.Drawing.Color.Transparent;
            this.rBTch.Location = new System.Drawing.Point(304, 318);
            this.rBTch.Name = "rBTch";
            this.rBTch.Size = new System.Drawing.Size(69, 22);
            this.rBTch.TabIndex = 11;
            this.rBTch.TabStop = true;
            this.rBTch.Text = "教师";
            this.rBTch.UseVisualStyleBackColor = false;
            // 
            // rBMG
            // 
            this.rBMG.AutoSize = true;
            this.rBMG.BackColor = System.Drawing.Color.Transparent;
            this.rBMG.Location = new System.Drawing.Point(423, 318);
            this.rBMG.Name = "rBMG";
            this.rBMG.Size = new System.Drawing.Size(87, 22);
            this.rBMG.TabIndex = 12;
            this.rBMG.TabStop = true;
            this.rBMG.Text = "管理员";
            this.rBMG.UseVisualStyleBackColor = false;
            this.rBMG.CheckedChanged += new System.EventHandler(this.rBMG_CheckedChanged);
            // 
            // frmIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(687, 495);
            this.Controls.Add(this.rBMG);
            this.Controls.Add(this.rBTch);
            this.Controls.Add(this.rBStu);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.buttonOut);
            this.Controls.Add(this.buttonIn);
            this.Controls.Add(this.tBPassword);
            this.Controls.Add(this.tBID);
            this.Controls.Add(this.labelPW);
            this.Controls.Add(this.labelID);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmIn";
            this.Text = "教务管理系统";
            this.Load += new System.EventHandler(this.frmIn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label labelPW;
        private System.Windows.Forms.TextBox tBID;
        private System.Windows.Forms.TextBox tBPassword;
        private System.Windows.Forms.Button buttonIn;
        private System.Windows.Forms.Button buttonOut;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.RadioButton rBStu;
        private System.Windows.Forms.RadioButton rBTch;
        private System.Windows.Forms.RadioButton rBMG;
    }
}

