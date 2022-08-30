using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp_Test2.Forms
{
    public partial class GameOverForm : Form
    {
        public delegate void ButtonClickHandler(string clickedButtonName, object sender, EventArgs e);
        public event ButtonClickHandler ButtonClick;
        public GameOverForm()
        {
            InitializeComponent();
        }
        public void ShowDialogWithData(string score)
        {
            Scorelabel.Text = score;
            ShowDialog();
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            ButtonClick.Invoke("restartButtonClick", sender, e);
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            ButtonClick.Invoke("newGameButtonClick", sender, e);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            ButtonClick.Invoke("exitButtonClick", sender, e);
        }
    }
}
