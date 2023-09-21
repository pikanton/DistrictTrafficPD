using GAI.Classes;
using System.Data.SqlClient;
using System.Data;
using WinFormsApp1;

namespace GAI.Repository
{
    public class ViolationRepository : Repository<Violation>
    {
        public DBContext context;
        public ViolationRepository(DBContext context)
        {
            this.context = context;
        }
        public Violation? GetById(int id)
        {
            string query = @"SELECT Код, Дата, [№ Протокола], [Размер штрафа], [Срок лишения прав]
                                  , [Код водителя], [Код сотрудника], [Код нарушения]
                                  , [ФИО водителя], [ФИО сотрудника], Нарушение 
                               FROM НарушениеExt
                               WHERE Нарушение.Код = @id";
            SqlCommand command = new SqlCommand(query, context.Connection);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Violation? violation = new()
                {
                    Id = (int)reader["Код"],
                    Date = (DateTime)reader["Дата"],
                    ProtocolNumber = reader["№ Протокола"].ToString(),
                    Fine = (decimal)reader["Размер штрафа"],
                    TermOfDeprivation = (int)reader["Срок лишения прав"],
                    DriverId = (int)reader["Код водителя"],
                    EmployeeId = (int)reader["Код сотрудника"],
                    TypeId = (int)reader["Код нарушения"],
                    DriverFIO = reader["ФИО водителя"].ToString(),
                    EmployeeFIO = reader["ФИО сотрудника"].ToString(),
                    TypeTitle = reader["Нарушение"].ToString()
                };
                reader.Close();
                return violation;
            }
            else
            {
                reader.Close();
                return null;
            }

        }
        public DataTable GetAll()
        {
            string query = @"SELECT Код, Дата, [№ Протокола], [Размер штрафа], [Срок лишения прав]
                                  , [Код водителя], [Код сотрудника], [Код нарушения]
                                  , [ФИО водителя], [ФИО сотрудника], Нарушение 
                               FROM НарушениеExt";
            SqlDataAdapter adapter = new(query, context.Connection);
            DataTable dataTable = new();
            adapter.Fill(dataTable);
            return dataTable;
        }
        
        public void Add(Violation violation)
        {
            string query = @"INSERT INTO Нарушение VALUES
                               (@Date,@ProtocolNumber,@Fine,@TermOfDeprivation,@DriverId,@EmployeeId,@TypeId)";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@Date", violation.Date);
            command.Parameters.AddWithValue("@ProtocolNumber", violation.ProtocolNumber);
            command.Parameters.AddWithValue("@Fine", violation.Fine);
            command.Parameters.AddWithValue("@TermOfDeprivation", violation.TermOfDeprivation);
            command.Parameters.AddWithValue("@DriverId", violation.DriverId);
            command.Parameters.AddWithValue("@EmployeeId", violation.EmployeeId);
            command.Parameters.AddWithValue("@TypeId", violation.TypeId);
            command.ExecuteNonQuery();
        }
        public void Update(Violation violation)
        {
            string query = @"UPDATE Нарушение SET
                               Дата = @Date
                              ,[№ Протокола] = @ProtocolNumber
                              ,[Размер штрафа] = @Fine
                              ,[Срок лишения прав] = @TermOfDeprivation
                              ,[Код водителя] = @DriverId
                              ,[Код сотрудника] = @EmployeeId
                              ,[Код нарушения] = @TypeId
                              WHERE Код = @Id";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@Id", violation.Id);
            command.Parameters.AddWithValue("@Date", violation.Date);
            command.Parameters.AddWithValue("@ProtocolNumber", violation.ProtocolNumber);
            command.Parameters.AddWithValue("@Fine", violation.Fine);
            command.Parameters.AddWithValue("@TermOfDeprivation", violation.TermOfDeprivation);
            command.Parameters.AddWithValue("@DriverId", violation.DriverId);
            command.Parameters.AddWithValue("@EmployeeId", violation.EmployeeId);
            command.Parameters.AddWithValue("@TypeId", violation.TypeId);
            command.ExecuteNonQuery();
        }
        public void Delete(int id) 
        {
            string query = @"DELETE FROM Нарушение WHERE Код = @id";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
    }
}
