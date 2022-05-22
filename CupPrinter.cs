using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp_Test2
{
    internal class CupPrinter : BrickMapPrinter
    {
        const int CupThickness = 10;
        SolidBrush BackgroundBrush = new SolidBrush(Color.Black);
        SolidBrush CupBrush = new SolidBrush(Color.White);

        public CupPrinter(int offsetX, int offsetY, Graphics graphics, Cup brickMap) 
            : base(offsetX, offsetY, graphics, brickMap)
        {}

        public override void Print()
        {
            PrintCupWalls();
            base.Print();
        }

        private void PrintCupWalls()
        {
            _graphics.FillRectangle(
                CupBrush, 
                _offsetX - CupThickness, 
                _offsetY, 
                _brickMap.Cols * _brickSize + CupThickness * 2, 
                _brickMap.Rows * _brickSize + CupThickness
            );

            _graphics.FillRectangle(
                BackgroundBrush, 
                _offsetX, 
                _offsetY, 
                _brickMap.Cols * _brickSize,
                _brickMap.Rows * _brickSize
            );
        }

    }
}
