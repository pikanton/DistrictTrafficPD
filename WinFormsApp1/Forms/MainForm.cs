using GAI;
using GAI.Forms;
using System.Data;
using System.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        private int CurrentUserId;
        private string CurrentUserFIO;
        private string CurrentUserRank;
        private static void FillDataGrid(SqlDataAdapter adapter, ref DataSet dataSet, ref DataGridView dgv)
        {
            dataSet.Clear();
            adapter.Fill(dataSet);
            dgv.DataSource = dataSet.Tables[0];
        }
        public MainForm(int currentUserId, string currentUserFIO, string currentUserRank)
        {
            CurrentUserId = currentUserId;
            CurrentUserFIO = currentUserFIO;
            CurrentUserRank = currentUserRank;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            introductionLabel.Text = $"������� �����:\n��� ����������: {CurrentUserFIO}" +
                                     $"\n������ ����������: {CurrentUserRank}";

            // �������� � dgv ���������
            DBContext.CloseConnection();
            SqlDataAdapter adapter = new(Queries.GetViolations, DBContext.Connection);
            DataSet dataSetViolation = new DataSet();
            FillDataGrid(adapter, ref dataSetViolation, ref dgvViolation);

            // �������� c dgv �����������
            adapter.SelectCommand = new SqlCommand(Queries.GetRegistrations, DBContext.Connection);
            DataSet dataSetRegistration = new DataSet();
            FillDataGrid(adapter, ref dataSetRegistration, ref dgvRegistration);

            // �������� c dgv ������������ �������������
            adapter.SelectCommand = new SqlCommand(Queries.GetLicenses, DBContext.Connection);
            DataSet dataSetLicense = new DataSet();
            FillDataGrid(adapter, ref dataSetLicense, ref dgvLicense);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AuthorizationForm? authorizationForm = Application.OpenForms["AuthorizationForm"] as AuthorizationForm;
            authorizationForm?.Close();
        }

        private void dgvViolation_DataSourceChanged(object sender, EventArgs e)
        {
            dgvViolation.Columns["���"].Visible = false;
        }

        private void dgvRegistration_DataSourceChanged(object sender, EventArgs e)
        {
            dgvRegistration.Columns["���"].Visible = false;
        }

        private void dgvLicense_DataSourceChanged(object sender, EventArgs e)
        {
            dgvLicense.Columns["���"].Visible = false;
        }
    }
}