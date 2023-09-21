using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Reports.Views
{
    public partial class EmployeeStatView : Form
    {
        string connectionString = @"Data Source=WIN-I8NPL89GTIE;" +
                                         @"Initial Catalog=ГАИ2;Integrated Security=True";
        string queryString = @"SELECT * FROM ЭффективностьСотрудниковЗаПоследнийМесяц";
        public EmployeeStatView()
        {
            InitializeComponent();
        }

        private void EmployeeStatView_Load(object sender, EventArgs e)
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
            ReportDataSource ds = new ReportDataSource("EmployeeStatDataSet", dataTable);
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(ds);
            reportViewer.LocalReport.ReportPath = @"D:\study\CourseProject\Reports\Reports\EmployeeStatReport.rdlc";
            reportViewer.RefreshReport();
        }
    }
}
