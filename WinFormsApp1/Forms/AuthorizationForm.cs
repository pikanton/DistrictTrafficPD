using GAI.Classes;
using GAI.Repository;
using System.Data.SqlClient;
using WinFormsApp1;

namespace GAI.Forms
{
    public partial class AuthorizationForm : Form
    {
        public DBContext context;
        public AuthorizationForm()
        {
            context = new DBContext();
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string username = loginBox.Text.Trim();
            string password = passwordBox.Text;
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Введите имя пользователя!");
                return;
            }
            else if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите пароль!");
                return;
            }
            EmployeeRepository employeeRepository = new(context);
            Employee? employee = employeeRepository.Authorize(username, password);
            if (employee != null)
            {
                MainForm mainForm = new(employee, context);
                mainForm.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль. Проверьте введенные данные!");
            }
        }
        private void passwordBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                submitButton_Click(sender, e);
            }
        }

        private void loginBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                submitButton_Click(sender, e);
            }
        }
    }
}
