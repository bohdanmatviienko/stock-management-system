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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int borderWidth = 3; // Adjust thickness here
            using (Pen dashedPen = new Pen(Color.Black, borderWidth))
            {
                dashedPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash; 

                e.Graphics.DrawRectangle(dashedPen,
                    new Rectangle(borderWidth / 2, borderWidth / 2,
                    panel1.Width - borderWidth, panel1.Height - borderWidth));
            }
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPass.Text.Trim();
            
            if(username == "" || password == "" || confirmPassword == "")
            {
                MessageBox.Show("All fields required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string hashedPassword = SecurityHelper.HashPassword(password);

            try
            {
                using (SqlConnection con = Connection.GetConnection())
                {
                    con.Open();
                    string query = "INSERT INTO [Stock].[dbo].[Login] (Username, Password) VALUES(@Username, @Password)";
                    using(SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", hashedPassword);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
