using GAI.Classes;
using GAI.Repository;
using WinFormsApp1;

namespace GAI.Forms
{
    public partial class IUCarForm : Form
    {
        private DBContext context;
        private Car car;
        private int IUstatus; //0 если форма открыта на добавление, 1 если на изменение
        public IUCarForm(DBContext context, Car? car = null)
        {
            this.context = context;
            if (car != null)
            {
                this.car = car;
                IUstatus = 1;
            }
            else
            {
                this.car = new Car();
                IUstatus = 0;
            }
            InitializeComponent();
        }

        private void IUCarForm_Load(object sender, EventArgs e)
        {
            if (IUstatus == 0)
            {
                Text = "Добавление автомобиля";
            }
            else if (IUstatus == 1)
            {
                Text = "Изменение автомобиля";
                VINText.Text = car.VIN;
                markText.Text = car.Mark;
                modelText.Text = car.Model;
                colorText.Text = car.Color;
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            CarRepository carRepository = new(context);
            try
            {
                if (car.VIN != VINText.Text)
                    carRepository.CheckVINUnique(VINText.Text);
                car.VIN = VINText.Text;
                car.Mark = markText.Text;
                car.Model = modelText.Text;
                car.Color = colorText.Text;
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
                carRepository.Add(car);
            }
            else if (IUstatus == 1)
            {
                carRepository.Update(car);
            }
            Close();
        }
    }
}
