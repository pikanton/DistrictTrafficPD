using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Reports
{
    public partial class ReportForm : Form
    {
        string connectionString =
            @"Data Source=WIN-60HHAKN0QQ0\SQLEXPRESS;
              Initial Catalog=StudTraining;Integrated Security=True";
        string queryString = @"SELECT * FROM КоличествоПроступковСтудентов";
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Fill(dataTable);
            }
            reportViewer.Reset();
            ReportDataSource ds = new ReportDataSource("MainDataSet", dataTable);
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(ds);
            reportViewer.LocalReport.ReportPath = @"../../../../Reports/Report1.rdlc";
            reportViewer.RefreshReport();
        }

    }
}
