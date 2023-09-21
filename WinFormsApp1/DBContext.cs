using System.Data.SqlClient;

namespace WinFormsApp1
{
    public class DBContext
    {
        private static readonly string connectionString = @"Data Source=WIN-I8NPL89GTIE;" +
                                          @"Initial Catalog=ГАИ2;Integrated Security=True";
        private readonly SqlConnection? connection;
        public SqlConnection? Connection => connection;
        public DBContext()
        {
            try
            {
                if (connection?.State != System.Data.ConnectionState.Open)
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                }
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
