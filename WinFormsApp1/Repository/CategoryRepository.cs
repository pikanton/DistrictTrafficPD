using GAI.Classes;
using System.Data.SqlClient;
using System.Data;
using WinFormsApp1;

namespace GAI.Repository
{
    public class CategoryRepository : Repository<Category>
    {
        public DBContext context;
        public CategoryRepository(DBContext context)
        {
            this.context = context;
        }
        public Category? GetById(int id)
        {
            string query = @"SELECT Код, Наименование, Расшифровка
                             FROM Категория WHERE Код = @id";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Category? category = new()
                {
                    Id = (int)reader["Код"],
                    Title = reader["Наименование"].ToString(),
                    Description = reader["Расшифровка"].ToString()
                };
                reader.Close();
                return category;
            }
            else
            {
                reader.Close();
                return null;
            }
        }
        public DataTable GetAll()
        {
            string query = @"SELECT Код, Наименование, Расшифровка
                             FROM Категория";
            SqlDataAdapter adapter = new(query, context.Connection);
            DataTable dataTable = new();
            adapter.Fill(dataTable);
            return dataTable;
        }
        public string[] GetAllTitles()
        {
            string query = @"SELECT Наименование
                               FROM Категория";
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
        public Category? GetByTitle(string title)
        {
            string query = @"SELECT Код, Наименование, Расшифровка
                             FROM Категория WHERE Наименование = @Title";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@Title", title);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Category? category = new()
                {
                    Id = (int)reader["Код"],
                    Title = reader["Наименование"].ToString(),
                    Description = reader["Расшифровка"].ToString()
                };
                reader.Close();
                return category;
            }
            else
            {
                reader.Close();
                return null;
            }
        }
        public void Add(Category category)
        {
            string query = @"INSERT INTO Категория VALUES
                               (@Title, @Description)";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@Title", category.Title);
            command.Parameters.AddWithValue("@Description", category.Description);
            command.ExecuteNonQuery();
        }
        public void Update(Category category)
        {
            string query = @"UPDATE Категория SET
                               Наименование = @Title
                              ,Расшифровка = @Description
                               WHERE Код = @Id";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@Id", category.Id);
            command.Parameters.AddWithValue("@Title", category.Title);
            command.Parameters.AddWithValue("@Description", category.Description);
            command.ExecuteNonQuery();
        }
        public void Delete(int id)
        {
            string query = @"SELECT COUNT(*) FROM [Категории удостоверения] 
                               WHERE [Код категории] = @id";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@id", id);
            int licensesCount = (int)command.ExecuteScalar();

            if (licensesCount > 0)
            {
                MessageBox.Show("Нельзя удалять эту запись!\n" +
                               $"Существуют {licensesCount} водительских удостоверений\n" +
                               $"с такой категорией!"
                                           , "Ошибка"
                                           , MessageBoxButtons.OKCancel
                                           , MessageBoxIcon.Error
                                           , MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                query = @"DELETE FROM Категория WHERE Код = @id";
                command = new(query, context.Connection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
        public void CheckTitleUnique(string title)
        {
            string query = @"SELECT COUNT(*) FROM Категория
                               WHERE Наименование = @Title";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@Title", title);
            if ((int)command.ExecuteScalar() != 0)
                throw new Exception("Наименование категории должно быть уникальным!");
        }
    }
}
