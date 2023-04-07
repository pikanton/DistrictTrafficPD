using System.Data.SqlClient;

namespace WinFormsApp1
{
    internal class DBContext
    {
        private static readonly string connectionString = @"Data Source=WIN-I8NPL89GTIE;" +
                                          @"Initial Catalog=ГАИ2;Integrated Security=True";
        private static SqlConnection? connection;

        public static SqlConnection? Connection => connection;
        public static void OpenConnection()
        {
            if (connection?.State != System.Data.ConnectionState.Open)
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
            }
        }
        public static void CloseConnection()
        {
            if (connection?.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
    }
}
