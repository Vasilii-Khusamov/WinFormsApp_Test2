using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp_Test2
{
    internal class SecondBufferPrinter : Printer
    {
        private Graphics _mainGraphics;
        private Graphics _secondGraphics;
        private BufferedGraphics _bufferedGraphics;

        public Graphics SecondGraphics 
        {
            get { return _secondGraphics; }
        }

        public SecondBufferPrinter(Graphics mainGraphics, int mainFormWidth, int mainFormHeight) 
        {
            _mainGraphics = mainGraphics;

            BufferedGraphicsContext bufferedGraphicsContext = BufferedGraphicsManager.Current;
            _bufferedGraphics = bufferedGraphicsContext.Allocate(mainGraphics, new Rectangle(0, 0, mainFormWidth, mainFormHeight));
            _secondGraphics = _bufferedGraphics.Graphics;
        }

        public override void Print()
        {
            _bufferedGraphics.Render(_mainGraphics);
        }
    }
}
