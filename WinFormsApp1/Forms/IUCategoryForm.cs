using GAI.Classes;
using GAI.Repository;
using WinFormsApp1;

namespace GAI.Forms
{
    public partial class IUCategoryForm : Form
    {
        private DBContext context;
        private Category category;
        private int IUstatus; //0 если форма открыта на добавление, 1 если на изменение
        public IUCategoryForm(DBContext context, Category? category = null)
        {
            this.context = context;
            if (category != null)
            {
                this.category = category;
                IUstatus = 1;
            }
            else
            {
                this.category = new Category();
                IUstatus = 0;
            }
            InitializeComponent();
        }

        private void IUCategoryForm_Load(object sender, EventArgs e)
        {
            if (IUstatus == 0)
            {
                Text = "Добавление категории";
            }
            else if (IUstatus == 1)
            {
                Text = "Изменение категории";
                titleText.Text = category.Title;
                descriptionText.Text = category.Description;
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            CategoryRepository categoryRepository = new(context);
            try
            {
                if (category.Title != titleText.Text)
                    categoryRepository.CheckTitleUnique(titleText.Text);
                category.Title = titleText.Text;
                category.Description = descriptionText.Text;
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
                categoryRepository.Add(category);
            }
            else if (IUstatus == 1)
            {
                categoryRepository.Update(category);
            }
            Close();
        }
    }
}
