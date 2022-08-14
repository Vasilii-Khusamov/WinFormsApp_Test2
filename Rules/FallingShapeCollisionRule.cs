using WinFormsApp_Test2.Utils;

namespace WinFormsApp_Test2.Rules
{
	internal class FallingShapeCollisionRule : Rule
	{
		public override void Start()
		{

		}

		public override void Tick(GameState gameState)
		{
			GameState gameStateClone = gameState.Clone();

			gameStateClone.FallingShapeRow++;

			if (Collision.CheckFallingShapeWallsCollision(gameStateClone) || Collision.CheckFallingShapeCupCollision(gameStateClone))
			{
				// Копирование падающей фигуры.
				gameState.Cup = BrickMapOperations.Merge(gameState.Cup, gameState.FallingShape, gameState.FallingShapeCol, gameState.FallingShapeRow);
				// Создание новой падающей фигуры.
				gameState.FallingShape = RandomShapeCreator.Create();
				gameState.FallingShapeCol = 3;
				gameState.FallingShapeRow = -2;
				gameState.FallingShapeTimer = GameState.FallingShapeDelay;
				gameState.FallingShapeSlideTimer = GameState.FallingShapeSlideDelay;
			}
		}
	}
}
