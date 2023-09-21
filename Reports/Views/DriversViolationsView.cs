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
    public partial class DriversViolationsView : Form
    {
        string connectionString = @"Data Source=WIN-I8NPL89GTIE;" +
                                         @"Initial Catalog=ГАИ2;Integrated Security=True";
        string queryString = @"EXEC СуммаНарушенийВодителейЗаПериод @Begin, @End";
        DateTime? beginDate;
        DateTime? endDate;
        public DriversViolationsView(DateTime? beginDate, DateTime? endDate)
        {
            this.beginDate = beginDate;
            this.endDate = endDate;
            InitializeComponent();
        }

        private void DriversViolationsView_Load(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                if (beginDate == null && endDate == null)
                {
                    sqlCommand.Parameters.AddWithValue("@Begin", DBNull.Value);
                    sqlCommand.Parameters.AddWithValue("@End", DBNull.Value);
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue("@Begin", beginDate);
                    sqlCommand.Parameters.AddWithValue("@End", endDate);
                }
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Fill(dataTable);
            }
            reportViewer.Reset();
            ReportDataSource ds = new ReportDataSource("DriversViolationsDataSet", dataTable);
            reportViewer.LocalReport.DataSources.Clear();   
            reportViewer.LocalReport.DataSources.Add(ds);
            reportViewer.LocalReport.ReportPath = @"D:\study\CourseProject\Reports\Reports\DriversViolationsReport.rdlc";
            string text;
            if (beginDate == null && endDate == null)
            {
                text = "Сумма штрафов водителей за всё время"; 
            }
            else
            {
                text = $"Сумма штрафов водителей за период от\n" +
                       $"{beginDate?.ToString("dd/MM/yyyy")} до {endDate?.Date.ToString("dd/MM/yyyy")}";

            }
            ReportParameter textParameter = new ReportParameter("Text", text);
            reportViewer.LocalReport.SetParameters(textParameter);
            reportViewer.RefreshReport();
        }
    }
}
