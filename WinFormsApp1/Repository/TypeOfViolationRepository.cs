using GAI.Classes;
using System.Data.SqlClient;
using System.Data;
using WinFormsApp1;

namespace GAI.Repository
{
    public class TypeOfViolationRepository : Repository<TypeOfViolation>
    {
        public DBContext context;
        public TypeOfViolationRepository(DBContext context)
        {
            this.context = context;
        }
        public TypeOfViolation? GetById(int id)
        {
            string query = @"SELECT Код, Наименование
                             FROM [Тип нарушения] WHERE Код = @id";
            SqlCommand command = new SqlCommand(query, context.Connection);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                TypeOfViolation? typeOfViolation = new()
                {
                    Id = (int)reader["Код"],
                    Title = reader["Наименование"].ToString(),
                };
                reader.Close();
                return typeOfViolation;
            }
            else
            {
                reader.Close();
                return null;
            }
        }
        public DataTable GetAll()
        {
            string query = @"SELECT Код, Наименование
                             FROM [Тип нарушения]";
            SqlDataAdapter adapter = new(query, context.Connection);
            DataTable dataTable = new();
            adapter.Fill(dataTable);
            return dataTable;
        }
        public string[] GetAllTitles()
        {
            string query = @"SELECT Наименование
                               FROM [Тип нарушения]";
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
        public TypeOfViolation? GetByTitle(string title)
        {
            string query = @"SELECT Код, Наименование
                             FROM [Тип нарушения] WHERE Наименование = @Title";
            SqlCommand command = new SqlCommand(query, context.Connection);
            command.Parameters.AddWithValue("@Title", title);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                TypeOfViolation? typeOfViolation = new()
                {
                    Id = (int)reader["Код"],
                    Title = reader["Наименование"].ToString(),
                };
                reader.Close();
                return typeOfViolation;
            }
            else
            {
                reader.Close();
                return null;
            }
        }
        public void Add(TypeOfViolation typeOfViolation)
        {
            string query = @"INSERT INTO [Тип нарушения] VALUES
                               (@Title)";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@Title", typeOfViolation.Title);
            command.ExecuteNonQuery();
        }
        public void Update(TypeOfViolation typeOfViolation)
        {
            string query = @"UPDATE [Тип нарушения] SET
                               Наименование = @Title
                               WHERE Код = @Id";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@Id", typeOfViolation.Id);
            command.Parameters.AddWithValue("@Title", typeOfViolation.Title);
            command.ExecuteNonQuery();
        }
        public void Delete(int id)
        {
            string query = @"SELECT COUNT(*) FROM Нарушение
                               WHERE [Код нарушения] = @id";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@id", id);
            int violationsCount = (int)command.ExecuteScalar();

            if (violationsCount > 0)
            {
                MessageBox.Show("Нельзя удлаять запись! \n" +
                               $"Существует {violationsCount} нарушений с этим типом!"
                                           , "Ошибка"
                                           , MessageBoxButtons.OKCancel
                                           , MessageBoxIcon.Error
                                           , MessageBoxDefaultButton.Button1);
                return;
            }
            query = @"DELETE FROM [Тип нарушения] WHERE Код = @id";
            command = new(query, context.Connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
        public void CheckTitleUnique(string title)
        {
            string query = @"SELECT COUNT(*) FROM [Тип нарушения]
                               WHERE Наименование = @Title";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@Title", title);
            if ((int)command.ExecuteScalar() != 0)
                throw new Exception("Тип нарушения должен быть уникальным!");
        }
    }
}
