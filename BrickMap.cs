using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp_Test2
{
    abstract internal class BrickMap
    {
        public readonly int Rows;
        public readonly int Cols;

        public readonly int[,] Bricks;

        public BrickMap(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            Bricks = new int[Rows, Cols];
            ClearBricks();
        }

        private void ClearBricks()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    Bricks[row, col] = 0;
                }
            }

        }
    }
}
