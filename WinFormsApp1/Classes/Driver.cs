namespace GAI.Classes
{
    public class Driver
    {
        private string? name;
        private string? surname;
        private string? patronymic;
        private string? passport;
        private string? phoneNumber;
        public int? Id { get; set; }
        public string? Name 
        { 
            get { return name; } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Имя водителя не может быть пустым!");
                }
                else if (value?.Length > 30)
                {
                    throw new Exception("Длина имени водителя не должна быть больше 30 символов!");
                }
                else
                    name = value;
            }
        }
        public string? Surname 
        {
            get { return surname; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Фамилия водителя не может быть пустой!");
                }
                else if (value?.Length > 30)
                {
                    throw new Exception("Длина фамилии водителя не должна быть больше 30 символов!");
                }
                else
                    surname = value;
            } 
        }
        public string? Patronymic
        {
            get { return patronymic; }
            set
            {
                if (value?.Length > 30)
                {
                    throw new Exception("Длина отчества водителя не должна быть больше 30 символов!");
                }
                else
                    patronymic = value;
            }
        }
        public string? Passport 
        { 
            get { return passport; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Паспорт не может быть пустым!");
                }
                else if (value?.Length != 9)
                {
                    throw new Exception("Длина паспорта должна быть ровно 9 символов!");
                }
                else
                    passport = value;
            }
        }
        public string? PhoneNumber 
        {
            get { return  phoneNumber; }
            set
            {
                if (value?.Length > 11)
                {
                    throw new Exception("Длина телефона не должна быть больше 11 символов!");
                }
                else
                    phoneNumber = value;
            }
        }
    }
}
