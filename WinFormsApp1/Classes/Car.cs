using System.Xml.Linq;

namespace GAI.Classes
{
    public class Car
    {
        private string? vin;
        private string? mark;
        private string? model;
        private string? color;
        public int? Id { get; set; }
        public string? VIN 
        {
            get { return vin; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("VIN не может быть пустым!");
                }
                else if (value?.Length != 17)
                {
                    throw new Exception("Длина VIN должна быть ровно 17 символов!");
                }
                else
                    vin = value;
            }
        }
        public string? Mark
        {
            get { return mark; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Марка не может быть пустой!");
                }
                else if (value?.Length > 30)
                {
                    throw new Exception("Длина марки должна быть больше 30 символов!");
                }
                else
                    mark = value;
            }
        }
        public string? Model
        {
            get { return model; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Модель не может быть пустой!");
                }
                else if (value?.Length > 30)
                {
                    throw new Exception("Длина модели должна быть больше 30 символов!");
                }
                else
                    model = value;
            }
        }
        public string? Color
        {
            get { return color; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Цвет не может быть пустым!");
                }
                else if (value?.Length > 30)
                {
                    throw new Exception("Длина цвета должна быть больше 30 символов!");
                }
                else
                    color = value;
            }
        }
    }
}
