using System.Data.SqlClient;
using System.Data;
using WinFormsApp1;
using License = GAI.Classes.License;

namespace GAI.Repository
{
    public class LicenseRepository : Repository<License>
    {
        public DBContext context;
        public LicenseRepository(DBContext context)
        {
            this.context = context;
        }
        public License? GetById(int id)
        {
            string query = @"SELECT Код
                                   ,Номер
	                               ,[Дата выдачи]
	                               ,[Срок действия]
	                               ,[Код водителя]
                                   ,[ФИО Водителя]
	                               ,Категории
                               FROM ВодительскоеУдостоверениеExt
                               WHERE Код = @id";
            SqlCommand command = new SqlCommand(query, context.Connection);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                License? license = new()
                {
                    Id = (int)reader["Код"],
                    Number = reader["Номер"].ToString(),
                    DateOfIssue = (DateTime)reader["Дата выдачи"],
                    Validity = (DateTime)reader["Срок действия"],
                    DriverId = (int)reader["Код водителя"],
                    DriverFIO = reader["ФИО водителя"].ToString(),
                    Categories = reader["Категории"].ToString().Split(',').ToList()
                };
                reader.Close();
                return license;
            }
            else
            {
                reader.Close();
                return null;
            }

        }
        public DataTable GetAll()
        {
            string query = @"SELECT Код
                                   ,Номер
	                               ,[Дата выдачи]
	                               ,[Срок действия]
	                               ,[Код водителя]
                                   ,[ФИО Водителя]
	                               ,Категории
                               FROM ВодительскоеУдостоверениеExt";
            SqlDataAdapter adapter = new(query, context.Connection);
            DataTable dataTable = new();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public void Add(License license)
        {
            string query = @"INSERT INTO [Водительское удостоверение] VALUES
                               (@Number,@DateOfIssue,@Validity,@DriverId)";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@Number", license.Number);
            command.Parameters.AddWithValue("@DateOfIssue", license.DateOfIssue);
            command.Parameters.AddWithValue("@Validity", license.Validity);
            command.Parameters.AddWithValue("@DriverId", license.DriverId);
            command.ExecuteNonQuery();

            query = @"SELECT Код FROM [Водительское удостоверение]
                        WHERE Номер = @Number";
            command = new(query, context.Connection);
            command.Parameters.AddWithValue("@Number", license.Number);
            license.Id = (int)command.ExecuteScalar();

            query = @"INSERT INTO [Категории удостоверения]
                        SELECT Код, @LicenseId FROM Категория
                        WHERE Наименование IN ({0})";
            string parameterNames = string.Join(",", 
                license.Categories.Select((_, index) => "@Category" + index));
            query = string.Format(query, parameterNames);
            command = new SqlCommand(query, context.Connection);
            for (int i = 0; i < license.Categories.Count; i++)
            {
                command.Parameters.AddWithValue("@Category" + i, license.Categories[i]);
            }
            command.Parameters.AddWithValue("@LicenseId", license.Id);
            command.ExecuteNonQuery();
        }
        public void Update(License license)
        {
            string query = @"DELETE FROM [Категории удостоверения]
                               WHERE [Код водительского удостоверения] = @LicenseId";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@LicenseId", license.Id);
            command.ExecuteNonQuery();

            query = @"UPDATE [Водительское удостоверение] SET
                             Номер = @Number
                            ,[Дата выдачи] = @DateOfIssue
                            ,[Срок действия] = @Validity
                            ,[Код водителя] = @DriverId
                       WHERE Код = @Id";
            command = new(query, context.Connection);
            command.Parameters.AddWithValue("@Id", license.Id);
            command.Parameters.AddWithValue("@Number", license.Number);
            command.Parameters.AddWithValue("@DateOfIssue", license.DateOfIssue);
            command.Parameters.AddWithValue("@Validity", license.Validity);
            command.Parameters.AddWithValue("@DriverId", license.DriverId);
            command.ExecuteNonQuery();

            query = @"INSERT INTO [Категории удостоверения]
                        SELECT Код, @LicenseId FROM Категория
                        WHERE Наименование IN ({0})";
            string parameterNames = string.Join(",",
                license.Categories.Select((_, index) => "@Category" + index));
            query = string.Format(query, parameterNames);
            command = new SqlCommand(query, context.Connection);
            for (int i = 0; i < license.Categories.Count; i++)
            {
                command.Parameters.AddWithValue("@Category" + i, license.Categories[i]);
            }
            command.Parameters.AddWithValue("@LicenseId", license.Id);
            command.ExecuteNonQuery();
        }
        public void Delete(int id)
        {
            string query = @"DELETE FROM [Водительское удостоверение] WHERE Код = @id";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
        public void CheckNumberUnique(string number)
        {
            string query = @"SELECT COUNT(*) FROM [Водительское удостоверение]
                               WHERE Номер = @Number";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@Number", number);
            if ((int)command.ExecuteScalar() != 0)
                throw new Exception("Номер водительского удостоверения должен быть уникальным!");
        }
        public void DeleteExt()
        {
            string query = @"EXEC КоличествоВодительскихУдостоверений";
            SqlCommand command = new(query, context.Connection);
            int countDeleted = (int)command.ExecuteScalar();

            var result = MessageBox.Show(
                "Вы уверены, что хотите выполнить эту операцию?\n" +
               $"Будет удалено {countDeleted} записи(ей)."
               ,"Подтверждение"
               ,MessageBoxButtons.OKCancel
               ,MessageBoxIcon.Question
               ,MessageBoxDefaultButton.Button1
                );
            if (result == DialogResult.OK)
            {
                query = @"EXEC УдалениеВодительскихУдостоверений";
                command = new(query, context.Connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
