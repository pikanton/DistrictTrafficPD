using System.Data.SqlClient;
using WinFormsApp1;

namespace CourseProject
{
    public partial class IURoomForm : Form
    {
        private DBContext context;
        private Room room;
        private int IUstatus; //0 если форма открыта на добавление, 1 если на изменение
        List<(int, string)> types;
        public IURoomForm(DBContext context, Room? room = null)
        {
            types = new();
            this.context = context;
            if (room != null)
            {
                this.room = room;
                IUstatus = 1;
            }
            else
            {
                this.room = new Room();
                IUstatus = 0;
            }
            InitializeComponent();
        }
        private void IURoomForm_Load(object sender, EventArgs e)
        {
            string query =
                @"SELECT Код, Вид FROM [Тип комнаты]";
            SqlCommand command = new(query, context.Connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                types.Add(((int)reader[0], reader[1].ToString()));
            }
            reader.Close();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(types.Select(x => x.Item2).ToArray());
            comboBox1.SelectedIndex = 0;
            if (IUstatus == 0)
            {
                Text = "Добавление комнаты";
                button1.Text = "Добавить";
            }
            else if (IUstatus == 1)
            {
                Text = "Изменение комнаты";
                button1.Text = "Изменить";
                textBox1.Text = room.CountOfPeople.ToString();
                textBox2.Text = room.Floor.ToString();
                textBox3.Text = room.RoomName.ToString();
                comboBox1.Text = room.Type;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = string.Empty;
            try
            {
                room.CountOfPeople = int.Parse(textBox1.Text);
                room.Floor = int.Parse(textBox2.Text);
                room.RoomName = int.Parse(textBox3.Text);
                room.Type = comboBox1.Text;
                room.TypeID = types.Where(x => x.Item2 == room.Type)
                                   .Select(x => x.Item1)
                                   .FirstOrDefault();
            }
            catch (OverflowException)
            {
                MessageBox.Show("Слишком большое значение в численных полях!", "Ошибка", MessageBoxButtons.OK
                               , MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверно указаны численные поля!", "Ошибка", MessageBoxButtons.OK
                               , MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK
                               , MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            if (IUstatus == 0)
            {
                query =
                    @"INSERT INTO Комната VALUES
                        (@CountOfPeople,@Floor,@RoomName,@TypeID)";
                SqlCommand command = new(query, context.Connection);
                command.Parameters.AddWithValue("@CountOfPeople", room.CountOfPeople);
                command.Parameters.AddWithValue("@Floor", room.Floor);
                command.Parameters.AddWithValue("@RoomName", room.RoomName);
                command.Parameters.AddWithValue("@TypeID", room.TypeID);
                command.ExecuteNonQuery();
            }
            else if (IUstatus == 1)
            {
                query =
                    @"UPDATE Комната SET
                        [Количество человек] = @CountOfPeople,
                        Этаж = @Floor,
                        Комната = @RoomName,
                        [Код типа комнаты] = @TypeID
                        WHERE Код = @ID";
                SqlCommand command = new(query, context.Connection);
                command.Parameters.AddWithValue("@ID", room.ID);
                command.Parameters.AddWithValue("@CountOfPeople", room.CountOfPeople);
                command.Parameters.AddWithValue("@Floor", room.Floor);
                command.Parameters.AddWithValue("@RoomName", room.RoomName);
                command.Parameters.AddWithValue("@TypeID", room.TypeID);
                command.ExecuteNonQuery();
            }
            Close();
        }
    }
}
