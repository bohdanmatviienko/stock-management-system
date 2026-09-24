using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Stock1
{
    public partial class Stock : Form
    {
        public Stock()
        {
            InitializeComponent();
        }
        private void Stock_Load(object sender, EventArgs e)
        {
            this.ActiveControl = dateTimePicker1;
            cmbStatus.SelectedIndex = 0;
            LoadData();
            Search();
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtProductCode.Focus();
            }
        }

        private void txtProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtProductCode.Text.Length > 0)
                {
                    txtProductCode.Text = dgview.SelectedRows[0].Cells[0].Value.ToString();
                    txtProductName.Text = dgview.SelectedRows[0].Cells[1].Value.ToString();
                    this.dgview.Visible = false;
                    txtQuantity.Focus();
                }
                else
                {
                    dgview.Visible = false;
                }
            }
        }

        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtProductName.Text.Length > 0)
                {
                    txtQuantity.Focus();
                }
                else
                {
                    txtProductName.Focus();
                }
            }
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtQuantity.Text.Length > 0)
                {
                    cmbStatus.Focus();
                }
                else
                {
                    txtQuantity.Focus();
                }
            }
        }

        private void txtProductCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
        private void ResetRecords()
        {
            dateTimePicker1.Value = DateTime.Now;
            txtProductCode.Clear();
            txtProductName.Clear();
            txtQuantity.Clear();
            cmbStatus.SelectedIndex = -1;
            btnAdd.Text = "Add";
            dateTimePicker1.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetRecords();
        }
        private bool Validation()
        {
            bool result = false;
            if (string.IsNullOrEmpty(txtProductCode.Text))
            {
                // in design added errorProvider1
                errorProvider1.Clear();
                errorProvider1.SetError(txtProductCode, "Product Code Required");
            }
            else if (string.IsNullOrEmpty(txtProductName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtProductName, "Product Name Required");
            }
            else if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtQuantity, "A Quantity is required");
            }
            else if (cmbStatus.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cmbStatus, "Select Status");
            }
            else
            {
                errorProvider1.Clear();
                result = true;
            }
            return result;
        }
        private bool IfProductExists(SqlConnection con, string productCode)
        {
            SqlDataAdapter sda = new SqlDataAdapter(@"Select 1 From [Stock] WHERE
                    [ProductCode] = '" + productCode + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                SqlConnection con = Connection.GetConnection();

                con.Open();
                bool status = false;
                if (cmbStatus.SelectedIndex == 0)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
                string sqlQuery;

                if (IfProductExists(con, txtProductCode.Text))
                {
                    sqlQuery = @"UPDATE [Stock]
                            SET [ProductName] = '" + txtProductName.Text + "' ,[Quantity] = '" + txtQuantity.Text + "', [ProductStatus] = '" + status + "' " +
                            "WHERE [ProductCode] = '" + txtProductCode.Text + "'";
                }
                else
                {
                    sqlQuery = @"INSERT INTO Stock (ProductCode, ProductName, TransDate, Quantity, ProductStatus) 
                                    VALUES('" + txtProductCode.Text + "', '" + txtProductName.Text + "', '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "'" +
                                    " ,'" + txtQuantity.Text + "' , '" + status + "')";
                }
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Saved Successfully");
                ResetRecords();
                LoadData();
            }
        }
        public void LoadData()
        {
            {
                SqlConnection con = Connection.GetConnection();
                SqlDataAdapter sda = new SqlDataAdapter("Select * From [Stock].[dbo].[Stock]", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvStock.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = dgvStock.Rows.Add();
                    dgvStock.Rows[n].Cells["dgSno"].Value = n + 1;
                    dgvStock.Rows[n].Cells["dgProCode"].Value = item["ProductCode"].ToString();
                    dgvStock.Rows[n].Cells["dgProName"].Value = item["ProductName"].ToString();
                    dgvStock.Rows[n].Cells["dgQuantity"].Value = float.Parse(item["Quantity"].ToString());
                    dgvStock.Rows[n].Cells["dgDate"].Value = Convert.ToDateTime(item["TransDate"].ToString()).ToString("dd/MM/yyyy");

                    if ((bool)item["ProductStatus"])
                    {
                        dgvStock.Rows[n].Cells["dgStatus"].Value = "Active";
                    }
                    else
                    {
                        dgvStock.Rows[n].Cells["dgStatus"].Value = "Inactive";
                    }
                }
            }
            if(dgvStock.Rows.Count > 0)
            {
                lblTPResults.Text = dgvStock.Rows.Count.ToString();

                float totQty = 0;
                for (int i = 0; i < dgvStock.Rows.Count; ++i)
                {
                    totQty += float.Parse(dgvStock.Rows[i].Cells["dgQuantity"].Value.ToString());
                    lblTQResult.Text = totQty.ToString();
                }
            }
            else
            {
                lblTQResult.Text = "0";
                lblTQResult.Text = "0";
            }
        }

        private void dgvStock_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnAdd.Text = "Update";
            txtProductCode.Text = dgvStock.SelectedRows[0].Cells["dgProCode"].Value.ToString();
            txtProductName.Text = dgvStock.SelectedRows[0].Cells["dgProName"].Value.ToString();
            txtQuantity.Text = dgvStock.SelectedRows[0].Cells["dgQuantity"].Value.ToString();
            dateTimePicker1.Text = DateTime.Parse(dgvStock.SelectedRows[0].Cells["dgDate"].Value.ToString()).ToString("dd/MM/yyyy");
            if (dgvStock.SelectedRows[0].Cells["dgStatus"].Value.ToString() == "Active")
            {
                cmbStatus.SelectedIndex = 0;
            }
            else
            {
                cmbStatus.SelectedIndex = 1;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Message", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (Validation())
                {
                    SqlConnection con = Connection.GetConnection();
                    var sqlQuery = "";
                    if (IfProductExists(con, txtProductCode.Text))
                    {
                        con.Open();
                        sqlQuery = @"DELETE FROM [Stock] WHERE [ProductCode] = '" + txtProductCode.Text + "'";
                        SqlCommand cmd = new SqlCommand(sqlQuery, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record deleted successfully ");
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("No record found with that product code");
                    }
                    LoadData();
                } 
            }
        }
        private DataGridView dgview;
        private DataGridViewTextBoxColumn dgviewcol1;
        private DataGridViewTextBoxColumn dgviewcol2;

        void Search()
        {
            // create
            dgview = new DataGridView();
            dgviewcol1 = new DataGridViewTextBoxColumn();
            dgviewcol2 = new DataGridViewTextBoxColumn();
            //set values
            this.dgview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.dgviewcol1, this.dgviewcol2 });
            this.dgview.Name = "dgview";
            dgview.Visible = false;
            this.dgviewcol1.Visible = false;
            this.dgviewcol2.Visible = false;
            this.dgview.AllowUserToAddRows = false;
            this.dgview.RowHeadersVisible = false;
            this.dgview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            //add to the form
            this.Controls.Add(dgview);
            this.dgview.ReadOnly = true;
            dgview.BringToFront();
        }
        void Search(int LX, int LY, int DW, int DH, string ColName, String ColSize)
        {
            this.dgview.Location = new System.Drawing.Point(LX, LY);
            this.dgview.Size = new System.Drawing.Size(DW, DH);

            string[] CLsize = ColSize.Split(',');
            for (int i = 0; i < CLsize.Length; i++)
            {
                if (int.Parse(CLsize[i]) != 0)
                {
                    dgview.Columns[i].Width = int.Parse(CLsize[i]);
                }
                else
                {
                    dgview.Columns[i].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            string[] CLName = ColName.Split(',');

            for (int i = 0; i < CLName.Length; i++)
            {
                this.dgview.Columns[i].HeaderText = CLName[i];
                this.dgview.Columns[i].Visible = true;
            }
        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {
            if (txtProductCode.Text.Length > 0)
            {
                this.dgview.Visible = true;
                dgview.BringToFront();
                Search(275,180, 430, 200, "Pro Code, Pro Name", "100,0");
                this.dgview.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.proCode_MouseDoubleClick);
                SqlConnection con = Connection.GetConnection();
                SqlDataAdapter sda = new SqlDataAdapter("Select Top(10) ProductCode, ProductName From [Products]" +
                    " Where [ProductCode] Like '" + txtProductCode.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgview.Rows.Clear();
                foreach(DataRow row in dt.Rows)
                {
                    int n = dgview.Rows.Add();
                    dgview.Rows[n].Cells[0].Value = row["ProductCode"].ToString();
                    dgview.Rows[n].Cells[1].Value = row["ProductName"].ToString();
                }
            }
            else
            {
                dgview.Visible = false;
            }
        }
        bool change = true;
        private void proCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (change)
            {
                change = false;
                txtProductCode.Text = dgview.SelectedRows[0].Cells[0].Value.ToString();
                txtProductName.Text = dgview.SelectedRows[0].Cells[1].Value.ToString();
                this.dgview.Visible = false;
                txtQuantity.Focus();
                change = true;
            }
        }
    }
}
