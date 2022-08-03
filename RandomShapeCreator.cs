using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp_Test2
{
    internal class RandomShapeCreator
    {
       public static Brush[,] Create()
        {
            Brush newBrickBrush = BrickBrushPalette.Palette[new Random().Next(1, BrickBrushPalette.Palette.Length - 1)];
            int randomIndex = new Random().Next(0, Tetramino.Palette.Length - 1);
            int[,] shapeTemplate = Tetramino.Palette[randomIndex];

            int templateRows = shapeTemplate.GetUpperBound(0) + 1;
            int templateCols = shapeTemplate.Length / templateRows;

            Brush[,] randomShape = new Brush[templateRows, templateCols];

            for (int row = 0; row < templateRows; row++)
            {
                for (int col = 0; col < templateCols; col++)
                {
                    randomShape[row, col] = shapeTemplate[row, col] == 1 ? newBrickBrush : BrickBrushPalette.EmptyBrush;
                }
            }

            return randomShape;
        }
    }
}
