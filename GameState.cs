using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp_Test2
{
    internal class GameState
    {
        public Brush[,] Cup { get; set; } = new Brush[0, 0];
        public int Score { get; set; }
        public string State { get; set; } = "pause";

        public Brush[,] FallingShape { get; set; } = new Brush[0, 0];
        public int FallingShapeX { get; set; }
        public int FallingShapeY { get; set; }

        public Brush[,] NextShape { get; set; } = new Brush[0, 0];
    }
}