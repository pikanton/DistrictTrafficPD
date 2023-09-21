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
            if (dgv.Columns["���"] != null)
                dgv.Columns["���"].Visible = false;
            if (dgv.Columns["��� ����������"] != null)
                dgv.Columns["��� ����������"].Visible = false;
            if (dgv.Columns["��� ��������"] != null)
                dgv.Columns["��� ��������"].Visible = false;
            if (dgv.Columns["��� ������"] != null)
                dgv.Columns["��� ������"].Visible = false;
            if (dgv.Columns["��� ���������"] != null)
                dgv.Columns["��� ���������"].Visible = false;
            if (dgv.Columns["��� ���������"] != null)
                dgv.Columns["��� ���������"].Visible = false;
            if (dgv.Columns["��� ����������"] != null)
                dgv.Columns["��� ����������"].Visible = false;
            if (dgv.Columns["��� ����"] != null)
                dgv.Columns["��� ����"].Visible = false;
            if (dgv.Columns["������"] != null)
                dgv.Columns["������"].Visible = false;
        }
        private void RestartAllDgv()
        {
            // �������� � dgv ���������
            ViolationRepository violationRepository = new(context);
            dgvViolation.DataSource = violationRepository.GetAll();
            HideDgvColumns(ref dgvViolation);

            // �������� c dgv �����������
            RegistrationRepository registrationRepository = new(context);
            dgvRegistration.DataSource = registrationRepository.GetAll();
            HideDgvColumns(ref dgvRegistration);

            // �������� c dgv ������������ �������������
            LicenseRepository licenseRepository = new(context);
            dgvLicense.DataSource = licenseRepository.GetAll();
            HideDgvColumns(ref dgvLicense);

            // �������� c dgv ��������
            DriverRepository driverRepository = new(context);
            dgvDrivers.DataSource = driverRepository.GetAll();
            HideDgvColumns(ref dgvDrivers);

            // �������� c dgv ����������
            CarRepository carRepository = new(context);
            dgvCars.DataSource = carRepository.GetAll();
            HideDgvColumns(ref dgvCars);

            // �������� c dgv �����
            dgvRollBack.DataSource = registrationRepository.GetRollBackView();
            HideDgvColumns(ref dgvRollBack);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            introductionLabel.Text = $"������� �����:\n��� ����������:" +
                                     $" {_currentEmployee.Surname} {_currentEmployee.Name} {_currentEmployee.Patronymic}" +
                                     $"\n������ ����������: {_currentEmployee.RangTitle}";
            switch (_currentEmployee.Role)
            {
                case "admin":
                    tabDirectories.Parent = mainControl;
                    tabRollBack.Parent = mainControl;
                    deleteLicenseExtButton.Visible = true;
                    ����������ToolStripMenuItem.Visible = true;
                    ����������������������������������������ToolStripMenuItem.Visible = true;
                    break;
                case "user":
                    tabDirectories.Parent = null;
                    tabRollBack.Parent = null;
                    deleteLicenseExtButton.Visible = false;
                    ����������ToolStripMenuItem.Visible = false;
                    ����������������������������������������ToolStripMenuItem.Visible = false;
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
                        if ((int)dgvViolation.Rows[index].Cells["��� ����������"].Value != _currentEmployee.Id)
                        {
                            MessageBox.Show("����� �������� ������ ����������� ���������!"
                                           , "������"
                                           , MessageBoxButtons.OK
                                           , MessageBoxIcon.Error
                                           , MessageBoxDefaultButton.Button1);
                            return;
                        }
                        break;
                }
                Violation violation = new()
                {
                    Id = (int)dgvViolation.Rows[index].Cells["���"].Value,
                    Date = (DateTime)dgvViolation.Rows[index].Cells["����"].Value,
                    ProtocolNumber = dgvViolation.Rows[index].Cells["� ���������"].Value.ToString(),
                    Fine = (decimal)dgvViolation.Rows[index].Cells["������ ������"].Value,
                    TermOfDeprivation = (int)dgvViolation.Rows[index].Cells["���� ������� ����"].Value,
                    DriverId = (int)dgvViolation.Rows[index].Cells["��� ��������"].Value,
                    EmployeeId = (int)dgvViolation.Rows[index].Cells["��� ����������"].Value,
                    TypeId = (int)dgvViolation.Rows[index].Cells["��� ���������"].Value,
                    DriverFIO = dgvViolation.Rows[index].Cells["��� ��������"].Value.ToString(),
                    EmployeeFIO = dgvViolation.Rows[index].Cells["��� ����������"].Value.ToString(),
                    TypeTitle = dgvViolation.Rows[index].Cells["���������"].Value.ToString()
                };
                IUViolationForm iUViolationForm = new(context, _currentEmployee, violation);
                iUViolationForm.ShowDialog();
                ViolationRepository violationRepository = new(context);
                dgvViolation.DataSource = violationRepository.GetAll();
                HideDgvColumns(ref dgvViolation);
            }
            else
            {
                MessageBox.Show("�������� ������ ��� ���������!", "������"
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
                        if ((int)dgvViolation.Rows[index].Cells["��� ����������"].Value != _currentEmployee.Id)
                        {
                            MessageBox.Show("����� ������� ������ ����������� ���������!"
                                           , "������"
                                           , MessageBoxButtons.OK
                                           , MessageBoxIcon.Error
                                           , MessageBoxDefaultButton.Button1);
                            return;
                        }
                        break;
                }
                var result = MessageBox.Show("�� �������, ��� ������ ������� ��� ������?"
                                           , "�������������"
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
                MessageBox.Show("�������� ������ ��� ��������!", "������"
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
                        if ((int)dgvRegistration.Rows[index].Cells["��� ����������"].Value != _currentEmployee.Id)
                        {
                            MessageBox.Show("����� �������� ������ ����������� �����������!"
                                           , "������"
                                           , MessageBoxButtons.OK
                                           , MessageBoxIcon.Error
                                           , MessageBoxDefaultButton.Button1);
                            return;
                        }
                        break;
                }
                Registration registration = new()
                {
                    Id = (int)dgvRegistration.Rows[index].Cells["���"].Value,
                    RegistrationPlate = dgvRegistration.Rows[index].Cells["��������������� ����"]
                                                                   .Value.ToString(),
                    Date = (DateTime)dgvRegistration.Rows[index].Cells["����"].Value,
                    CarId = (int)dgvRegistration.Rows[index].Cells["��� ����������"].Value,
                    DriverId = (int)dgvRegistration.Rows[index].Cells["��� ��������"].Value,
                    EmployeeId = (int)dgvRegistration.Rows[index].Cells["��� ����������"].Value,
                    CarMarkModelVIN = dgvRegistration.Rows[index].Cells["����������"].Value.ToString(),
                    DriverFIO = dgvRegistration.Rows[index].Cells["��� ��������"].Value.ToString(),
                    EmployeeFIO = dgvRegistration.Rows[index].Cells["��� ����������"].Value.ToString()
                };
                IURegistrationForm iURegistratioForm = new(context, _currentEmployee, registration);
                iURegistratioForm.ShowDialog();
                RestartAllDgv();
            }
            else
            {
                MessageBox.Show("�������� ������ ��� ���������!", "������"
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
                        if ((int)dgvRegistration.Rows[index].Cells["��� ����������"].Value != _currentEmployee.Id)
                        {
                            MessageBox.Show("����� ������� ������ ����������� �����������!"
                                           , "������"
                                           , MessageBoxButtons.OK
                                           , MessageBoxIcon.Error
                                           , MessageBoxDefaultButton.Button1);
                            return;
                        }
                        break;
                }
                var result = MessageBox.Show("�� �������, ��� ������ ������� ��� ������?"
                                           , "�������������"
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
                MessageBox.Show("�������� ������ ��� ��������!", "������"
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
                    Id = (int)dgvLicense.Rows[index].Cells["���"].Value,
                    Number = dgvLicense.Rows[index].Cells["�����"].Value.ToString(),
                    DateOfIssue = (DateTime)dgvLicense.Rows[index].Cells["���� ������"].Value,
                    Validity = (DateTime)dgvLicense.Rows[index].Cells["���� ��������"].Value,
                    DriverId = (int)dgvLicense.Rows[index].Cells["��� ��������"].Value,
                    DriverFIO = dgvLicense.Rows[index].Cells["��� ��������"].Value.ToString(),
                    Categories = dgvLicense.Rows[index].Cells["���������"].Value.ToString().Split(',').ToList()
                };
                IULicenseForm iULicenseForm = new(context, license);
                iULicenseForm.ShowDialog();
                LicenseRepository licenseRepository = new(context);
                dgvLicense.DataSource = licenseRepository.GetAll();
                HideDgvColumns(ref dgvLicense);
            }
            else
            {
                MessageBox.Show("�������� ������ ��� ���������!", "������"
                                , MessageBoxButtons.OK, MessageBoxIcon.Error
                                , MessageBoxDefaultButton.Button1);
            }
        }

        private void deleteLicenseButton_Click(object sender, EventArgs e)
        {
            if (dgvLicense.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("�� �������, ��� ������ ������� ��� ������?"
                                           , "�������������"
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
                MessageBox.Show("�������� ������ ��� ��������!", "������"
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
                    Id = (int)dgvDrivers.Rows[index].Cells["���"].Value,
                    Surname = dgvDrivers.Rows[index].Cells["�������"].Value.ToString(),
                    Name = dgvDrivers.Rows[index].Cells["���"].Value.ToString(),
                    Patronymic = dgvDrivers.Rows[index].Cells["��������"].Value.ToString(),
                    Passport = dgvDrivers.Rows[index].Cells["�������"].Value.ToString(),
                    PhoneNumber = dgvDrivers.Rows[index].Cells["�������"].Value.ToString(),
                };
                IUDriverForm iUDriverForm = new(context, driver);
                iUDriverForm.ShowDialog();
                RestartAllDgv();
            }
            else
            {
                MessageBox.Show("�������� ������ ��� ���������!", "������"
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
                MessageBox.Show("�������� ������ ��� ��������!", "������"
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
                    Id = (int)dgvCars.Rows[index].Cells["���"].Value,
                    VIN = dgvCars.Rows[index].Cells["VIN"].Value.ToString(),
                    Mark = dgvCars.Rows[index].Cells["�����"].Value.ToString(),
                    Model = dgvCars.Rows[index].Cells["������"].Value.ToString(),
                    Color = dgvCars.Rows[index].Cells["����"].Value.ToString(),
                };
                IUCarForm iUCarForm = new(context, car);
                iUCarForm.ShowDialog();
                RestartAllDgv();
            }
            else
            {
                MessageBox.Show("�������� ������ ��� ���������!", "������"
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
                MessageBox.Show("�������� ������ ��� ��������!", "������"
                                , MessageBoxButtons.OK, MessageBoxIcon.Error
                                , MessageBoxDefaultButton.Button1);
            }
        }

        private void addDirectoryButton_Click(object sender, EventArgs e)
        {
            switch (directoryCB.Text)
            {
                case "������":
                    IURangForm iURangForm = new(context);
                    iURangForm.ShowDialog();
                    RangRepository rangRepository = new(context);
                    dgvDirectories.DataSource = rangRepository.GetAll();
                    HideDgvColumns(ref dgvDirectories);
                    break;
                case "���������":
                    IUCategoryForm iUCategoryForm = new(context);
                    iUCategoryForm.ShowDialog();
                    CategoryRepository categoryRepository = new(context);
                    dgvDirectories.DataSource = categoryRepository.GetAll();
                    HideDgvColumns(ref dgvDirectories);
                    break;
                case "���� ���������":
                    IUTypeOfViolationForm iUTypeOfViolationForm = new(context);
                    iUTypeOfViolationForm.ShowDialog();
                    TypeOfViolationRepository typeOfViolationRepository = new(context);
                    dgvDirectories.DataSource = typeOfViolationRepository.GetAll();
                    HideDgvColumns(ref dgvDirectories);
                    break;
                case "����������":
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
                    case "������":
                        Rang rang = new()
                        {
                            Id = (int)dgvDirectories.Rows[index].Cells["���"].Value,
                            Title = dgvDirectories.Rows[index].Cells["������������"].Value.ToString()
                        };
                        IURangForm iURangForm = new(context, rang);
                        iURangForm.ShowDialog();
                        RangRepository rangRepository = new(context);
                        dgvDirectories.DataSource = rangRepository.GetAll();
                        HideDgvColumns(ref dgvDirectories);
                        RestartAllDgv();
                        break;
                    case "���������":
                        Category category = new()
                        {
                            Id = (int)dgvDirectories.Rows[index].Cells["���"].Value,
                            Title = dgvDirectories.Rows[index].Cells["������������"].Value.ToString(),
                            Description = dgvDirectories.Rows[index].Cells["�����������"].Value.ToString()
                        };
                        IUCategoryForm iUCategoryForm = new(context, category);
                        iUCategoryForm.ShowDialog();
                        CategoryRepository categoryRepository = new(context);
                        dgvDirectories.DataSource = categoryRepository.GetAll();
                        HideDgvColumns(ref dgvDirectories);
                        RestartAllDgv();
                        break;
                    case "���� ���������":
                        TypeOfViolation typeOfViolation = new()
                        {
                            Id = (int)dgvDirectories.Rows[index].Cells["���"].Value,
                            Title = dgvDirectories.Rows[index].Cells["������������"].Value.ToString(),
                        };
                        IUTypeOfViolationForm iUTypeOfViolationForm = new(context, typeOfViolation);
                        iUTypeOfViolationForm.ShowDialog();
                        TypeOfViolationRepository typeOfViolationRepository = new(context);
                        dgvDirectories.DataSource = typeOfViolationRepository.GetAll();
                        HideDgvColumns(ref dgvDirectories);
                        RestartAllDgv();
                        break;
                    case "����������":
                        Employee employee = new()
                        {
                            Id = (int)dgvDirectories.Rows[index].Cells["���"].Value,
                            Surname = dgvDirectories.Rows[index].Cells["�������"].Value.ToString(),
                            Name = dgvDirectories.Rows[index].Cells["���"].Value.ToString(),
                            Patronymic = dgvDirectories.Rows[index].Cells["��������"].Value.ToString(),
                            UserName = dgvDirectories.Rows[index].Cells["�����"].Value.ToString(),
                            PhoneNumber = dgvDirectories.Rows[index].Cells["�������"].Value.ToString(),
                            RangId = (int)dgvDirectories.Rows[index].Cells["��� ������"].Value,
                            RoleId = (int)dgvDirectories.Rows[index].Cells["��� ����"].Value,
                            RangTitle = dgvDirectories.Rows[index].Cells["������"].Value.ToString(),
                            Role = dgvDirectories.Rows[index].Cells["����"].Value.ToString()
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
                            introductionLabel.Text = $"������� �����:\n��� ����������:" +
                                     $" {_currentEmployee.Surname} {_currentEmployee.Name} {_currentEmployee.Patronymic}" +
                                     $"\n������ ����������: {_currentEmployee.RangTitle}";
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
                MessageBox.Show("�������� ������ ��� ���������!", "������"
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
                    case "������":
                        var result = MessageBox.Show("�� �������, ��� ������ ������� ��� ������?"
                                           , "�������������"
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
                    case "���������":
                        result = MessageBox.Show("�� �������, ��� ������ ������� ��� ������?"
                                           , "�������������"
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
                    case "���� ���������":
                        result = MessageBox.Show("�� �������, ��� ������ ������� ��� ������?"
                                           , "�������������"
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
                    case "����������":


                        if (id == _currentEmployee.Id)
                        {
                            MessageBox.Show("������ ������� �������� ����������!"
                                           , "������"
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
                MessageBox.Show("�������� ������ ��� ��������!", "������"
                                , MessageBoxButtons.OK, MessageBoxIcon.Error
                                , MessageBoxDefaultButton.Button1);
            }
        }

        private void directoryCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (directoryCB.Text)
            {
                case "������":
                    RangRepository rangRepository = new(context);
                    dgvDirectories.DataSource = rangRepository.GetAll();
                    HideDgvColumns(ref dgvDirectories);
                    break;
                case "���������":
                    CategoryRepository categoryRepository = new(context);
                    dgvDirectories.DataSource = categoryRepository.GetAll();
                    HideDgvColumns(ref dgvDirectories);
                    break;
                case "���� ���������":
                    TypeOfViolationRepository typeOfViolationRepository = new(context);
                    dgvDirectories.DataSource = typeOfViolationRepository.GetAll();
                    HideDgvColumns(ref dgvDirectories);
                    break;
                case "����������":
                    EmployeeRepository EmployeeRepository = new(context);
                    dgvDirectories.DataSource = EmployeeRepository.GetAll();
                    HideDgvColumns(ref dgvDirectories);
                    break;
                default:
                    break;
            }
        }

        private void ��������������������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"D:/study/CourseProject/Reports/bin/Debug/Reports.exe", "DriversViolationsForThePeriod");
        }

        private void ����������������������������������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"D:/study/CourseProject/Reports/bin/Debug/Reports.exe", "EmployeeStatView");
        }

        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
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
                var result = MessageBox.Show("�� ������� ��� ������ ������� ������ � ��� ���������?"
                                , "�������������"
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
                MessageBox.Show("�������� ������ ��� ������!", "������"
                                , MessageBoxButtons.OK, MessageBoxIcon.Error
                                , MessageBoxDefaultButton.Button1);
            }
        }
    }
}