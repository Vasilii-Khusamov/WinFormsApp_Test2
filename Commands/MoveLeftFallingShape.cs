using WinFormsApp_Test2.Utils;

namespace WinFormsApp_Test2.Commands
{
	internal class MoveLeftFallingShape : Command
	{
		public override void Execute(GameState gameState)
		{
			GameState gameStateClone = gameState.Clone();
			gameStateClone.FallingShapeCol--;

			if (!Collision.CheckFallingShapeWallsCollision(gameStateClone) && !Collision.CheckFallingShapeCupCollision(gameStateClone))
			{
				gameState.FallingShapeCol--;
			}
		}
	}
}
