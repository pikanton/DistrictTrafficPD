namespace GAI.Classes
{
    public class TypeOfViolation
    {
        private string? title;
        public int? Id { get; set; }
        public string? Title 
        {
            get { return title; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Тип нарушения не может быть пустым!");
                }
                else if (value?.Length > 255)
                {
                    throw new Exception("Длина типа нарушения должна быть меньше 255 символов!");
                }
                else
                    title = value;
            }
        }
    }
}
