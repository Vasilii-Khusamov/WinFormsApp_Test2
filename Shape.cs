using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp_Test2
{
    internal class Shape : BrickMap
    {
        public float SpeedY = 0.1F;
        public int Col = 0;
        public float Row = 0;

        public Shape(int rows, int cols) : base(rows, cols)
        {
        }
    }
}
