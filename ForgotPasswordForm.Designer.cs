namespace Stock1
{
    partial class ForgotPasswordForm
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
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.btnSendReset = new System.Windows.Forms.Button();
            this.lblForgotPass = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblEmail.Location = new System.Drawing.Point(80, 82);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(161, 20);
            this.lblEmail.TabIndex = 0;
            this.lblEmail.Text = "Enter your username:";
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtUser.Location = new System.Drawing.Point(247, 82);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(92, 26);
            this.txtUser.TabIndex = 1;
            // 
            // btnSendReset
            // 
            this.btnSendReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSendReset.Location = new System.Drawing.Point(84, 122);
            this.btnSendReset.Name = "btnSendReset";
            this.btnSendReset.Size = new System.Drawing.Size(255, 33);
            this.btnSendReset.TabIndex = 2;
            this.btnSendReset.Text = "Reset password";
            this.btnSendReset.UseVisualStyleBackColor = true;
            this.btnSendReset.Click += new System.EventHandler(this.btnSendReset_Click);
            // 
            // lblForgotPass
            // 
            this.lblForgotPass.AutoSize = true;
            this.lblForgotPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblForgotPass.Location = new System.Drawing.Point(147, 45);
            this.lblForgotPass.Name = "lblForgotPass";
            this.lblForgotPass.Size = new System.Drawing.Size(142, 20);
            this.lblForgotPass.TabIndex = 3;
            this.lblForgotPass.Text = "Forgot Password ?";
            // 
            // ForgotPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 215);
            this.Controls.Add(this.lblForgotPass);
            this.Controls.Add(this.btnSendReset);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblEmail);
            this.Name = "ForgotPasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Forgot Password ";
            this.Load += new System.EventHandler(this.ForgotPasswordForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Button btnSendReset;
        private System.Windows.Forms.Label lblForgotPass;
    }
}