using GAI.Classes;
using GAI.Repository;
using WinFormsApp1;

namespace GAI.Forms
{
    public partial class IUTypeOfViolationForm : Form
    {
        private DBContext context;
        private TypeOfViolation typeOfViolation;
        private int IUstatus; //0 если форма открыта на добавление, 1 если на изменение
        public IUTypeOfViolationForm(DBContext context, TypeOfViolation? typeOfViolation = null)
        {
            this.context = context;
            if (typeOfViolation != null)
            {
                this.typeOfViolation = typeOfViolation;
                IUstatus = 1;
            }
            else
            {
                this.typeOfViolation = new TypeOfViolation();
                IUstatus = 0;
            }
            InitializeComponent();
        }

        private void IUTypeOfViolationForm_Load(object sender, EventArgs e)
        {
            if (IUstatus == 0)
            {
                Text = "Добавление типа нарушения";
            }
            else if (IUstatus == 1)
            {
                Text = "Изменение типа нарушения";
                titleText.Text = typeOfViolation.Title;
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            TypeOfViolationRepository typeOfViolationRepository = new(context);
            try
            {
                if (typeOfViolation.Title != titleText.Text)
                    typeOfViolationRepository.CheckTitleUnique(titleText.Text);
                typeOfViolation.Title = titleText.Text;
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
                typeOfViolationRepository.Add(typeOfViolation);
            }
            else if (IUstatus == 1)
            {
                typeOfViolationRepository.Update(typeOfViolation);
            }
            Close();
        }
    }
}
