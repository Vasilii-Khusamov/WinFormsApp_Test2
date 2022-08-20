namespace WinFormsApp_Test2
{
    internal partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void PrintScore(int score)
        {
            scoreLabel.Text = score.ToString();
        }
    }
}