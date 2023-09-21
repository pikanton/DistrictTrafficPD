namespace GAI.Classes
{
    public class License
    {
        private string? number;
        public int? Id { get; set; }
        public string? Number
        {
            get { return number; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Номер удостоверения не может быть пустым!");
                }
                else if (value?.Length > 7)
                {
                    throw new Exception("Длина номера удостоверения не должна быть больше 7 символов!");
                }
                else
                    number = value;
            }
        }
        public DateTime DateOfIssue { get; set; }
        public DateTime Validity { get; set; }
        public int? DriverId { get; set; }
        public string? DriverFIO { get; set; }
        public List<string>? Categories { get; set; }
    }
}
