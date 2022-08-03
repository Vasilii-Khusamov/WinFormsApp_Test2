using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp_Test2
{
    internal class FallingShapePrinter : BrickMapPrinter
    {
        private GameState _gameState;
        public FallingShapePrinter(int offsetX, int offsetY, Graphics graphics, GameState gameState) 
            : base(offsetX, offsetY, graphics, gameState.FallingShape)
        {
            _gameState = gameState;
        }

        protected override int CalculateBrickX(int col)
        {
            return base.CalculateBrickX(col) + _gameState.FallingShapeX * _brickSize;
        }

        protected override int CalculateBrickY(int row)
        {
            return base.CalculateBrickY(row) + _gameState.FallingShapeY * _brickSize;
        }
    }
}
