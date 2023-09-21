using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.Diagnostics.Internal;
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

namespace Reports
{
    public partial class ViolationReport : Form
    {
        string connectionString = @"Data Source=WIN-I8NPL89GTIE;" +
                                          @"Initial Catalog=ГАИ2;Integrated Security=True";
        string queryString = @"SELECT * FROM ТестОтчета";
        public ViolationReport()
        {
            InitializeComponent();
        }

        private void ViolationReport_Load(object sender, EventArgs e)
        {
            
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(queryString, conn);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Fill(dataTable);
            }
            reportViewer.Reset();
            ReportDataSource ds = new ReportDataSource("TestDataSet", dataTable);
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(ds);
            reportViewer.LocalReport.ReportPath = @"D:\study\CourseProject\Reports\Report1.rdlc";
            reportViewer.RefreshReport();
            }
    }
}
