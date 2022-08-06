namespace WinFormsApp_Test2.Rules
{
	internal class FallingShapeRule : Rule
	{
		public override void Start()
		{

		}

		public override void Tick(GameState gameState)
		{

			if (gameState.FallingShapeTimer < 1)
			{
				gameState.FallingShapeRow++;
				gameState.FallingShapeTimer = gameState.FallingShapeDelay;
			}
			else
			{
				gameState.FallingShapeTimer--;
			}
		}
	}
}
