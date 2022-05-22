using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp_Test2
{
    internal class RandomShapeCreator
    {
       public static Shape Create()
        {
            int newBrickBrushIndex = new Random().Next(1, BrickBrushPalette.Palette.Length - 1);
            int randomIndex = new Random().Next(0, Tetramino.Palette.Length - 1);
            int[,] shapeTemplate = Tetramino.Palette[randomIndex];

            int templateRows = shapeTemplate.GetUpperBound(0) + 1;
            int templateCols = shapeTemplate.Length / templateRows;

            Shape randomShape = new(templateRows, templateCols);

            for (int row = 0; row < templateRows; row++)
            {
                for (int col = 0; col < templateCols; col++)
                {
                    randomShape.Bricks[row, col] = shapeTemplate[row, col] * newBrickBrushIndex;
                }
            }

            return randomShape;
        }
    }
}
