using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp_Test2
{
    abstract internal class BrickMapPrinter : Printer
    {
        protected const int _brickSize = 30;
        protected int _offsetX;
        protected int _offsetY;
        protected Graphics _graphics;
        protected Brush[,] _brickMap;

        public BrickMapPrinter(int offsetX, int offsetY, Graphics graphics, Brush[,] brickMap)
        {
            _offsetX = offsetX;
            _offsetY = offsetY;
            _graphics = graphics;
            _brickMap = brickMap;
        }

        public override void Print()
        {
            int rows = _brickMap.GetUpperBound(0) + 1;
            int cols = _brickMap.GetUpperBound(1) + 1;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Brush brickBrush = _brickMap[row, col];
                    int x = CalculateBrickX(col);
                    int y = CalculateBrickY(row);
                    int width = _brickSize;
                    int height = _brickSize;

                    _graphics.FillRectangle(brickBrush, x, y, width, height);
                }
            }
        }

        protected virtual int CalculateBrickX(int col)
        {
            return _offsetX + (col * _brickSize);
        }
        protected virtual int CalculateBrickY(int row)
        {
            return _offsetY + (row * _brickSize);
        }


    }
}
