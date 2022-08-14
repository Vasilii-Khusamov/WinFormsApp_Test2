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

			if 
			(
				(
					Collision.CheckFallingShapeWallsCollision(gameStateClone) 
					|| Collision.CheckFallingShapeCupCollision(gameStateClone)
				)
				&& gameState.FallingShapeSlideTimer < 1
			)
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

			if 
			(
				gameState.FallingShapeSlideTimer < 1
				&&
				(
					Collision.CheckFallingShapeWallsCollision(gameStateClone)
					|| Collision.CheckFallingShapeCupCollision(gameStateClone)
				)
			)
            {
				gameState.FallingShapeSlideTimer = GameState.FallingShapeSlideDelay;
			}
			else if (Collision.CheckFallingShapeWallsCollision(gameStateClone) || Collision.CheckFallingShapeCupCollision(gameStateClone))
			{
				gameState.FallingShapeSlideTimer -= 1;
			}
			else if (gameState.FallingShapeSlideTimer < 1)
			{
				gameState.FallingShapeSlideTimer = GameState.FallingShapeSlideDelay;
			}
		}
	}
}
