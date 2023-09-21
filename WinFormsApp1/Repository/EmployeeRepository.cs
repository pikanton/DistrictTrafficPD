using GAI.Classes;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using WinFormsApp1;

namespace GAI.Repository
{
    public class EmployeeRepository : Repository<Employee>
    {
        public DBContext context;
        public EmployeeRepository(DBContext context)
        {
            this.context = context;
        }
        public Employee? GetById(int id)
        {
            string query = "SELECT Код, Логин, Пароль, Фамилия, Имя, Отчество, Телефон, [Код звания]" +
                           "      ,[Код роли], Звание, Роль " +
                           "FROM СотрудникExt " +
                           "WHERE Код = @id";

SqlCommand command = new SqlCommand(query, context.Connection);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Employee? employee = new()
                {
                    Id = (int)reader["Код"],
                    UserName = reader["Логин"].ToString(),
                    HashedPassword = reader["Пароль"].ToString(),
                    Name = reader["Имя"].ToString(),
                    Surname = reader["Фамилия"].ToString(),
                    Patronymic = reader["Отчество"].ToString(),
                    PhoneNumber = reader["Телефон"].ToString(),
                    RangId = (int)reader["Код звания"],
                    RoleId = (int)reader["Код роли"],
                    RangTitle = reader["Звание"].ToString(),
                    Role = reader["Роль"].ToString()
                };
                reader.Close();
                return employee;
            }
            else
            {
                reader.Close();
                return null;
            }

        }
        public DataTable GetAll()
        {
            string query = "SELECT Код, Логин, Пароль, Фамилия, Имя, Отчество, Телефон, [Код звания]" +
                           "      ,[Код роли], Звание, Роль " +
                           "FROM СотрудникExt";
            SqlDataAdapter adapter = new(query, context.Connection);
            DataTable dataTable = new();
            adapter.Fill(dataTable);
            return dataTable;
        }
        public Employee? Authorize(string username, string password)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            string hashedPassword = Convert.ToBase64String(hashedBytes);

