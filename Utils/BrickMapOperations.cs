using WinFormsApp_Test2.GameData;

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
					if (target[row, col] != BrickBrushPalette.EmptyBrickBrush)
					{
						result[row + offsetRow, col + offsetCol] = target[row, col];
					}
				}
			}

			return result;
		}
	}
}
