using GAI.Classes;
using GAI.Repository;
using WinFormsApp1;

namespace GAI.Forms
{
    public partial class IURangForm : Form
    {
        private DBContext context;
        private Rang rang;
        private int IUstatus; //0 если форма открыта на добавление, 1 если на изменение
        public IURangForm(DBContext context, Rang? rang = null)
        {
            this.context = context;
            if (rang != null)
            {
                this.rang = rang;
                IUstatus = 1;
            }
            else
            {
                this.rang = new Rang();
                IUstatus = 0;
            }
            InitializeComponent();
        }

        private void IURangForm_Load(object sender, EventArgs e)
        {
            if (IUstatus == 0)
            {
                Text = "Добавление звания";
            }
            else if (IUstatus == 1)
            {
                Text = "Изменение звания";
                titleText.Text = rang.Title;
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            RangRepository rangRepository = new(context);
            try
            {
                if (rang.Title != titleText.Text)
                    rangRepository.CheckTitleUnique(titleText.Text);
                rang.Title = titleText.Text;
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
                rangRepository.Add(rang);
            }
            else if (IUstatus == 1)
            {
                rangRepository.Update(rang);
            }
            Close();
        }
    }
}
