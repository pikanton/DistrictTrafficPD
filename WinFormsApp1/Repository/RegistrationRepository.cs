using GAI.Classes;
using System.Data.SqlClient;
using System.Data;
using WinFormsApp1;

namespace GAI.Repository
{
    public class RegistrationRepository
    {
        public DBContext context;
        public RegistrationRepository(DBContext context)
        {
            this.context = context;
        }
        public Registration? GetById(int id)
        {
            string query = @"SELECT Код, [Регистрационный знак], Дата, [Код автомобиля],
                                    [Код водителя], [Код сотрудника],
                                    [ФИО Водителя],
                                    [ФИО Сотрудника],
                                    [Автомобиль]
                               FROM РегистрацияExt
                               WHERE Регистрация.Код = @id";
            SqlCommand command = new SqlCommand(query, context.Connection);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Registration? registration = new()
                {
                    Id = (int)reader["Код"],
                    RegistrationPlate = reader["Регистрационный знак"].ToString(),
                    Date = (DateTime)reader["Дата"],
                    CarId = (int)reader["Код автомобиля"],
                    DriverId = (int)reader["Код водителя"],
                    EmployeeId = (int)reader["Код сотрудника"],
                    CarMarkModelVIN = reader["Автомобиль"].ToString(),
                    DriverFIO = reader["ФИО водителя"].ToString(),
                    EmployeeFIO = reader["ФИО сотрудника"].ToString()
                };
                reader.Close();
                return registration;
            }
            else
            {
                reader.Close();
                return null;
            }

        }
        public DataTable GetAll()
        {
            string query = @"SELECT Код, [Регистрационный знак], Дата, [Код автомобиля],
                                    [Код водителя], [Код сотрудника],
                                    [ФИО Водителя],
                                    [ФИО Сотрудника],
                                    [Автомобиль]
                               FROM РегистрацияExt";
            SqlDataAdapter adapter = new(query, context.Connection);
            DataTable dataTable = new();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public void Add(Registration registration)
        {
            string query = @"INSERT INTO Регистрация VALUES
                               (@RegistrationPlate,@Date,@CarId,@DriverId,@EmployeeId)";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@RegistrationPlate", registration.RegistrationPlate);
            command.Parameters.AddWithValue("@Date", registration.Date);
            command.Parameters.AddWithValue("@CarId", registration.CarId);
            command.Parameters.AddWithValue("@DriverId", registration.DriverId);
            command.Parameters.AddWithValue("@EmployeeId", registration.EmployeeId);
            command.ExecuteNonQuery();
        }
        public void Update(Registration registration)
        {
            string query = @"UPDATE Регистрация SET
                               [Регистрационный знак] = @RegistrationPlate
                             , Дата = @Date
                             , [Код автомобиля] = @CarId
                             , [Код водителя] = @DriverId
                             , [Код сотрудника] = @EmployeeId
                               WHERE Код = @Id";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@Id", registration.Id);
            command.Parameters.AddWithValue("@RegistrationPlate", registration.RegistrationPlate);
            command.Parameters.AddWithValue("@Date", registration.Date);
            command.Parameters.AddWithValue("@CarId", registration.CarId);
            command.Parameters.AddWithValue("@DriverId", registration.DriverId);
            command.Parameters.AddWithValue("@EmployeeId", registration.EmployeeId);
            command.ExecuteNonQuery();
        }
        public void Delete(int id)
        {
            string query = @"DELETE FROM Регистрация WHERE Код = @id";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
        public void CheckRegistrationPlateUnique(string registrationPlate)
        {
            string query = @"SELECT COUNT(*) FROM Регистрация 
                               WHERE [Регистрационный знак] = @RegistrationPlate";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@RegistrationPlate", registrationPlate);
            if ((int)command.ExecuteScalar() != 0)
                throw new Exception("Регистрационный знак должен быть уникальным!");
        }
        public DataTable GetRollBackView()
        {
            string query = @"SELECT * FROM Регистрация_Лог_Представление";
            SqlDataAdapter adapter = new(query, context.Connection);
            DataTable dataTable = new();
            adapter.Fill(dataTable);
            return dataTable;
        }
        public void RollBack(int id)
        {
            string query = @"EXEC Откат_Регистрации @id";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
    }
}
