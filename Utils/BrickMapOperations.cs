using WinFormsApp_Test2.GameData;
using WinFormsApp_Test2.Extentions;

namespace WinFormsApp_Test2.Utils
{
	internal class BrickMapOperations
	{
		/// <summary>
		/// Объединение массивов из target в destination со смещением.
		/// Пустые ячейки не переносятся.
		/// </summary>
		/// <param name="destination"></param>
		/// <param name="target"></param>
		/// <param name="offsetCol">Смещение по х</param>
		/// <param name="offsetRow">Смещение по у</param>
		/// <returns>Объединенный массив</returns>
		public static Brush[,] Merge(Brush[,] destination, Brush[,] target, int offsetCol, int offsetRow)
		{
			Brush[,] result = (Brush[,])destination.Clone();

			for (int col = 0; col < target.GetUpperBound(1) + 1; col++)
			{
				for (int row = 0; row < target.GetUpperBound(0) + 1; row++)
				{
					if 
					(
						target[row, col] != BrickBrushPalette.EmptyBrickBrush && 
						row + offsetRow >= 0 &&
						row + offsetRow <= destination.GetUpperBound(0) &&

						col + offsetCol >= 0 &&
						col + offsetCol <= destination.GetUpperBound(1)
					)
					{
						result[row + offsetRow, col + offsetCol] = target[row, col];
					}
				}
			}

			return result;
		}

		/// <summary>
		/// Вращение массива brickMap по часовой стрелке.
		/// </summary>
		/// <param name="brickMap">Исходный массив</param>
		/// <returns>Повёрнутый массив</returns>
		public static Brush[,] Rotate(Brush[,] brickMap)
		{
			(int rows, int cols) = brickMap.GetSize();

			Brush[,] result = new Brush[cols, rows];

			for (int col = 0; col < cols; col++)
			{
				for (int row = 0; row < rows; row++)
				{
					result[row,col] = brickMap[col, rows - row - 1];
				}
			}

			return result;
		}
		/// <summary>
		/// Удаление Строк из двухмерного массива
		/// </summary>
		/// <param name="target">Исходный массив</param>
		/// <param name="rows">Строки которые надо удалить</param>
		/// <returns>Исходный массив без Строк которых надо удалить</returns>
		public static Brush[,] ClearLines(Brush[,] target, bool[] rows)
        {
			Brush[,] result = (Brush[,])target.Clone();

			for (int row1 = 0; row1 <= rows.GetUpperBound(0); row1++)
            {
				if (row1 > result.GetUpperBound(0)) break;

				if (rows[row1])
                {
					for (int row2 = row1; row2 >= 0; row2--)
                    {
						for (int col = 0; col <= result.GetUpperBound(1); col++)
                        {
							if (row2 != 0)
                            {
								result[row2, col] = result[row2 - 1, col];
                            }
                            else
                            {
								result[row2, col] = BrickBrushPalette.EmptyBrickBrush;
                            }
                        }
                    }
                }
                else
                {
					continue;
                }
            }

			return result;
        }
	}
}
