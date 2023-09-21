using GAI.Classes;
using System.Data.SqlClient;
using System.Data;
using WinFormsApp1;

namespace GAI.Repository
{
    public class DriverRepository : Repository<Driver>
    {
        public DBContext context;
        public DriverRepository(DBContext context)
        {
            this.context = context;
        }
        public Driver? GetById(int id)
        {
            string query = @"SELECT Код, Фамилия, Имя, Отчество, Паспорт, Телефон 
                               FROM Водитель WHERE Код = @id";
            SqlCommand command = new SqlCommand(query, context.Connection);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Driver? driver = new()
                {
                    Id = (int)reader["Код"],
                    Name = reader["Имя"].ToString(),
                    Surname = reader["Фамилия"].ToString(),
                    Patronymic = reader["Отчество"].ToString(),
                    Passport = reader["Паспорт"].ToString(),
                    PhoneNumber = reader["Телефон"].ToString()
                };
                reader.Close();
                return driver;
            }
            else
            {
                reader.Close();
                return null;
            }

        }
        public DataTable GetAll()
        {
            string query = @"SELECT Код, Фамилия, Имя, Отчество, Паспорт, Телефон 
                               FROM Водитель";
            SqlDataAdapter adapter = new(query, context.Connection);
            DataTable dataTable = new();
            adapter.Fill(dataTable);
            return dataTable;
        }
        public string[] GetAllFIO()
        {
            string query = @"SELECT dbo.ФИОВодителя(Код) AS [ФИО водителя]
                               FROM Водитель";
            SqlCommand command = new(query, context.Connection);
            SqlDataReader reader = command.ExecuteReader();
            List<string> list = new();
            while (reader.Read())
            {
                list.Add(reader["ФИО водителя"].ToString());
            }
            reader.Close();
            return list.ToArray();
        }
        public Driver? GetByFIO(string FIO)
        {
            string[] splitedFIO = FIO.Split(' ');
            if (splitedFIO.Length != 4)
            {
                throw new Exception("ФИО записано неверно!");
            }
            string query = @"SELECT Код, Фамилия, Имя, Отчество, Паспорт, Телефон 
                               FROM Водитель WHERE Фамилия = @Surname
                                 AND Имя = @Name AND Отчество = @Patronymic 
                                 AND Паспорт = @Passport";
            SqlCommand command = new SqlCommand(query, context.Connection);
            command.Parameters.AddWithValue("@Surname", splitedFIO[0]);
            command.Parameters.AddWithValue("@Name", splitedFIO[1]);
            command.Parameters.AddWithValue("@Patronymic", splitedFIO[2]);
            command.Parameters.AddWithValue("@Passport", splitedFIO[3]);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Driver? driver = new()
                {
                    Id = (int)reader["Код"],
                    Name = reader["Имя"].ToString(),
                    Surname = reader["Фамилия"].ToString(),
                    Patronymic = reader["Отчество"].ToString(),
                    Passport = reader["Паспорт"].ToString(),
                    PhoneNumber = reader["Телефон"].ToString()
                };
                reader.Close();
                return driver;
            }
            else
            {
                reader.Close();
                return null;
            }
        }
        public void Add(Driver driver)
        {
            string query = @"INSERT INTO Водитель VALUES
                               (@Surname,@Name,@Patronymic,@Passport,@PhoneNumber)";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@Surname", driver.Surname);
            command.Parameters.AddWithValue("@Name", driver.Name);
            command.Parameters.AddWithValue("@Patronymic", driver.Patronymic);
            command.Parameters.AddWithValue("@Passport", driver.Passport);
            command.Parameters.AddWithValue("@PhoneNumber", driver.PhoneNumber);
            command.ExecuteNonQuery();
        }
        public void Update(Driver driver)
        {
            string query = @"UPDATE Водитель SET
                               Фамилия = @Surname
                             , Имя = @Name
                             , Отчество = @Patronymic
                             , Паспорт = @Passport
                             , Телефон = @PhoneNumber
                               WHERE Код = @Id";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@Id", driver.Id);
            command.Parameters.AddWithValue("@Surname", driver.Surname);
            command.Parameters.AddWithValue("@Name", driver.Name);
            command.Parameters.AddWithValue("@Patronymic", driver.Patronymic);
            command.Parameters.AddWithValue("@Passport", driver.Passport);
            command.Parameters.AddWithValue("@PhoneNumber", driver.PhoneNumber);
            command.ExecuteNonQuery();
        }
        public void Delete(int id)
        {
            string query = @"SELECT COUNT(*) FROM Регистрация 
                               WHERE [Код водителя] = @id";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@id", id);
            int registrationsCount = (int)command.ExecuteScalar();

            query = @"SELECT COUNT(*) FROM Нарушение 
                        WHERE [Код водителя] = @id";
            command = new(query, context.Connection);
            command.Parameters.AddWithValue("@id", id);
            int violationsCount = (int)command.ExecuteScalar();

            query = @"SELECT COUNT(*) FROM [Водительское удостоверение] 
                        WHERE [Код водителя] = @id";
            command = new(query, context.Connection);
            command.Parameters.AddWithValue("@id", id);
            int licensesCount = (int)command.ExecuteScalar();

            var result = MessageBox.Show("Вы уверены, что хотите удалить эту запись?\n" +
                                        $"У данного водителя есть {registrationsCount} регистраци(и/я/й),\n" +
                                        $"{licensesCount} водительск(ое/их) удостоверени(е/я/й)\n" +
                                        $"и {violationsCount} нарушени(е/я/й),\n" +
                                        $"они тоже будут удалены!"
                                           , "Подтверждение"
                                           , MessageBoxButtons.OKCancel
                                           , MessageBoxIcon.Question
                                           , MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                query = @"DELETE FROM Водитель WHERE Код = @id";
                command = new(query, context.Connection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
        public void CheckPassportUnique(string passport)
        {
            string query = @"SELECT COUNT(*) FROM Водитель
                               WHERE Паспорт = @Passport";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@Passport", passport);
            if ((int)command.ExecuteScalar() != 0)
                throw new Exception("Номер паспорта должен быть уникальным!");
        }
    }
}
