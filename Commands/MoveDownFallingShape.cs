using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp_Test2.Commands
{
	internal class MoveDownFallingShape : Command
	{
		public override void Execute(GameState gameState)
		{
			gameState.FallingShapeTimer = 0;
		}
	}
}
