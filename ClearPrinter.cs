using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp_Test2
{
    internal class ClearPrinter : Printer
    {
        private readonly Graphics _secondGraphics;

        public ClearPrinter(Graphics secondGraphics)
        {
            _secondGraphics = secondGraphics;
        }

        public override void Print()
        {
            _secondGraphics.Clear(Color.Black);
        }
    }
}
