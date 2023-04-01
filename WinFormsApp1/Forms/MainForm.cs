using GAI.Forms;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        private int CurrentUserId;
        private string CurrentUserFIO;
        private string CurrentUserRank;

        public MainForm(int currentUserId, string currentUserFIO, string currentUserRank)
        {
            CurrentUserId = currentUserId;
            CurrentUserFIO = currentUserFIO;
            CurrentUserRank = currentUserRank;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            introductionLabel.Text = $"Текущий сеанс:\nФИО сотурдника: {CurrentUserFIO}" +
                                     $"\nЗвание сотрудника: {CurrentUserRank}";
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AuthorizationForm? authorizationForm = Application.OpenForms["AuthorizationForm"] as AuthorizationForm;
            authorizationForm?.Close();
        }
    }
}