using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp_Test2.Utils;

namespace WinFormsApp_Test2.Commands
{
	internal class RotateFallingShape : Command
	{
		/// <summary>
		/// Эта команда вращает фигуру.
		/// 
		/// Если при вращении фигуры она пересекается со стаканом или кирпичиками, тов
		/// команда попытается сдвинуть фигуру вправо или влево на один кирпичик.
		/// Если пересечение осталось, то вращение отменяется.
		/// </summary>
		/// <param name="gameState"></param>
		public override void Execute(GameState gameState)
		{
			GameState gameStateClone = gameState.Clone();

			bool thereIsNoPlace = false;

            Func<bool> isCollision = () => 
			(
				Utils.Collision.CheckFallingShapeWallsCollision(gameStateClone) 
				|| Utils.Collision.CheckFallingShapeCupCollision(gameStateClone)
			);

			gameStateClone.FallingShape = BrickMapOperations.Rotate(gameStateClone.FallingShape);

			if (isCollision())
            {
				gameStateClone.FallingShapeCol += 1;

				if (isCollision())
                {
					gameStateClone.FallingShapeCol -= 2;

					if (isCollision())
                    {
						thereIsNoPlace = true;
                    }
                }
            }

            if (!thereIsNoPlace)
            {
				gameState.FallingShape = BrickMapOperations.Rotate(gameState.FallingShape);
				gameState.FallingShapeCol = gameStateClone.FallingShapeCol;
			}
		}
	}
}
