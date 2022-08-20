using WinFormsApp_Test2.Utils;

namespace WinFormsApp_Test2.Rules
{
	internal class FallingShapeRule : Rule
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
				gameState.FallingShapeTimer < 1 
				&& !Collision.CheckFallingShapeCupCollision(gameStateClone) 
				&& !Collision.CheckFallingShapeWallsCollision(gameStateClone)
			)
			{
				gameState.FallingShapeRow++;
				gameState.FallingShapeTimer = GameState.FallingShapeDelay;
			}
			else
			{
				gameState.FallingShapeTimer--;
			}
		}
	}
}
