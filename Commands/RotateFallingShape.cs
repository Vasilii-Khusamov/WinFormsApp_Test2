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
		public override void Execute(GameState gameState)
		{
			gameState.FallingShape = BrickMapOperations.Rotate(gameState.FallingShape);
		}
	}
}
