namespace clientExample
{
    partial class FormRegister
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
            this.groupRegister = new System.Windows.Forms.GroupBox();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.textPass = new System.Windows.Forms.TextBox();
            this.textConfirmPass = new System.Windows.Forms.TextBox();
            this.textNick = new System.Windows.Forms.TextBox();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.linkNickHelp = new System.Windows.Forms.LinkLabel();
            this.labelRegister = new System.Windows.Forms.Label();
            this.groupRegister.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupRegister
            // 
            this.groupRegister.Controls.Add(this.labelRegister);
            this.groupRegister.Controls.Add(this.linkNickHelp);
            this.groupRegister.Controls.Add(this.label4);
            this.groupRegister.Controls.Add(this.label3);
            this.groupRegister.Controls.Add(this.label2);
            this.groupRegister.Controls.Add(this.label1);
            this.groupRegister.Controls.Add(this.buttonRegister);
            this.groupRegister.Controls.Add(this.textNick);
            this.groupRegister.Controls.Add(this.textConfirmPass);
            this.groupRegister.Controls.Add(this.textPass);
            this.groupRegister.Controls.Add(this.textEmail);
            this.groupRegister.Location = new System.Drawing.Point(6, 6);
            this.groupRegister.Name = "groupRegister";
            this.groupRegister.Size = new System.Drawing.Size(270, 161);
            this.groupRegister.TabIndex = 0;
            this.groupRegister.TabStop = false;
            this.groupRegister.Text = "Register";
            // 
            // textEmail
            // 
            this.textEmail.Location = new System.Drawing.Point(106, 26);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(156, 20);
            this.textEmail.TabIndex = 1;
            // 
            // textPass
            // 
            this.textPass.Location = new System.Drawing.Point(106, 52);
            this.textPass.Name = "textPass";
            this.textPass.Size = new System.Drawing.Size(156, 20);
            this.textPass.TabIndex = 2;
            this.textPass.UseSystemPasswordChar = true;
            // 
            // textConfirmPass
            // 
            this.textConfirmPass.Location = new System.Drawing.Point(106, 78);
            this.textConfirmPass.Name = "textConfirmPass";
            this.textConfirmPass.Size = new System.Drawing.Size(156, 20);
            this.textConfirmPass.TabIndex = 3;
            this.textConfirmPass.UseSystemPasswordChar = true;
            // 
            // textNick
            // 
            this.textNick.Location = new System.Drawing.Point(106, 104);
            this.textNick.Name = "textNick";
            this.textNick.Size = new System.Drawing.Size(156, 20);
            this.textNick.TabIndex = 7;
            // 
            // buttonRegister
            // 
            this.buttonRegister.Location = new System.Drawing.Point(9, 130);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(253, 23);
            this.buttonRegister.TabIndex = 0;
            this.buttonRegister.Text = "Submit";
            this.buttonRegister.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Confirm Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nickname:";
            // 
            // linkNickHelp
            // 
            this.linkNickHelp.AutoSize = true;
            this.linkNickHelp.Location = new System.Drawing.Point(60, 107);
            this.linkNickHelp.Name = "linkNickHelp";
            this.linkNickHelp.Size = new System.Drawing.Size(13, 13);
            this.linkNickHelp.TabIndex = 9;
            this.linkNickHelp.TabStop = true;
            this.linkNickHelp.Text = "?";
            // 
            // labelRegister
            // 
            this.labelRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRegister.Location = new System.Drawing.Point(-4, 0);
            this.labelRegister.Name = "labelRegister";
            this.labelRegister.Size = new System.Drawing.Size(274, 161);
            this.labelRegister.TabIndex = 10;
            this.labelRegister.Text = "Registering...";
            this.labelRegister.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelRegister.Visible = false;
            // 
            // FormRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 174);
            this.Controls.Add(this.groupRegister);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.groupRegister.ResumeLayout(false);
            this.groupRegister.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupRegister;
        private System.Windows.Forms.LinkLabel linkNickHelp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.TextBox textNick;
        private System.Windows.Forms.TextBox textConfirmPass;
        private System.Windows.Forms.TextBox textPass;
        private System.Windows.Forms.TextBox textEmail;
        public System.Windows.Forms.Label labelRegister;
    }
}