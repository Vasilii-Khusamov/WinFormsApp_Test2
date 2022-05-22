using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp_Test2
{
    internal class BrickBrushPalette
    {

        public static SolidBrush[] Palette = {
             new SolidBrush(Color.FromArgb(0, Color.Black)), // Это цвет ячейки, когда в ней нет кирпичика.
             new SolidBrush(Color.Red),
             new SolidBrush(Color.Orange),
             new SolidBrush(Color.Yellow),
             new SolidBrush(Color.Green),
             new SolidBrush(Color.Blue),
             new SolidBrush(Color.Cyan),
             new SolidBrush(Color.DarkViolet),
        };

    }
}
