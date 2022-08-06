namespace WinFormsApp_Test2.Utils
{
	internal class Collision
	{
		/// <summary>
		/// Проверка на столкновение падающей фигурки со стенками стакана (левой, правой и нижней стенками).
		/// </summary>
		/// <param name="gameState">Ссылка на состояние игры.</param>
		/// <returns>Возвращает true, если фигурка пересекается со стенкой.</returns>
		static public bool CheckFallingShapeWallsCollision(GameState gameState)
		{
			bool result = false;

			for (int col = 0; col < gameState.FallingShapeCols; col++)
			{
				for (int row = 0; row < gameState.FallingShapeRows; row++)
				{
					if (gameState.FallingShape[row, col] == BrickBrushPalette.EmptyBrickBrush) continue;
					if
					(
						col + gameState.FallingShapeCol < 0
						|| col + gameState.FallingShapeCol > gameState.CupCols - 1
						|| row + gameState.FallingShapeRow > gameState.CupRows - 1
					)
					{
						result = true;
						break;
					}
				}
				if (result == true) break;
			}

			return result;
		}

		/// <summary>
		/// Проверка на столкновение падающей фигурки с кирпичиками стакана.
		/// </summary>
		/// <param name="gameState">Ссылка на состояние игры.</param>
		/// <returns>Возвращает true, если фигурка пересекается с кирпичиками стакана.</returns>
		static public bool CheckFallingShapeCupCollision(GameState gameState)
		{
			bool result = false;
			for (int col = 0; col < gameState.FallingShapeCols; col++)
			{
				for (int row = 0; row < gameState.FallingShapeRows; row++)
				{
					if (
						gameState.FallingShape[row, col] != BrickBrushPalette.EmptyBrickBrush
						&& col + gameState.FallingShapeCol >= 0 && col + gameState.FallingShapeCol < gameState.CupCols
						&& row + gameState.FallingShapeRow >= 0 && row + gameState.FallingShapeRow < gameState.CupRows
					)
					{
						if (gameState.Cup[row + gameState.FallingShapeRow, col + gameState.FallingShapeCol] != BrickBrushPalette.EmptyBrickBrush)
						{
							result = true;
							break;
						}
					}
				}
				if (result == true) break;
			}

			return result;
		}
	}
}
