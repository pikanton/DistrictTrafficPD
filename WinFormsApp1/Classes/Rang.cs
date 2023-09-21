namespace GAI.Classes
{
    public class Rang
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
                    throw new Exception("Звание не может быть пустым!");
                }
                else if (value?.Length > 30)
                {
                    throw new Exception("Длина звания не должна быть больше 30 символов!");
                }
                else
                    title = value;
            }
        }
    }
}
