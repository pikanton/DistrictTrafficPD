using Microsoft.Reporting.WinForms;
using Reports.Views;
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

namespace Reports.Forms
{
    public partial class DriversViolationsForThePeriod : Form
    {
        public DriversViolationsForThePeriod()
        {
            InitializeComponent();
        }
        private void subminButton_Click(object sender, EventArgs e)
        {
            DateTime beginDate = beginDateTimePicker.Value.Date;
            DateTime endDate = endDateTimePicker.Value.Date;
            DriversViolationsView driversViolationsView;
            if (checkBox.Checked)
            {
                driversViolationsView = new DriversViolationsView(null, null);
            }
            else
            {
                driversViolationsView = new DriversViolationsView(beginDate, endDate);
            }
            driversViolationsView.ShowDialog();
        }
    }
}
