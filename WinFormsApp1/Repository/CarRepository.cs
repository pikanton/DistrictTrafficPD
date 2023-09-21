using GAI.Classes;
using System.Data.SqlClient;
using System.Data;
using WinFormsApp1;

namespace GAI.Repository
{
    public class CarRepository : Repository<Car>
    {
        public DBContext context;
        public CarRepository(DBContext context)
        {
            this.context = context;
        }
        public Car? GetById(int id)
        {
            string query = @"SELECT Код, VIN, Марка, Модель, Цвет 
                               FROM Автомобиль WHERE Код = @id";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Car? car = new()
                {    
                    Id = (int)reader["Код"],
                    VIN = reader["VIN"].ToString(),
                    Mark = reader["Марка"].ToString(),
                    Model = reader["Модель"].ToString(),
                    Color = reader["Цвет"].ToString(),
                };
                reader.Close();
                return car;
            }
            else
            {
                reader.Close();
                return null;
            }

        }
        public DataTable GetAll()
        {
            string query = @"SELECT Код, VIN, Марка, Модель, Цвет 
                               FROM Автомобиль";
            SqlDataAdapter adapter = new(query, context.Connection);
            DataTable dataTable = new();
            adapter.Fill(dataTable);
            return dataTable;
        }
        public string[] GetAllMarkModelVIN()
        {
            string query = @"SELECT dbo.МаркаМодельVINАвтомобиля(Код) AS Автомобиль
                               FROM Автомобиль";
            SqlCommand command = new(query, context.Connection);
            SqlDataReader reader = command.ExecuteReader();
            List<string> list = new();
            while (reader.Read())
            {
                list.Add(reader["Автомобиль"].ToString());
            }
            reader.Close();
            return list.ToArray();
        }
        public Car? GetByMarkModelVIN(string markModelVIN)
        {
            string[] splitedMarkModelVIN = markModelVIN.Split(' ');
            if (splitedMarkModelVIN.Length != 3)
            {
                throw new Exception("Информация об автомобиле записана неверно!");
            }
            string query = @"SELECT Код, VIN, Марка, Модель, Цвет 
                               FROM Автомобиль WHERE Марка = @Mark
                                 AND Модель = @Model AND VIN = @VIN";
            SqlCommand command = new SqlCommand(query, context.Connection);
            command.Parameters.AddWithValue("@Mark", splitedMarkModelVIN[0]);
            command.Parameters.AddWithValue("@Model", splitedMarkModelVIN[1]);
            command.Parameters.AddWithValue("@VIN", splitedMarkModelVIN[2]);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Car? car = new()
                {
                    Id = (int)reader["Код"],
                    VIN = reader["VIN"].ToString(),
                    Mark = reader["Марка"].ToString(),
                    Model = reader["Модель"].ToString(),
                    Color = reader["Цвет"].ToString(),
                };
                reader.Close();
                return car;
            }
            else
            {
                reader.Close();
                return null;
            }
        }
        public void Add(Car car)
        {
            string query = @"INSERT INTO Автомобиль VALUES
                               (@VIN,@Mark,@Model,@Color)";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@VIN", car.VIN);
            command.Parameters.AddWithValue("@Mark", car.Mark);
            command.Parameters.AddWithValue("@Model", car.Model);
            command.Parameters.AddWithValue("@Color", car.Color);
            command.ExecuteNonQuery();
        }
        public void Update(Car car)
        {
            string query = @"UPDATE Автомобиль SET
                               VIN = @VIN
                             , Марка = @Mark
                             , Модель = @Model
                             , Цвет = @Color
                               WHERE Код = @Id";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@Id", car.Id);
            command.Parameters.AddWithValue("@VIN", car.VIN);
            command.Parameters.AddWithValue("@Mark", car.Mark);
            command.Parameters.AddWithValue("@Model", car.Model);
            command.Parameters.AddWithValue("@Color", car.Color);
            command.ExecuteNonQuery();
        }
        public void Delete(int id)
        {
            string query = @"SELECT COUNT(*) FROM Регистрация 
                               WHERE [Код автомобиля] = @id";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@id", id);
            int registrationsCount = (int)command.ExecuteScalar();
            var result = MessageBox.Show("Вы уверены, что хотите удалить эту запись?\n" +
                                        $"У данного автомобиля есть {registrationsCount} регистраци(и/я/й),\n" +
                                        $"они тоже будут удалены!"
                                           , "Подтверждение"
                                           , MessageBoxButtons.OKCancel
                                           , MessageBoxIcon.Question
                                           , MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                query = @"DELETE FROM Автомобиль WHERE Код = @id";
                command = new(query, context.Connection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
        public void CheckVINUnique(string vin)
        {
            string query = @"SELECT COUNT(*) FROM Автомобиль
                               WHERE VIN = @VIN";
            SqlCommand command = new(query, context.Connection);
            command.Parameters.AddWithValue("@VIN", vin);
            if ((int)command.ExecuteScalar() != 0)
                throw new Exception("Номер VIN должен быть уникальным!");
        }
    }
}
