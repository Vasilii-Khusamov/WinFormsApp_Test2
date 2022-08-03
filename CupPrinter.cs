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

        public CupPrinter(int offsetX, int offsetY, Graphics graphics, GameState gameState) 
            : base(offsetX, offsetY, graphics, gameState.Cup)
        {}

        public override void Print()
        {
            PrintCupWalls();
            base.Print();
        }

        private void PrintCupWalls()
        {
            int brickMapCols = _brickMap.GetUpperBound(0) + 1;
            int brickMapRows = _brickMap.GetUpperBound(1) + 1;

            _graphics.FillRectangle(
                CupBrush, 
                _offsetX - CupThickness, 
                _offsetY, 
                brickMapCols * _brickSize + CupThickness * 2,
                brickMapRows * _brickSize + CupThickness
            );

            _graphics.FillRectangle(
                BackgroundBrush, 
                _offsetX, 
                _offsetY, 
                brickMapCols * _brickSize,
                brickMapRows * _brickSize
            );
        }

    }
}
