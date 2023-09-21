using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using WinFormsApp1;

namespace CourseProject
{
    public partial class MainForm : Form
    {
        DBContext context;
        public MainForm()
        {
            context = new DBContext();
            InitializeComponent();
        }
        private void RefillDgv()
        {
            string query;
            switch (tableCB.Text)
            {
                case "Гости":
                    query =
                        @"SELECT Гости.Код, [Код заселения],
                          ФИО, [Дата/Время], Комната
                            FROM Гости, Заселение, Комната
                            WHERE [Код заселения] = Заселение.Код
                            AND [Код комнаты] = Комната.Код";
                    break;
                case "Заселение":
                    query =
                        @"SELECT Заселение.Код, [Код комнаты], Комната
                                 [Дата заселения], [Код студента],
	                             Студент.Фамилия + ' ' + 
                                 Студент.Имя + ' ' + 
                                 Студент.Отчество AS Студент,
	                             [код персонала],
	                             Персонал.Фамилия + ' ' + 
                                 Персонал.Имя + ' ' + 
                                 Персонал.Отчество AS Персонал,
	                             [Дата выселения]
                          FROM Заселение, Комната, Персонал, Студент
                          WHERE [Код комнаты] = Комната.Код
                            AND [Код студента] = Студент.Код
	                        AND [код персонала] = Персонал.Код";
                    break;
                case "Комната":
                    query =
                        @"SELECT Комната.Код, [Количество человек],
                                 Этаж, Комната,
	                             [Код типа комнаты], Вид AS [Тип комнаты]
                            FROM Комната, [Тип комнаты]
                            WHERE [Код типа комнаты] = [Тип комнаты].Код";
                    break;
                case "Предоставление услуг":
                    query =
                        @"SELECT * FROM [Информация о предостовлении услуг]";
                    break;
                default:
                    query = string.Empty;
                    break;
            }
            if (!string.IsNullOrEmpty(query))
            {
                SqlDataAdapter adapter = new(query, context.Connection);
                DataTable dataTable = new();
                adapter.Fill(dataTable);
                dgvTable.DataSource = dataTable;
                if (dgvTable.Columns["Код"] != null)
                    dgvTable.Columns["Код"].Visible = false;
                if (dgvTable.Columns["Код услуги"] != null)
                    dgvTable.Columns["Код услуги"].Visible = false;
                if (dgvTable.Columns["Код заселения"] != null)
                    dgvTable.Columns["Код заселения"].Visible = false;
                if (dgvTable.Columns["код персонала"] != null)
                    dgvTable.Columns["код персонала"].Visible = false;
                if (dgvTable.Columns["Код студента"] != null)
                    dgvTable.Columns["Код студента"].Visible = false;
                if (dgvTable.Columns["Код типа комнаты"] != null)
                    dgvTable.Columns["Код типа комнаты"].Visible = false;
            }
            else
            {
                dgvTable.DataSource = null;
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            tableCB.SelectedIndex = 0;
        }

        private void tableCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefillDgv();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            switch (tableCB.Text)
            {
                case "Комната":
                    IURoomForm iuroomForm = new(context);
                    iuroomForm.ShowDialog();
                    RefillDgv();
                    break;
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (dgvTable.SelectedRows.Count == 1)
            {
                int index = dgvTable.SelectedRows[0].Index;
                switch (tableCB.Text)
                {
                    case "Комната":
                        Room room = new()
                        {
                            ID = (int)dgvTable.Rows[index].Cells["Код"].Value,
                            CountOfPeople = (int)dgvTable.Rows[index].Cells["Количество человек"].Value,
                            Floor = (int)dgvTable.Rows[index].Cells["Этаж"].Value,
                            RoomName = (int)dgvTable.Rows[index].Cells["Комната"].Value,
                            TypeID = (int)dgvTable.Rows[index].Cells["Код типа комнаты"].Value,
                            Type = (string)dgvTable.Rows[index].Cells["Тип комнаты"].Value
                        };
                        IURoomForm iuroomForm = new(context, room);
                        iuroomForm.ShowDialog();
                        RefillDgv();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Нужно выбрать запись для изменения!",
                                "Предупреждение",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button1);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dgvTable.SelectedRows.Count == 1)
            {
                int index = dgvTable.SelectedRows[0].Index;
                int id = (int)dgvTable.Rows[index].Cells["Код"].Value;
                switch (tableCB.Text)
                {
                    case "Комната":
                        var result = 
                            MessageBox.Show("Вы уверены, что хотите удалить эту запись?",
                                            "Предупреждение",
                                            MessageBoxButtons.OKCancel,
                                            MessageBoxIcon.Question,
                                            MessageBoxDefaultButton.Button1);
                        if (result == DialogResult.OK)
                        {
                            try
                            {
                                string query =
                                @"DELETE FROM Комната WHERE Код = @id";
                                SqlCommand command = new(query, context.Connection);
                                command.Parameters.AddWithValue("@id", id);
                                command.ExecuteNonQuery();
                                RefillDgv();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message,
                                    "Ошибка",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1);
                            }
                        }
                        break;

                }
            }
            else
            {
                MessageBox.Show("Нужно выбрать запись для удаления!",
                                "Предупреждение",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button1);
            }
        }

        private void количествоПроступковСтудентовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"../../../../Reports/bin/Debug/Reports.exe");
        }
    }
}
