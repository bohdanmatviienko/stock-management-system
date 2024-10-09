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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPassword.Clear();
            txtUserName.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=BAN-B5-WK-007;Initial Catalog=Stock;Integrated Security=True;");
            SqlDataAdapter sda = new SqlDataAdapter(@"SELECT * FROM [Stock].[dbo].[Login] where UserName = '" + txtUserName.Text + "' and Password = '" + txtPassword.Text + "'", con);
            
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                this.Hide();
                StockMain main = new StockMain();
                main.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username & Password..!", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                btnClear_Click(sender, e);
            }
        }
    }
}
