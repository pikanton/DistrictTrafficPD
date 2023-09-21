using GAI.Forms;
using GAI.Classes;
using GAI.Repository;
using System.Text;
using System.Windows.Forms;
using System;
using System.Reflection;
using System.Diagnostics;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        private Employee _currentEmployee;
        public DBContext context;
        public MainForm(Employee employee, DBContext context)
        {
            _currentEmployee = employee;
            this.context = context;
            InitializeComponent();
        }
        private void HideDgvColumns(ref DataGridView dgv)
        {
            if (dgv.Columns["Код"] != null)
                dgv.Columns["Код"].Visible = false;
            if (dgv.Columns["Код сотрудника"] != null)
                dgv.Columns["Код сотрудника"].Visible = false;
            if (dgv.Columns["Код водителя"] != null)
                dgv.Columns["Код водителя"].Visible = false;
            if (dgv.Columns["Код звания"] != null)
                dgv.Columns["Код звания"].Visible = false;
            if (dgv.Columns["Код нарушения"] != null)
                dgv.Columns["Код нарушения"].Visible = false;
            if (dgv.Columns["Код категории"] != null)
                dgv.Columns["Код категории"].Visible = false;
            if (dgv.Columns["Код автомобиля"] != null)
                dgv.Columns["Код автомобиля"].Visible = false;
            if (dgv.Columns["Код роли"] != null)
                dgv.Columns["Код роли"].Visible = false;
            if (dgv.Columns["Пароль"] != null)
                dgv.Columns["Пароль"].Visible = false;
        }
        private void RestartAllDgv()
        {
            // Работаем с dgv Нарушение
            ViolationRepository violationRepository = new(context);
            dgvViolation.DataSource = violationRepository.GetAll();
            HideDgvColumns(ref dgvViolation);

            // Работаем c dgv Регистрация
            RegistrationRepository registrationRepository = new(context);
            dgvRegistration.DataSource = registrationRepository.GetAll();
            HideDgvColumns(ref dgvRegistration);

            // Работаем c dgv Водительское удостоверение
            LicenseRepository licenseRepository = new(context);
            dgvLicense.DataSource = licenseRepository.GetAll();
            HideDgvColumns(ref dgvLicense);

            // Работаем c dgv Водители
            DriverRepository driverRepository = new(context);
            dgvDrivers.DataSource = driverRepository.GetAll();
            HideDgvColumns(ref dgvDrivers);

            // Работаем c dgv Автомобили
            CarRepository carRepository = new(context);
            dgvCars.DataSource = carRepository.GetAll();
            HideDgvColumns(ref dgvCars);

            // Работаем c dgv Откат
            dgvRollBack.DataSource = registrationRepository.GetRollBackView();
            HideDgvColumns(ref dgvRollBack);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            introductionLabel.Text = $"Текущий сеанс:\nФИО сотурдника:" +
                                     $" {_currentEmployee.Surname} {_currentEmployee.Name} {_currentEmployee.Patronymic}" +
                                     $"\nЗвание сотрудника: {_currentEmployee.RangTitle}";
            switch (_currentEmployee.Role)
            {
                case "admin":
                    tabDirectories.Parent = mainControl;
                    tabRollBack.Parent = mainControl;
                    deleteLicenseExtButton.Visible = true;
                    сотрудникиToolStripMenuItem.Visible = true;
                    эффективностьСотрудниковЗаПоследнийМесяцToolStripMenuItem.Visible = true;
                    break;
                case "user":
                    tabDirectories.Parent = null;
                    tabRollBack.Parent = null;
                    deleteLicenseExtButton.Visible = false;
                    сотрудникиToolStripMenuItem.Visible = false;
                    эффективностьСотрудниковЗаПоследнийМесяцToolStripMenuItem.Visible = false;
                    break;
                default:
                    break;
            }
            directoryCB.SelectedIndex = 0;
            RestartAllDgv();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AuthorizationForm? authorizationForm = Application.OpenForms["AuthorizationForm"] as AuthorizationForm;
            authorizationForm?.Close();
        }

        private void addViolationButton_Click(object sender, EventArgs e)
        {
            IUViolationForm iUViolationForm = new(context, _currentEmployee);
            iUViolationForm.ShowDialog();
            ViolationRepository violationRepository = new(context);
            dgvViolation.DataSource = violationRepository.GetAll();
            HideDgvColumns(ref dgvViolation);
        }

        private void updateViolationButton_Click(object sender, EventArgs e)
        {
            if (dgvViolation.SelectedRows.Count == 1)
            {
                int index = dgvViolation.SelectedRows[0].Index;
                switch (_currentEmployee.Role)
                {
                    case "admin":
                        break;
                    case "user":
                        if ((int)dgvViolation.Rows[index].Cells["Код сотрудника"].Value != _currentEmployee.Id)
                        {
                            MessageBox.Show("Можно изменять только собственные нарушения!"
                                           , "Ошибка"
                                           , MessageBoxButtons.OK
                                           , MessageBoxIcon.Error
                                           , MessageBoxDefaultButton.Button1);
                            return;
                        }
                        break;
                }
                Violation violation = new()
                {
                    Id = (int)dgvViolation.Rows[index].Cells["Код"].Value,
                    Date = (DateTime)dgvViolation.Rows[index].Cells["Дата"].Value,
                    ProtocolNumber = dgvViolation.Rows[index].Cells["№ Протокола"].Value.ToString(),
                    Fine = (decimal)dgvViolation.Rows[index].Cells["Размер штрафа"].Value,
                    TermOfDeprivation = (int)dgvViolation.Rows[index].Cells["Срок лишения прав"].Value,
                    DriverId = (int)dgvViolation.Rows[index].Cells["Код водителя"].Value,
                    EmployeeId = (int)dgvViolation.Rows[index].Cells["Код сотрудника"].Value,
                    TypeId = (int)dgvViolation.Rows[index].Cells["Код нарушения"].Value,
                    DriverFIO = dgvViolation.Rows[index].Cells["ФИО водителя"].Value.ToString(),
                    EmployeeFIO = dgvViolation.Rows[index].Cells["ФИО сотрудника"].Value.ToString(),
                    TypeTitle = dgvViolation.Rows[index].Cells["Нарушение"].Value.ToString()
                };
                IUViolationForm iUViolationForm = new(context, _currentEmployee, violation);
                iUViolationForm.ShowDialog();
                ViolationRepository violationRepository = new(context);
                dgvViolation.DataSource = violationRepository.GetAll();
                HideDgvColumns(ref dgvViolation);
            }
            else
            {
                MessageBox.Show("Выберите строку для изменения!", "Ошибка"
                                , MessageBoxButtons.OK, MessageBoxIcon.Error
                                , MessageBoxDefaultButton.Button1);
            }
        }

        private void deleteViolationButton_Click(object sender, EventArgs e)
        {
            if (dgvViolation.SelectedRows.Count > 0)
            {
                int index = dgvViolation.SelectedRows[0].Index;
                switch (_currentEmployee.Role)
                {
                    case "admin":
                        break;
                    case "user":
                        if ((int)dgvViolation.Rows[index].Cells["Код сотрудника"].Value != _currentEmployee.Id)
                        {
                            MessageBox.Show("Можно удалять только собственные нарушения!"
                                           , "Ошибка"
                                           , MessageBoxButtons.OK
                                           , MessageBoxIcon.Error
                                           , MessageBoxDefaultButton.Button1);
                            return;
                        }
                        break;
                }
                var result = MessageBox.Show("Вы уверены, что хотите удалить эту запись?"
                                           , "Подтверждение"
                                           , MessageBoxButtons.OKCancel
                                           , MessageBoxIcon.Question
                                           , MessageBoxDefaultButton.Button1);
                if (result == DialogResult.OK)
                {
                    int id = (int)dgvViolation.Rows[index].Cells[0].Value;
                    ViolationRepository violationRepository = new(context);
                    violationRepository.Delete(id);
                    dgvViolation.DataSource = violationRepository.GetAll();
                    HideDgvColumns(ref dgvViolation);
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления!", "Ошибка"
                                , MessageBoxButtons.OK, MessageBoxIcon.Error
                                , MessageBoxDefaultButton.Button1);
            }
        }

        private void addRegistrationButton_Click(object sender, EventArgs e)
        {
            IURegistrationForm iURegistrationForm = new(context, _currentEmployee);
            iURegistrationForm.ShowDialog();
            RestartAllDgv();
        }

        private void updateRegistrationButton_Click(object sender, EventArgs e)
        {
            if (dgvRegistration.SelectedRows.Count == 1)
            {
                int index = dgvRegistration.SelectedRows[0].Index;
                switch (_currentEmployee.Role)
                {
                    case "admin":
                        break;
                    case "user":
                        if ((int)dgvRegistration.Rows[index].Cells["Код сотрудника"].Value != _currentEmployee.Id)
                        {
                            MessageBox.Show("Можно изменять только собственные регистрации!"
                                           , "Ошибка"
                                           , MessageBoxButtons.OK
                                           , MessageBoxIcon.Error
                                           , MessageBoxDefaultButton.Button1);
                            return;
                        }
                        break;
                }
                Registration registration = new()
                {
                    Id = (int)dgvRegistration.Rows[index].Cells["Код"].Value,
                    RegistrationPlate = dgvRegistration.Rows[index].Cells["Регистрационный знак"]
                                                                   .Value.ToString(),
                    Date = (DateTime)dgvRegistration.Rows[index].Cells["Дата"].Value,
                    CarId = (int)dgvRegistration.Rows[index].Cells["Код автомобиля"].Value,
                    DriverId = (int)dgvRegistration.Rows[index].Cells["Код водителя"].Value,
                    EmployeeId = (int)dgvRegistration.Rows[index].Cells["Код сотрудника"].Value,
                    CarMarkModelVIN = dgvRegistration.Rows[index].Cells["Автомобиль"].Value.ToString(),
                    DriverFIO = dgvRegistration.Rows[index].Cells["ФИО водителя"].Value.ToString(),
                    EmployeeFIO = dgvRegistration.Rows[index].Cells["ФИО сотрудника"].Value.ToString()
                };
                IURegistrationForm iURegistratioForm = new(context, _currentEmployee, registration);
                iURegistratioForm.ShowDialog();
                RestartAllDgv();
            }
            else
            {
                MessageBox.Show("Выберите строку для изменения!", "Ошибка"
                                , MessageBoxButtons.OK, MessageBoxIcon.Error
                                , MessageBoxDefaultButton.Button1);
            }
        }

        private void deleteRegistrationButton_Click(object sender, EventArgs e)
        {
            if (dgvRegistration.SelectedRows.Count > 0)
            {
                int index = dgvRegistration.SelectedRows[0].Index;
                switch (_currentEmployee.Role)
                {
                    case "admin":
                        break;
                    case "user":
                        if ((int)dgvRegistration.Rows[index].Cells["Код сотрудника"].Value != _currentEmployee.Id)
                        {
                            MessageBox.Show("Можно удалять только собственные регистрации!"
                                           , "Ошибка"
                                           , MessageBoxButtons.OK
                                           , MessageBoxIcon.Error
                                           , MessageBoxDefaultButton.Button1);
                            return;
                        }
                        break;
                }
                var result = MessageBox.Show("Вы уверены, что хотите удалить эту запись?"
                                           , "Подтверждение"
                                           , MessageBoxButtons.OKCancel
                                           , MessageBoxIcon.Question
                                           , MessageBoxDefaultButton.Button1);
                if (result == DialogResult.OK)
                {
                    int id = (int)dgvRegistration.Rows[index].Cells[0].Value;
                    RegistrationRepository registrationRepository = new(context);
                    registrationRepository.Delete(id);
                    RestartAllDgv();
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления!", "Ошибка"
                                , MessageBoxButtons.OK, MessageBoxIcon.Error
                                , MessageBoxDefaultButton.Button1);
            }
        }

        private void addLicenseButton_Click(object sender, EventArgs e)
        {
            IULicenseForm iULicenseForm = new(context);
            iULicenseForm.ShowDialog();
            LicenseRepository licenseRepository = new(context);
            dgvLicense.DataSource = licenseRepository.GetAll();
            HideDgvColumns(ref dgvLicense);
        }

        private void updateLicenseButton_Click(object sender, EventArgs e)
        {
            if (dgvLicense.SelectedRows.Count == 1)
            {
                int index = dgvLicense.SelectedRows[0].Index;
                License license = new()
                {
                    Id = (int)dgvLicense.Rows[index].Cells["Код"].Value,
                    Number = dgvLicense.Rows[index].Cells["Номер"].Value.ToString(),
                    DateOfIssue = (DateTime)dgvLicense.Rows[index].Cells["Дата выдачи"].Value,
                    Validity = (DateTime)dgvLicense.Rows[index].Cells["Срок действия"].Value,
                    DriverId = (int)dgvLicense.Rows[index].Cells["Код водителя"].Value,
                    DriverFIO = dgvLicense.Rows[index].Cells["ФИО водителя"].Value.ToString(),
                    Categories = dgvLicense.Rows[index].Cells["Категории"].Value.ToString().Split(',').ToList()
                };
                IULicenseForm iULicenseForm = new(context, license);
                iULicenseForm.ShowDialog();
                LicenseRepository licenseRepository = new(context);
                dgvLicense.DataSource = licenseRepository.GetAll();
                HideDgvColumns(ref dgvLicense);
            }
            else
            {
                MessageBox.Show("Выберите строку для изменения!", "Ошибка"
                                , MessageBoxButtons.OK, MessageBoxIcon.Error
                                , MessageBoxDefaultButton.Button1);
            }
        }

        private void deleteLicenseButton_Click(object sender, EventArgs e)
        {
            if (dgvLicense.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить эту запись?"
                                           , "Подтверждение"
                                           , MessageBoxButtons.OKCancel
                                           , MessageBoxIcon.Question
                                           , MessageBoxDefaultButton.Button1);
                if (result == DialogResult.OK)
                {
                    int index = dgvLicense.SelectedRows[0].Index;
                    int id = (int)dgvLicense.Rows[index].Cells[0].Value;
                    LicenseRepository licenseRepository = new(context);
                    licenseRepository.Delete(id);
                    dgvLicense.DataSource = licenseRepository.GetAll();
                    HideDgvColumns(ref dgvLicense);
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления!", "Ошибка"
                                , MessageBoxButtons.OK, MessageBoxIcon.Error
                                , MessageBoxDefaultButton.Button1);
            }
        }

        private void addDriverButton_Click(object sender, EventArgs e)
        {
            IUDriverForm iUDriverForm = new(context);
            iUDriverForm.ShowDialog();
            DriverRepository driverRepository = new(context);
            dgvDrivers.DataSource = driverRepository.GetAll();
            HideDgvColumns(ref dgvDrivers);
        }

        private void updateDriverButton_Click(object sender, EventArgs e)
        {
            if (dgvDrivers.SelectedRows.Count == 1)
            {
                int index = dgvDrivers.SelectedRows[0].Index;
                Driver driver = new()
                {
                    Id = (int)dgvDrivers.Rows[index].Cells["Код"].Value,
                    Surname = dgvDrivers.Rows[index].Cells["Фамилия"].Value.ToString(),
                    Name = dgvDrivers.Rows[index].Cells["Имя"].Value.ToString(),
                    Patronymic = dgvDrivers.Rows[index].Cells["Отчество"].Value.ToString(),
                    Passport = dgvDrivers.Rows[index].Cells["Паспорт"].Value.ToString(),
                    PhoneNumber = dgvDrivers.Rows[index].Cells["Телефон"].Value.ToString(),
                };
                IUDriverForm iUDriverForm = new(context, driver);
                iUDriverForm.ShowDialog();
                RestartAllDgv();
            }
            else
            {
                MessageBox.Show("Выберите строку для изменения!", "Ошибка"
                                , MessageBoxButtons.OK, MessageBoxIcon.Error
                                , MessageBoxDefaultButton.Button1);
            }
        }

        private void deleteDriverButton_Click(object sender, EventArgs e)
        {
            if (dgvDrivers.SelectedRows.Count > 0)
            {
                int index = dgvDrivers.SelectedRows[0].Index;
                int id = (int)dgvDrivers.Rows[index].Cells[0].Value;
                DriverRepository driverRepository = new(context);
                driverRepository.Delete(id);
                RestartAllDgv();
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления!", "Ошибка"
                                , MessageBoxButtons.OK, MessageBoxIcon.Error
                                , MessageBoxDefaultButton.Button1);
            }
        }

        private void addCarButton_Click(object sender, EventArgs e)
        {
            IUCarForm iUCarForm = new(context);
            iUCarForm.ShowDialog();
            CarRepository carRepository = new(context);
            dgvCars.DataSource = carRepository.GetAll();
            HideDgvColumns(ref dgvCars);
        }

        private void updateCarButton_Click(object sender, EventArgs e)
        {
            if (dgvCars.SelectedRows.Count == 1)
            {
                int index = dgvCars.SelectedRows[0].Index;
                Car car = new()
                {
                    Id = (int)dgvCars.Rows[index].Cells["Код"].Value,
                    VIN = dgvCars.Rows[index].Cells["VIN"].Value.ToString(),
                    Mark = dgvCars.Rows[index].Cells["Марка"].Value.ToString(),
                    Model = dgvCars.Rows[index].Cells["Модель"].Value.ToString(),
                    Color = dgvCars.Rows[index].Cells["Цвет"].Value.ToString(),
                };
                IUCarForm iUCarForm = new(context, car);
                iUCarForm.ShowDialog();
                RestartAllDgv();
            }
            else
            {
                MessageBox.Show("Выберите строку для изменения!", "Ошибка"
                                , MessageBoxButtons.OK, MessageBoxIcon.Error
                                , MessageBoxDefaultButton.Button1);
            }
        }

        private void deleteCarButton_Click(object sender, EventArgs e)
        {
            if (dgvCars.SelectedRows.Count > 0)
            {
                int index = dgvCars.SelectedRows[0].Index;
                int id = (int)dgvCars.Rows[index].Cells[0].Value;
                CarRepository carRepository = new(context);
                carRepository.Delete(id);
                RestartAllDgv();
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления!", "Ошибка"
                                , MessageBoxButtons.OK, MessageBoxIcon.Error
                                , MessageBoxDefaultButton.Button1);
            }
        }

        private void addDirectoryButton_Click(object sender, EventArgs e)
        {
            switch (directoryCB.Text)
            {
                case "Звания":
                    IURangForm iURangForm = new(context);
                    iURangForm.ShowDialog();
                    RangRepository rangRepository = new(context);
                    dgvDirectories.DataSource = rangRepository.GetAll();
                    HideDgvColumns(ref dgvDirectories);
                    break;
                case "Категории":
                    IUCategoryForm iUCategoryForm = new(context);
                    iUCategoryForm.ShowDialog();
                    CategoryRepository categoryRepository = new(context);
                    dgvDirectories.DataSource = categoryRepository.GetAll();
                    HideDgvColumns(ref dgvDirectories);
                    break;
                case "Типы нарушения":
                    IUTypeOfViolationForm iUTypeOfViolationForm = new(context);
                    iUTypeOfViolationForm.ShowDialog();
                    TypeOfViolationRepository typeOfViolationRepository = new(context);
                    dgvDirectories.DataSource = typeOfViolationRepository.GetAll();
                    HideDgvColumns(ref dgvDirectories);
                    break;
                case "Сотрудники":
                    IUEmployeeForm iUEmployeeForm = new(context);
                    iUEmployeeForm.ShowDialog();
                    EmployeeRepository employeeRepository = new(context);
                    dgvDirectories.DataSource = employeeRepository.GetAll();
                    HideDgvColumns(ref dgvDirectories);
                    break;
                default:
                    break;
            }
        }

        private void updateDirectoryButton_Click(object sender, EventArgs e)
        {
            if (dgvDirectories.SelectedRows.Count == 1)
            {
                int index = dgvDirectories.SelectedRows[0].Index;
                switch (directoryCB.Text)
                {
                    case "Звания":
                        Rang rang = new()
                        {
                            Id = (int)dgvDirectories.Rows[index].Cells["Код"].Value,
                            Title = dgvDirectories.Rows[index].Cells["Наименование"].Value.ToString()
                        };
                        IURangForm iURangForm = new(context, rang);
                        iURangForm.ShowDialog();
                        RangRepository rangRepository = new(context);
                        dgvDirectories.DataSource = rangRepository.GetAll();
                        HideDgvColumns(ref dgvDirectories);
                        RestartAllDgv();
                        break;
                    case "Категории":
                        Category category = new()
                        {
                            Id = (int)dgvDirectories.Rows[index].Cells["Код"].Value,
                            Title = dgvDirectories.Rows[index].Cells["Наименование"].Value.ToString(),
                            Description = dgvDirectories.Rows[index].Cells["Расшифровка"].Value.ToString()
                        };
                        IUCategoryForm iUCategoryForm = new(context, category);
                        iUCategoryForm.ShowDialog();
                        CategoryRepository categoryRepository = new(context);
                        dgvDirectories.DataSource = categoryRepository.GetAll();
                        HideDgvColumns(ref dgvDirectories);
                        RestartAllDgv();
                        break;
                    case "Типы нарушения":
                        TypeOfViolation typeOfViolation = new()
                        {
                            Id = (int)dgvDirectories.Rows[index].Cells["Код"].Value,
                            Title = dgvDirectories.Rows[index].Cells["Наименование"].Value.ToString(),
                        };
                        IUTypeOfViolationForm iUTypeOfViolationForm = new(context, typeOfViolation);
                        iUTypeOfViolationForm.ShowDialog();
                        TypeOfViolationRepository typeOfViolationRepository = new(context);
                        dgvDirectories.DataSource = typeOfViolationRepository.GetAll();
                        HideDgvColumns(ref dgvDirectories);
                        RestartAllDgv();
                        break;
                    case "Сотрудники":
                        Employee employee = new()
                        {
                            Id = (int)dgvDirectories.Rows[index].Cells["Код"].Value,
                            Surname = dgvDirectories.Rows[index].Cells["Фамилия"].Value.ToString(),
                            Name = dgvDirectories.Rows[index].Cells["Имя"].Value.ToString(),
                            Patronymic = dgvDirectories.Rows[index].Cells["Отчество"].Value.ToString(),
                            UserName = dgvDirectories.Rows[index].Cells["Логин"].Value.ToString(),
                            PhoneNumber = dgvDirectories.Rows[index].Cells["Телефон"].Value.ToString(),
                            RangId = (int)dgvDirectories.Rows[index].Cells["Код звания"].Value,
                            RoleId = (int)dgvDirectories.Rows[index].Cells["Код роли"].Value,
                            RangTitle = dgvDirectories.Rows[index].Cells["Звание"].Value.ToString(),
                            Role = dgvDirectories.Rows[index].Cells["Роль"].Value.ToString()
                        };
                        IUEmployeeForm iUEmployeeForm;
                        EmployeeRepository employeeRepository = new(context);
                        if (employee.Id == _currentEmployee.Id)
                        {
                            iUEmployeeForm = new(context, employee, false);
                            iUEmployeeForm.ShowDialog();
                            dgvDirectories.DataSource = employeeRepository.GetAll();
                            HideDgvColumns(ref dgvDirectories);
                            _currentEmployee = employee;
                            introductionLabel.Text = $"Текущий сеанс:\nФИО сотурдника:" +
                                     $" {_currentEmployee.Surname} {_currentEmployee.Name} {_currentEmployee.Patronymic}" +
                                     $"\nЗвание сотрудника: {_currentEmployee.RangTitle}";
                        }
                        else
                        {
                            iUEmployeeForm = new(context, employee, true);
                            iUEmployeeForm.ShowDialog();
                            dgvDirectories.DataSource = employeeRepository.GetAll();
                            HideDgvColumns(ref dgvDirectories);
                        }
                        RestartAllDgv();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для изменения!", "Ошибка"
                                , MessageBoxButtons.OK, MessageBoxIcon.Error
                                , MessageBoxDefaultButton.Button1);
            }
        }

        private void deleteDIrectoryButton_Click(object sender, EventArgs e)
        {
            if (dgvDirectories.SelectedRows.Count > 0)
            {
                int index = dgvDirectories.SelectedRows[0].Index;
                int id = (int)dgvDirectories.Rows[index].Cells[0].Value;
                switch (directoryCB.Text)
                {
                    case "Звания":
                        var result = MessageBox.Show("Вы уверены, что хотите удалить эту запись?"
                                           , "Подтверждение"
                                           , MessageBoxButtons.OKCancel
                                           , MessageBoxIcon.Question
                                           , MessageBoxDefaultButton.Button1);
                        if (result == DialogResult.OK)
                        {
                            RangRepository rangRepository = new(context);
                            rangRepository.Delete(id);
                            dgvDirectories.DataSource = rangRepository.GetAll();
                            RestartAllDgv();
                        }
                        break;
                    case "Категории":
                        result = MessageBox.Show("Вы уверены, что хотите удалить эту запись?"
                                           , "Подтверждение"
                                           , MessageBoxButtons.OKCancel
                                           , MessageBoxIcon.Question
                                           , MessageBoxDefaultButton.Button1);
                        if (result == DialogResult.OK)
                        {
                            CategoryRepository categoryRepository = new(context);
                            categoryRepository.Delete(id);
                            dgvDirectories.DataSource = categoryRepository.GetAll();
                            RestartAllDgv();
                        }
                        break;
                    case "Типы нарушения":
                        result = MessageBox.Show("Вы уверены, что хотите удалить эту запись?"
                                           , "Подтверждение"
                                           , MessageBoxButtons.OKCancel
                                           , MessageBoxIcon.Question
                                           , MessageBoxDefaultButton.Button1);
                        if (result == DialogResult.OK)
                        {
                            TypeOfViolationRepository typeOfViolationRepository = new(context);
                            typeOfViolationRepository.Delete(id);
                            dgvDirectories.DataSource = typeOfViolationRepository.GetAll();
                            RestartAllDgv();
                        }
                        break;
                    case "Сотрудники":


                        if (id == _currentEmployee.Id)
                        {
                            MessageBox.Show("Нельзя удалять текущего сотрудника!"
                                           , "Ошибка"
                                           , MessageBoxButtons.OK
                                           , MessageBoxIcon.Error
                                           , MessageBoxDefaultButton.Button1);
                            return;
                        }
                        EmployeeRepository employeeRepository = new(context);
                        employeeRepository.Delete(id);
                        dgvDirectories.DataSource = employeeRepository.GetAll();
                        RestartAllDgv();

                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления!", "Ошибка"
                                , MessageBoxButtons.OK, MessageBoxIcon.Error
                                , MessageBoxDefaultButton.Button1);
            }
        }

        private void directoryCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (directoryCB.Text)
            {
                case "Звания":
                    RangRepository rangRepository = new(context);
                    dgvDirectories.DataSource = rangRepository.GetAll();
                    HideDgvColumns(ref dgvDirectories);
                    break;
                case "Категории":
                    CategoryRepository categoryRepository = new(context);
                    dgvDirectories.DataSource = categoryRepository.GetAll();
                    HideDgvColumns(ref dgvDirectories);
                    break;
                case "Типы нарушения":
                    TypeOfViolationRepository typeOfViolationRepository = new(context);
                    dgvDirectories.DataSource = typeOfViolationRepository.GetAll();
                    HideDgvColumns(ref dgvDirectories);
                    break;
                case "Сотрудники":
                    EmployeeRepository EmployeeRepository = new(context);
                    dgvDirectories.DataSource = EmployeeRepository.GetAll();
                    HideDgvColumns(ref dgvDirectories);
                    break;
                default:
                    break;
            }
        }

        private void нарушенийВодителейЗаПериодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"D:/study/CourseProject/Reports/bin/Debug/Reports.exe", "DriversViolationsForThePeriod");
        }

        private void эффективностьСотрудниковЗаПоследнийМесяцToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"D:/study/CourseProject/Reports/bin/Debug/Reports.exe", "EmployeeStatView");
        }

        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"D:/study/CourseProject/Reports/bin/Debug/Reports.exe", "EmployeeView");
        }

        private void deleteLicenseExtButton_Click(object sender, EventArgs e)
        {
            LicenseRepository licenseRepository = new(context);
            licenseRepository.DeleteExt();
            dgvLicense.DataSource = licenseRepository.GetAll();
        }

        private void rollBackButton_Click(object sender, EventArgs e)
        {
            if (dgvRollBack.SelectedRows.Count == 1)
            {
                var result = MessageBox.Show("Вы уверены что хотите вернуть данные в это состояние?"
                                , "Подтверждение"
                                , MessageBoxButtons.OKCancel
                                , MessageBoxIcon.Question
                                , MessageBoxDefaultButton.Button1);
                if (result == DialogResult.OK)
                {
                    int index = dgvRollBack.SelectedRows[0].Index;
                    int id = (int)dgvRollBack.Rows[index].Cells[0].Value;
                    RegistrationRepository registrationRepository = new(context);
                    registrationRepository.RollBack(id);
                    RestartAllDgv();
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для отката!", "Ошибка"
                                , MessageBoxButtons.OK, MessageBoxIcon.Error
                                , MessageBoxDefaultButton.Button1);
            }
        }
    }
}