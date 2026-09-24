using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock1
{
    public partial class ResetPasswordForm : Form
    {
        private string username;
        public ResetPasswordForm(string user)
        {
            InitializeComponent();
            username = user;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int borderWidth = 3; // Adjust thickness here
            using (Pen dashedPen = new Pen(Color.Black, borderWidth))
            {
                dashedPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash; // Set dashed style

                // Draw rectangle border
                e.Graphics.DrawRectangle(dashedPen,
                    new Rectangle(borderWidth / 2, borderWidth / 2,
                    panel1.Width - borderWidth, panel1.Height - borderWidth));
            }
        }

        private void btnSaveNewPass_Click(object sender, EventArgs e)
        {
            string newPassword = txtNewPass.Text.Trim();
            string confirmPassword = txtConfPass.Text.Trim();
            
            if(string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Both password fields are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if(newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match, please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string hashedPassword = SecurityHelper.HashPassword(newPassword);

            using (SqlConnection con = Connection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("UPDATE [Stock].[dbo].[Login] SET Password = @newPassword WHERE Username COLLATE Latin1_General_CS_AS = @Username", con);
                cmd.Parameters.AddWithValue("@newPassword", hashedPassword);
                cmd.Parameters.AddWithValue("@Username", username);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Password reset successfull!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error updating password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
        }

        private void ResetPasswordForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }
    }
}
