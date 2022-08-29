using WinFormsApp_Test2.Forms;

namespace WinFormsApp_Test2.Printers
{
    internal class GameOverPrinter : Printer
    {
        private GameState _gameState;
        private MainForm _mainForm;
        private GameOverForm _gameOverForm;
        public GameOverPrinter(GameState gameState, MainForm mainForm, GameOverForm gameOverForm)
        {
            _gameState = gameState;
            _mainForm = mainForm;
            _gameOverForm = gameOverForm;
        }

        public override void Print()
        {
            if (_gameState.Status == "gameOver" && _mainForm.Visible)
            {
                _mainForm.Hide();
                _gameOverForm.ShowDialogWithData(_gameState.Score.ToString());
            }
        }
    }
}