            string query = "SELECT Код, Логин, Пароль, Фамилия, Имя, Отчество, Телефон, [Код звания]" +
                           "      ,[Код роли], Звание, Роль " +
                           "FROM СотрудникExt " +
                           "WHERE Логин = @username ";
            SqlCommand command = new SqlCommand(query, context.Connection);
            command.Parameters.AddWithValue("@username", username);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                string? dbPassword = reader["Пароль"].ToString();
                if (hashedPassword.Equals(dbPassword))
                {
                    Employee? employee = new()
                    {
                        Id = (int)reader["Код"],
                        UserName = reader["Логин"].ToString(),
                        HashedPassword = reader["Пароль"].ToString(),
                        Name = reader["Имя"].ToString(),
                        Surname = reader["Фамилия"].ToString(),
                        Patronymic = reader["Отчество"].ToString(),
                        PhoneNumber = reader["Телефон"].ToString(),
                        RangId = (int)reader["Код звания"],
                        RoleId = (int)reader["Код роли"],
                        RangTitle = reader["Звание"].ToString(),
                        Role = reader["Роль"].ToString()
                    };
                    reader.Close();
                    return employee;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
            else { return null; }
        }
        public string[] GetAllFIO()
        {
            string query = @"SELECT dbo.ФИОСотрудника(Код) AS [ФИО сотрудника]
                               FROM Сотрудник";
            SqlCommand command = new(query, context.Connection);
            SqlDataReader reader = command.ExecuteReader();
            List<string> list = new();
            while (reader.Read())
            {
                list.Add(reader["ФИО сотрудника"].ToString());
            }
            reader.Close();
            return list.ToArray();
        }
        public Employee? GetByFIO(string FIO)
        {
            string[] splitedFIO = FIO.Split(' ');
            if (splitedFIO.Length != 3)
            {
                throw new Exception("ФИО записано неверно!");
            }
            string query = @"SELECT Код, Логин, Пароль, Фамилия, Имя
                              ,Отчество, Телефон, [Код звания], [Код роли]
                              ,Звание, Роль 
                              FROM СотрудникExt
                              WHERE Фамилия = @Surname
                                AND Имя = @Name 
                                AND Отчество = @Patronymic";
            SqlCommand command = new SqlCommand(query, context.Connection);
            command.Parameters.AddWithValue("@Surname", splitedFIO[0]);
            command.Parameters.AddWithValue("@Name", splitedFIO[1]);
            command.Parameters.AddWithValue("@Patronymic", splitedFIO[2]);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Employee? employee = new()
                {
                    Id = (int)reader["Код"],
                    UserName = reader["Логин"].ToString(),
                    HashedPassword = reader["Пароль"].ToString(),
                    Name = reader["Имя"].ToString(),
                    Surname = reader["Фамилия"].ToString(),
                    Patronymic = reader["Отчество"].ToString(),
                    PhoneNumber = reader["Телефон"].ToString(),
                    RangId = (int)reader["Код звания"],
                    RoleId = (int)reader["Код роли"],
                    RangTitle = reader["Звание"].ToString(),
                    Role = reader["Роль"].ToString()
                };
                reader.Close();
                return employee;
            }
            else
            {
                reader.Close();
                return null;
            }
        }
        public string[] GetAllRoles()
        {
            string query = @"SELECT Наименование
                               FROM Роль";
            SqlCommand command = new(query, context.Connection);
            SqlDataReader reader = command.ExecuteReader();
            List<string> list = new();
            while (reader.Read())
            {
                list.Add(reader["Наименование"].ToString());
            }
            reader.Close();
            return list.ToArray();
        }
        public int? GetRoleIdByTitle(string title)
        {
            string query = @"SELECT Код
                             FROM Роль WHERE Наименование = @Title";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@Title", title);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int id = (int)reader["Код"];
                reader.Close();
                return id;
            }
            else
            {
                reader.Close();
                return null;
            }
        }
        public void Add(Employee employee)
        {
            string query = @"INSERT INTO Сотрудник VALUES
                               (@UserName,@HashedPassword,@Surname,@Name,@Patronymic,@PhoneNumber,@RangId,@RoleId)";
            SqlCommand command = new(query, context.Connection);
            SHA256 sha256 = SHA256.Create();
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(employee.Password));
            string hashedPassword = Convert.ToBase64String(hashedBytes);
            command.Parameters.AddWithValue("@UserName", employee.UserName);
            command.Parameters.AddWithValue("@HashedPassword", hashedPassword);
            command.Parameters.AddWithValue("@Surname", employee.Surname);
            command.Parameters.AddWithValue("@Name", employee.Name);
            command.Parameters.AddWithValue("@Patronymic", employee.Patronymic);
            command.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
            command.Parameters.AddWithValue("@RangId", employee.RangId);
            command.Parameters.AddWithValue("@RoleId", employee.RoleId);
            command.ExecuteNonQuery();
        }
        public void Update(Employee employee)
        {
            if (employee.Password == null)
            {
                string query = @"UPDATE Сотрудник SET
                               Логин = @UserName
                              ,Фамилия = @Surname
                              ,Имя = @Name
                              ,Отчество = @Patronymic
                              ,Телефон = @PhoneNumber
                              ,[Код звания] = @RangId
                              ,[Код роли] = @RoleId
                              WHERE Код = @Id";
                SqlCommand command = new(query, context.Connection);
                command.Parameters.AddWithValue("@Id", employee.Id);
                command.Parameters.AddWithValue("@UserName", employee.UserName);
                command.Parameters.AddWithValue("@Surname", employee.Surname);
                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@Patronymic", employee.Patronymic);
                command.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                command.Parameters.AddWithValue("@RangId", employee.RangId);
                command.Parameters.AddWithValue("@RoleId", employee.RoleId);
                command.ExecuteNonQuery();
            }
            else
            {
                string query = @"UPDATE Сотрудник SET
                               Логин = @UserName
                              ,Пароль = @HashedPassword
                              ,Фамилия = @Surname
                              ,Имя = @Name
                              ,Отчество = @Patronymic
                              ,Телефон = @PhoneNumber
                              ,[Код звания] = @RangId
                              ,[Код роли] = @RoleId
                              WHERE Код = @Id";
                SqlCommand command = new(query, context.Connection);
                SHA256 sha256 = SHA256.Create();
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(employee.Password));
                string hashedPassword = Convert.ToBase64String(hashedBytes);
                command.Parameters.AddWithValue("@Id", employee.Id);
                command.Parameters.AddWithValue("@UserName", employee.UserName);
                command.Parameters.AddWithValue("@HashedPassword", hashedPassword);
                command.Parameters.AddWithValue("@Surname", employee.Surname);
                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@Patronymic", employee.Patronymic);
                command.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                command.Parameters.AddWithValue("@RangId", employee.RangId);
                command.Parameters.AddWithValue("@RoleId", employee.RoleId);
                command.ExecuteNonQuery();
            }
            
        }
        public void Delete(int id)
        {
            string query = @"SELECT COUNT(*) FROM Регистрация 
                               WHERE [Код сотрудника] = @id";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@id", id);
            int registrationsCount = (int)command.ExecuteScalar();

            query = @"SELECT COUNT(*) FROM Нарушение 
                        WHERE [Код сотрудника] = @id";
            command = new(query, context.Connection);
            command.Parameters.AddWithValue("@id", id);
            int violationsCount = (int)command.ExecuteScalar();

            var result = MessageBox.Show("Вы уверены, что хотите удалить эту запись?\n" +
                                        $"У данного сотрудника есть {registrationsCount} регистраци(и/я/й)\n" +
                                        $"и {violationsCount} нарушени(е/я/й),\n" +
                                        $"они тоже будут удалены!"
                                           , "Подтверждение"
                                           , MessageBoxButtons.OKCancel
                                           , MessageBoxIcon.Question
                                           , MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                query = @"DELETE FROM Сотрудник WHERE Код = @id";
                command = new(query, context.Connection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
