namespace Stock1
{
    partial class ResetPasswordForm
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
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.lblConfPass = new System.Windows.Forms.Label();
            this.lblNewPass = new System.Windows.Forms.Label();
            this.txtConfPass = new System.Windows.Forms.TextBox();
            this.lblResPass = new System.Windows.Forms.Label();
            this.btnSaveNewPass = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNewPass
            // 
            this.txtNewPass.Location = new System.Drawing.Point(188, 96);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.PasswordChar = '*';
            this.txtNewPass.Size = new System.Drawing.Size(144, 26);
            this.txtNewPass.TabIndex = 1;
            // 
            // lblConfPass
            // 
            this.lblConfPass.AutoSize = true;
            this.lblConfPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfPass.Location = new System.Drawing.Point(110, 153);
            this.lblConfPass.Name = "lblConfPass";
            this.lblConfPass.Size = new System.Drawing.Size(141, 20);
            this.lblConfPass.TabIndex = 2;
            this.lblConfPass.Text = "Confirm Password:";
            // 
            // lblNewPass
            // 
            this.lblNewPass.AutoSize = true;
            this.lblNewPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPass.Location = new System.Drawing.Point(110, 115);
            this.lblNewPass.Name = "lblNewPass";
            this.lblNewPass.Size = new System.Drawing.Size(116, 20);
            this.lblNewPass.TabIndex = 3;
            this.lblNewPass.Text = "New password:";
            // 
            // txtConfPass
            // 
            this.txtConfPass.Location = new System.Drawing.Point(188, 134);
            this.txtConfPass.Name = "txtConfPass";
            this.txtConfPass.PasswordChar = '*';
            this.txtConfPass.Size = new System.Drawing.Size(144, 26);
            this.txtConfPass.TabIndex = 4;
            // 
            // lblResPass
            // 
            this.lblResPass.AutoSize = true;
            this.lblResPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResPass.Location = new System.Drawing.Point(129, 46);
            this.lblResPass.Name = "lblResPass";
            this.lblResPass.Size = new System.Drawing.Size(125, 20);
            this.lblResPass.TabIndex = 0;
            this.lblResPass.Text = "Reset Password";
            // 
            // btnSaveNewPass
            // 
            this.btnSaveNewPass.Location = new System.Drawing.Point(45, 172);
            this.btnSaveNewPass.Name = "btnSaveNewPass";
            this.btnSaveNewPass.Size = new System.Drawing.Size(287, 32);
            this.btnSaveNewPass.TabIndex = 7;
            this.btnSaveNewPass.Text = "Save new password";
            this.btnSaveNewPass.UseVisualStyleBackColor = true;
            this.btnSaveNewPass.Click += new System.EventHandler(this.btnSaveNewPass_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtConfPass);
            this.panel1.Controls.Add(this.btnSaveNewPass);
            this.panel1.Controls.Add(this.lblResPass);
            this.panel1.Controls.Add(this.txtNewPass);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(69, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 229);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // ResetPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 298);
            this.Controls.Add(this.lblNewPass);
            this.Controls.Add(this.lblConfPass);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ResetPasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reset your password here";
            this.Load += new System.EventHandler(this.ResetPasswordForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.Label lblConfPass;
        private System.Windows.Forms.Label lblNewPass;
        private System.Windows.Forms.TextBox txtConfPass;
        private System.Windows.Forms.Label lblResPass;
        private System.Windows.Forms.Button btnSaveNewPass;
        private System.Windows.Forms.Panel panel1;
    }
}