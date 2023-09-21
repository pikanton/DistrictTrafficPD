using GAI.Classes;
using System.Data.SqlClient;
using System.Data;
using WinFormsApp1;
using System;

namespace GAI.Repository
{
    public class RangRepository : Repository<Rang>
    {
        public DBContext context;
        public RangRepository(DBContext context)
        {
            this.context = context;
        }
        public Rang? GetById(int id)
        {
            string query = @"SELECT Код, Наименование
                             FROM Звание WHERE Код = @id";
            SqlCommand command = new SqlCommand(query, context.Connection);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Rang? rang = new()
                {
                    Id = (int)reader["Код"],
                    Title = reader["Наименование"].ToString(),
                };
                reader.Close();
                return rang;
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
                             FROM Звание";
            SqlDataAdapter adapter = new(query, context.Connection);
            DataTable dataTable = new();
            adapter.Fill(dataTable);
            return dataTable;
        }
        public string[] GetAllTitles()
        {
            string query = @"SELECT Наименование
                               FROM Звание";
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
        public Rang? GetByTitle(string title)
        {
            string query = @"SELECT Код, Наименование
                             FROM Звание WHERE Наименование = @Title";
            SqlCommand command = new SqlCommand(query, context.Connection);
            command.Parameters.AddWithValue("@Title", title);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Rang? rang = new()
                {
                    Id = (int)reader["Код"],
                    Title = reader["Наименование"].ToString(),
                };
                reader.Close();
                return rang;
            }
            else
            {
                reader.Close();
                return null;
            }
        }
        public void Add(Rang rang)
        {
            string query = @"INSERT INTO Звание VALUES
                               (@Title)";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@Title", rang.Title);
            command.ExecuteNonQuery();
        }
        public void Update(Rang rang)
        {
            string query = @"UPDATE Звание SET
                               Наименование = @Title
                               WHERE Код = @Id";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@Id", rang.Id);
            command.Parameters.AddWithValue("@Title", rang.Title);
            command.ExecuteNonQuery();
        }
        public void Delete(int id)
        {
            string query = @"SELECT COUNT(*) FROM Сотрудник
                               WHERE [Код звания] = @id";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@id", id);
            int employeesCount = (int)command.ExecuteScalar();

            if (employeesCount > 0)
            {
                MessageBox.Show("Нельзя удалять запись! \n" +
                               $"Существует {employeesCount} сотрудник(ов/а) с этим званием!"
                                           , "Ошибка"
                                           , MessageBoxButtons.OKCancel
                                           , MessageBoxIcon.Error
                                           , MessageBoxDefaultButton.Button1);
                return;
            }
            query = @"DELETE FROM Звание WHERE Код = @id";
            command = new(query, context.Connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
        public void CheckTitleUnique(string title)
        {
            string query = @"SELECT COUNT(*) FROM Звание
                               WHERE Наименование = @Title";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@Title", title);
            if ((int)command.ExecuteScalar() != 0)
                throw new Exception("Звание должно быть уникальным!");
        }
    }
}
