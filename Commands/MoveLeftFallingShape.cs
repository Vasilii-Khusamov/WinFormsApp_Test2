﻿namespace WinFormsApp_Test2.Commands
{
	internal class MoveLeftFallingShape : Command
	{
		public override void Execute(GameState gameState)
		{
			GameState gameStateClone = gameState.Clone();
			gameStateClone.FallingShapeCol--;

			if (!Utils.Collision.CheckFallingShapeWallsCollision(gameStateClone))
			{
				gameState.FallingShapeCol--;
			}
		}
	}
}