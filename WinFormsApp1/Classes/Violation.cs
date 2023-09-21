namespace GAI.Classes
{
    public class Violation
    {
        private string? protocolNumber;
        private decimal? fine;
        private int? termOfDeprivation;
        public int? Id { get; set; }
        public DateTime Date { get; set; }
        public string? ProtocolNumber 
        {
            get { return protocolNumber; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Номер протокола не может быть пустым!");
                }
                else if (value?.Length > 30)
                {
                    throw new Exception("Длина номера протокола не должна быть больше 30 символов!");
                }
                else
                    protocolNumber = value;
            }
        }
        public decimal? Fine 
        {
            get { return fine; }
            set
            {
                if (value == null)
                {
                    throw new Exception("Размер штрафа не может быть пустым!");
                }
                else if (value == null)
                {
                    throw new Exception("Размер штрафа должен быть больше 0!");
                }
                else
                    fine = value;
            } 
        }
        public int? TermOfDeprivation 
        { 
            get { return termOfDeprivation; }
            set
            {
                if (value == null)
                {
                    throw new Exception("Срок лишения прав не может быть пустым!");
                }
                else if (value < 0)
                {
                    throw new Exception("Срок лишения должен быть больше 0!");
                }
                else
                    termOfDeprivation = value;
            } 
        }
        public int? DriverId { get; set; }
        public int? EmployeeId { get; set; }
        public int? TypeId { get; set; }
        public string? DriverFIO { get; set; }
        public string? EmployeeFIO { get; set; }
        public string? TypeTitle { get; set; }
    }
}
