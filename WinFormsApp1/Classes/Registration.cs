namespace GAI.Classes
{
    public class Registration
    {
        private string? registrationPlate;
        public int? Id { get; set; }
        public string? RegistrationPlate
        {
            get { return registrationPlate; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Регистрационный знак не может быть пустым!");
                }
                else if (value?.Length != 8)
                {
                    throw new Exception("Длина регистрационного знака должна быть ровно 8 символов!");
                }
                else
                    registrationPlate = value;
            }
        }
        public DateTime Date { get; set; }
        public int? CarId { get; set; }
        public int? DriverId { get; set; }
        public int? EmployeeId { get; set; }
        public string? CarMarkModelVIN { get; set; }
        public string? DriverFIO { get; set; }
        public string? EmployeeFIO { get; set; }
    }
}
