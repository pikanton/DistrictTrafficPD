using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using WinFormsApp1;

namespace GAI.Forms
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string login = loginBox.Text.Trim();
            string password = passwordBox.Text;
            SHA256 sha256 = SHA256.Create();
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            string hashedPassword = Convert.ToBase64String(hashedBytes);

            string query = Queries.Login;
            using (DBContext.Connection)
            {
                DBContext.OpenConnection();
                using (SqlCommand command = new(query, DBContext.Connection))
                {
                    command.Parameters.AddWithValue("@login", login);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        string? dbPassword = reader["Пароль"].ToString();
                        if (hashedPassword.Equals(dbPassword))
                        {
                            MainForm mainForm = new((int)reader["Код"]
                                                  , $"{reader["Фамилия"]} {reader["Имя"]} {reader["Отчество"]}"
                                                  , reader["Наименование"].ToString());
                            mainForm.Show();
                            Hide();
                        }
                        else
                        {
                            MessageBox.Show("Неверный пароль. Проверьте введенные данные.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин. Проверьте введенные данные.");
                    }
                }
                DBContext.CloseConnection();
            }

        }
    }
}
