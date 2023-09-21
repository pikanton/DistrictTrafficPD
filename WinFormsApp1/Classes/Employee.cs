namespace GAI.Classes
{
    public class Employee
    {
        private string? userName;
        private string? password;
        private string? name;
        private string? surname;
        private string? patronymic;
        private string? phoneNumber;
        public int? Id { get; set; }
        public string? UserName 
        {
            get { return userName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Логин не может быть пустым!");
                }
                else if (value?.Length > 30)
                {
                    throw new Exception("Длина логина не должна быть больше 30 символов!");
                }
                else
                    userName = value;
            }
        }
        public string? Password 
        { 
            get { return password; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Пароль не может быть пустым!");
                }
                else if (value?.Length < 6)
                {
                    throw new Exception("Длина пароля не должна быть меньше 6 символов!");
                }
                else if (value?.Length > 30)
                {
                    throw new Exception("Длина пароля не должна быть больше 30 символов!");
                }
                else
                    password = value;
            } 
        }
        public string? HashedPassword { get; set; }
        public string? Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Имя сотрудника не может быть пустым!");
                }
                else if (value?.Length > 30)
                {
                    throw new Exception("Длина имени сотрудника не должна быть больше 30 символов!");
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
                    throw new Exception("Фамилия сотрудника не может быть пустой!");
                }
                else if (value?.Length > 30)
                {
                    throw new Exception("Длина фамилии сотрудника не должна быть больше 30 символов!");
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
                    throw new Exception("Длина отчества сотрудника не должна быть больше 30 символов!");
                }
                else
                    patronymic = value;
            }
        }
        public string? PhoneNumber
        {
            get { return phoneNumber; }
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
        public int? RangId { get; set; }
        public int? RoleId { get; set; }
        public string? RangTitle { get; set; }
        public string? Role { get; set; }
    }
}
