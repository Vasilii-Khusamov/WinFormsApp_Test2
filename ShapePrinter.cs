using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp_Test2
{
    internal class ShapePrinter : BrickMapPrinter
    {
        private Shape _shape;

        public ShapePrinter(int offsetX, int offsetY, Graphics graphics, Shape shape) 
            : base(offsetX, offsetY, graphics, shape)
        {
            _shape = shape;
        }

        protected override int CalculateBrickX(int col)
        {
            return base.CalculateBrickX(col) + _shape.Col * _brickSize;
        }

        protected override int CalculateBrickY(int row)
        {
            return base.CalculateBrickY(row) + Convert.ToInt32(_shape.Row) * _brickSize;
        }
    }
}
