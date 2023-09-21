using GAI.Classes;
using GAI.Repository;
using WinFormsApp1;

namespace GAI.Forms
{
    public partial class IUEmployeeForm : Form
    {
        private DBContext context;
        private Employee employee;
        private bool isEnabledRole;
        private int IUstatus; //0 если форма открыта на добавление, 1 если на изменение
        public IUEmployeeForm(DBContext context, Employee? employee = null, bool isEnabledRole = false)
        {
            this.context = context;
            this.isEnabledRole = isEnabledRole;
            if (employee != null)
            {
                this.employee = employee;
                IUstatus = 1;
            }
            else
            {
                this.employee = new Employee();
                IUstatus = 0;
            }
            InitializeComponent();
        }
        private void IUEmployeeForm_Load(object sender, EventArgs e)
        {
            rangCB.Items.Clear();
            RangRepository rangRepository = new(context);
            rangCB.Items.AddRange(rangRepository.GetAllTitles());
            roleCB.Items.Clear();
            EmployeeRepository employeeRepository = new(context);
            roleCB.Items.AddRange(employeeRepository.GetAllRoles());
            rangCB.SelectedIndex = 0;
            roleCB.SelectedIndex = 0;
            if (IUstatus == 0)
            {
                Text = "Регистрация сотрудника";
                passwordLabel.Text = "Пароль";
            }
            else if (IUstatus == 1)
            {
                Text = "Изменение сотрудника";
                passwordLabel.Text = "Пароль (оставьте пустым, что бы не вносить изменения)";
                surnameText.Text = employee.Surname;
                nameText.Text = employee.Name;
                patronymicText.Text = employee.Patronymic;
                phoneNumberText.Text = employee.PhoneNumber;
                userNameText.Text = employee.UserName;
                rangCB.Text = employee.RangTitle;
                roleCB.Text = employee.Role;
            }
            roleCB.Enabled = isEnabledRole;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            EmployeeRepository employeeRepository = new(context);
            try
            {
                employee.Surname = surnameText.Text;
                employee.Name = nameText.Text;
                employee.Patronymic = patronymicText.Text;
                employee.PhoneNumber = phoneNumberText.Text;
                employee.UserName = userNameText.Text;
                if (IUstatus != 1 || !string.IsNullOrEmpty(passwordText.Text))
                {
                    employee.Password = passwordText.Text;
                }
                RangRepository rangRepository = new(context);
                employee.RangId = rangRepository.GetByTitle(rangCB.Text).Id;
                employee.RoleId = employeeRepository.GetRoleIdByTitle(roleCB.Text);
            }
            catch (OverflowException)
            {
                MessageBox.Show("Слишком большое значение в численных полях!", "Ошибка", MessageBoxButtons.OK
                               , MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверно указаны численные поля!", "Ошибка", MessageBoxButtons.OK
                               , MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK
                               , MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            if (IUstatus == 0)
            {
                employeeRepository.Add(employee);
            }
            else if (IUstatus == 1)
            {
                employeeRepository.Update(employee);
            }
            Close();
        }
    }
}
