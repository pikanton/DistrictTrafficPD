using GAI.Classes;
using GAI.Repository;
using WinFormsApp1;

namespace GAI.Forms
{
    public partial class IUViolationForm : Form
    {
        private DBContext context;
        private Violation violation;
        private Employee currentEmployee;
        private int IUstatus; //0 если форма открыта на добавление, 1 если на изменение
        public IUViolationForm(DBContext context, Employee currentEmployee, Violation? violation = null)
        {
            this.context = context;
            this.currentEmployee = currentEmployee;
            if (violation != null)
            {
                this.violation = violation;
                IUstatus = 1;
            }
            else
            {
                this.violation = new Violation();
                IUstatus = 0;
            }
            InitializeComponent();
        }

        private void IUViolationForm_Load(object sender, EventArgs e)
        {
            driverCB.Items.Clear();
            DriverRepository driverRepository = new(context);
            driverCB.Items.AddRange(driverRepository.GetAllFIO());
            employeeCB.Items.Clear();
            EmployeeRepository employeeRepository = new(context);
            employeeCB.Items.AddRange(employeeRepository.GetAllFIO());
            typeCB.Items.Clear();
            TypeOfViolationRepository typeOfViolationRepository = new(context);
            typeCB.Items.AddRange(typeOfViolationRepository.GetAllTitles());
            driverCB.SelectedIndex = 0;
            employeeCB.SelectedIndex = 0;
            typeCB.SelectedIndex = 0;
            if (IUstatus == 0)
            {
                Text = "Регистрация нарушения";
            }
            else if (IUstatus == 1)
            {
                Text = "Изменение нарушения";
                protocolText.Text = violation.ProtocolNumber;
                fineText.Text = violation.Fine.ToString();
                termOfDeprivationText.Text = violation.TermOfDeprivation.ToString();
                driverCB.Text = violation.DriverFIO;
                employeeCB.Text = violation.EmployeeFIO;
                typeCB.Text = violation.TypeTitle;
                dateTimePicker.Value = violation.Date;
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
            try
            {
                violation.Date = dateTimePicker.Value.Date;
                violation.ProtocolNumber = protocolText.Text;
                violation.Fine = string.IsNullOrEmpty(fineText.Text)
                    ? null : decimal.Parse(fineText.Text);
                violation.TermOfDeprivation = string.IsNullOrEmpty(termOfDeprivationText.Text)
                    ? null : int.Parse(termOfDeprivationText.Text);
                DriverRepository driverRepository = new(context);
                violation.DriverId = driverRepository.GetByFIO(driverCB.Text).Id;
                EmployeeRepository employeeRepository = new(context);
                violation.EmployeeId = employeeRepository.GetByFIO(employeeCB.Text).Id;
                TypeOfViolationRepository typeOfViolationRepository = new(context);
                violation.TypeId = typeOfViolationRepository.GetByTitle(typeCB.Text).Id;
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
            ViolationRepository violationRepository = new(context);
            if (IUstatus == 0)
            {
                violationRepository.Add(violation);
            }
            else if (IUstatus == 1)
            {
                violationRepository.Update(violation);
            }
            Close();
        }
    }
}
