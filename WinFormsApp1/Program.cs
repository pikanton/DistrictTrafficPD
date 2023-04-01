using GAI.Forms;

namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            try
            {
                DBContext.OpenConnection();
                DBContext.CloseConnection();
                ApplicationConfiguration.Initialize();
                Application.Run(new AuthorizationForm());
            }
            catch
            {
                MessageBox.Show(
                    "Не удается установить соеденение с базой данных. Попробуйте позже."
                    , "Ошибка"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error
                    , MessageBoxDefaultButton.Button1
                    );
            }
        }
    }
}