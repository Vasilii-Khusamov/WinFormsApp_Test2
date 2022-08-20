using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp_Test2.Printers
{
    internal class ScorePrinter : Printer
    {
        private MainForm _mainForm;
        private GameState _gameState;

        public ScorePrinter(MainForm mainForm, GameState gameState)
        {
            _mainForm = mainForm;
            _gameState = gameState;
        }
        public override void Print()
        {
            _mainForm.PrintScore(_gameState.Score);
        }
    }
}
