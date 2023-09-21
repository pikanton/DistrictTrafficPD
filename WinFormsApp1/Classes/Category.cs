namespace GAI.Classes
{
    public class Category
    {
        private string? title;
        private string? description;
        public int? Id { get; set; }
        public string? Title
        {
            get { return title; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Категория не может быть пустой!");
                }
                else if (value?.Length > 2)
                {
                    throw new Exception("Длина категории не должна быть больше 2 символов!");
                }
                else
                    title = value;
            }
        }
        public string? Description
        {
            get { return description; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Описание не может быть пустым!");
                }
                else if (value?.Length > 255)
                {
                    throw new Exception("Длина описания не должна быть больше 255 символов!");
                }
                else
                    description = value;
            }
        }
    }
}
