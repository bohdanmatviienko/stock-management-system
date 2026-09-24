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
using CrystalDecisions.CrystalReports.Engine;
using Stock1.Reports;

namespace Stock1.ReportForms
{
    public partial class ProductsReport : Form
    {
        ReportDocument cryrpt = new ReportDocument();
        public ProductsReport()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            cryrpt = new ReportDocument();
        }

        private void ProductsReport_Load(object sender, EventArgs e)
        {
            cryrpt.Load(@"C:\Users\23073343\OneDrive - Activate Learning\Stock1\Reports\Product.rpt");
            SqlConnection con = Connection.GetConnection();
            con.Open();
            // DataSet dst = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter("Select * From [Products]", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cryrpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = cryrpt;
        }
    }
}
