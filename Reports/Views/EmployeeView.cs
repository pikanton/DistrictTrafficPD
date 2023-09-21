using Microsoft.Reporting.WinForms;
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

namespace Reports.Views
{
    public partial class EmployeeView : Form
    {
        string connectionString = @"Data Source=WIN-I8NPL89GTIE;" +
                                         @"Initial Catalog=ГАИ2;Integrated Security=True";
        string queryString = @"SELECT * FROM СотрудникОтчет";
        public EmployeeView()
        {
            InitializeComponent();
        }

        private void EmployeeView_Load(object sender, EventArgs e)
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
            ReportDataSource ds = new ReportDataSource("EmployeeDataSet", dataTable);
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(ds);
            reportViewer.LocalReport.ReportPath = @"D:\study\CourseProject\Reports\Reports\EmployeeReport.rdlc";
            reportViewer.RefreshReport();
        }
    }
}
