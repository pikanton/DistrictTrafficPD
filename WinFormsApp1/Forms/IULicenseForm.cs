using GAI.Classes;
using GAI.Repository;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using WinFormsApp1;

namespace GAI.Forms
{
    public partial class IULicenseForm : Form
    {
        private DBContext context;
        private License license;
        private int IUstatus; //0 если форма открыта на добавление, 1 если на изменение
        public IULicenseForm(DBContext context, License? license = null)
        {
            this.context = context;
            if (license != null)
            {
                this.license = license;
                IUstatus = 1;
            }
            else
            {
                this.license = new License();
                IUstatus = 0;
            }
            InitializeComponent();
        }

        private void IULicenseForm_Load(object sender, EventArgs e)
        {
            driverCB.Items.Clear();
            DriverRepository driverRepository = new(context);
            driverCB.Items.AddRange(driverRepository.GetAllFIO());
            categoriesCLB.Items.Clear();
            CategoryRepository categoryRepository = new(context);
            categoriesCLB.Items.AddRange(categoryRepository.GetAllTitles());
            driverCB.SelectedIndex = 0;
            if (IUstatus == 0)
            {
                Text = "Регистрация водительского удостоверения";
            }
            else if (IUstatus == 1)
            {
                Text = "Изменение водительского удостоверения";
                numberText.Text = license.Number.ToString();
                dateOfIssuePicker.Value = license.DateOfIssue;
                validityPicker.Value = license.Validity;
                driverCB.Text = license.DriverFIO;
                foreach (var category in license.Categories)
                    categoriesCLB.SetItemChecked(categoriesCLB.FindStringExact(category), true);
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            LicenseRepository licenseRepository = new(context);
            try
            {
                if (license.Number != numberText.Text)
                    licenseRepository.CheckNumberUnique(numberText.Text);
                license.Number = numberText.Text;
                license.DateOfIssue = dateOfIssuePicker.Value.Date;
                license.Validity = validityPicker.Value.Date;
                DriverRepository driverRepository = new(context);
                license.DriverId = driverRepository.GetByFIO(driverCB.Text).Id;
                if (categoriesCLB.CheckedItems.Count == 0)
                {
                    throw new Exception("Выберите хотя бы одну категорию!");
                }
                license.Categories = new List<string>();
                foreach (var item in categoriesCLB.CheckedItems)
                {
                    license.Categories.Add(item.ToString());
                }
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
                licenseRepository.Add(license);
            }
            else if (IUstatus == 1)
            {
                licenseRepository.Update(license);
            }
            Close();
        }
    }
}
