using GAI.Classes;
using GAI.Repository;
using WinFormsApp1;

namespace GAI.Forms
{
    public partial class IUDriverForm : Form
    {
        private DBContext context;
        private Driver driver;
        private int IUstatus; //0 если форма открыта на добавление, 1 если на изменение
        public IUDriverForm(DBContext context, Driver? driver = null)
        {
            this.context = context;
            if (driver != null)
            {
                this.driver = driver;
                IUstatus = 1;
            }
            else
            {
                this.driver = new Driver();
                IUstatus = 0;
            }
            InitializeComponent();
        }

        private void IUDriverForm_Load(object sender, EventArgs e)
        {
            if (IUstatus == 0)
            {
                Text = "Добавление водителя";
            }
            else if (IUstatus == 1)
            {
                Text = "Изменение водителя";
                surnameText.Text = driver.Surname;
                nameText.Text = driver.Name;
                patronymicText.Text = driver.Patronymic;
                passportText.Text = driver.Passport;
                phoneNumberText.Text = driver.PhoneNumber;
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            DriverRepository driverRepository = new(context);
            try
            {
                driver.Surname = surnameText.Text;
                driver.Name = nameText.Text;
                driver.Patronymic = patronymicText.Text;
                if (driver.Passport != passportText.Text)
                    driverRepository.CheckPassportUnique(passportText.Text);
                driver.Passport = passportText.Text;
                driver.PhoneNumber = phoneNumberText.Text;
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
                driverRepository.Add(driver);
            }
            else if (IUstatus == 1)
            {
                driverRepository.Update(driver);
            }
            Close();
        }
    }
}
