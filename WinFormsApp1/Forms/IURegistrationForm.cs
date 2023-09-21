using GAI.Classes;
using GAI.Repository;
using WinFormsApp1;

namespace GAI.Forms
{
    public partial class IURegistrationForm : Form
    {
        private DBContext context;
        private Employee currentEmployee;
        private Registration registration;
        private int IUstatus; //0 если форма открыта на добавление, 1 если на изменение
        public IURegistrationForm(DBContext context, Employee currentEmployee, Registration? registration = null)
        {
            this.context = context;
            this.currentEmployee = currentEmployee;
            if (registration != null)
            {
                this.registration = registration;
                IUstatus = 1;
            }
            else
            {
                this.registration = new Registration();
                IUstatus = 0;
            }
            InitializeComponent();
        }

        private void IURegistrationForm_Load(object sender, EventArgs e)
        {
            driverCB.Items.Clear();
            DriverRepository driverRepository = new(context);
            driverCB.Items.AddRange(driverRepository.GetAllFIO());
            employeeCB.Items.Clear();
            EmployeeRepository employeeRepository = new(context);
            employeeCB.Items.AddRange(employeeRepository.GetAllFIO());
            carCB.Items.Clear();
            CarRepository carRepository = new(context);
            carCB.Items.AddRange(carRepository.GetAllMarkModelVIN());
            driverCB.SelectedIndex = 0;
            employeeCB.SelectedIndex = 0;
            carCB.SelectedIndex = 0;
            if (IUstatus == 0)
            {
                Text = "Регистрация автомобиля";
            }
            else if (IUstatus == 1)
            {
                Text = "Изменение регистрации";
                registrationPlateText.Text = registration.RegistrationPlate.ToString();
                driverCB.Text = registration.DriverFIO;
                employeeCB.Text = registration.EmployeeFIO;
                carCB.Text = registration.CarMarkModelVIN;
                dateTimePicker.Value = registration.Date;
            }
            switch (currentEmployee.Role)
            {
                case "admin":
                    employeeCB.Enabled = true;
                    break;
                case "user":
                    employeeCB.Text = currentEmployee.Surname + " " +
                                      currentEmployee.Name + " " +
                                      currentEmployee.Patronymic;
                    employeeCB.Enabled = false;
                    break;
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            RegistrationRepository registrationRepository = new(context);
            try
            {
                registration.Date = dateTimePicker.Value.Date;
                if (registration.RegistrationPlate != registrationPlateText.Text)
                    registrationRepository.CheckRegistrationPlateUnique(registrationPlateText.Text);
                registration.RegistrationPlate = registrationPlateText.Text;
                DriverRepository driverRepository = new(context);
                registration.DriverId = driverRepository.GetByFIO(driverCB.Text).Id;
                EmployeeRepository employeeRepository = new(context);
                registration.EmployeeId = employeeRepository.GetByFIO(employeeCB.Text).Id;
                CarRepository carRepository = new(context);
                registration.CarId = carRepository.GetByMarkModelVIN(carCB.Text).Id;
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
                registrationRepository.Add(registration);
            }
            else if (IUstatus == 1)
            {
                registrationRepository.Update(registration);
            }
            Close();
        }
    }
}
