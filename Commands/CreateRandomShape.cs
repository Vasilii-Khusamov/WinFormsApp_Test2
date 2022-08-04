namespace WinFormsApp_Test2.Commands
{
	internal class CreateRandomShape : Command
	{
		public override void Execute(GameState gameState)
		{
			gameState.FallingShape = RandomShapeCreator.Create();
		}
	}
}
