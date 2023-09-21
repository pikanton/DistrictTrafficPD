using Reports.Forms;
using Reports.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reports
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] Args)
        {
            SqlServerTypes.Utilities.LoadNativeAssemblies(AppDomain.CurrentDomain.BaseDirectory);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Args.Length > 0)
            {
                switch (Args[0])
                {
                    case "DriversViolationsForThePeriod":
                        Application.Run(new DriversViolationsForThePeriod());
                        break;
                    case "EmployeeView":
                        Application.Run(new EmployeeView());
                        break;
                    case "EmployeeStatView":
                        Application.Run(new EmployeeStatView());
                        break;
                }
            }
            else
            {
                Application.Run(new EmployeeStatView());
            }
        }
    }
}
