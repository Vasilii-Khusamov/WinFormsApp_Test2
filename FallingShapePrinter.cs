namespace WinFormsApp_Test2
{
	internal class FallingShapePrinter : BrickMapPrinter
	{
		private readonly GameState _gameState;

		public FallingShapePrinter(int offsetX, int offsetY, Graphics graphics, GameState gameState)
			 : base(offsetX, offsetY, graphics)
		{
			_gameState = gameState;
		}

		protected override Brush[,] BrickMap => _gameState.FallingShape;

		protected override int CalculateBrickX(int col) => base.CalculateBrickX(col) + _gameState.FallingShapeCol * _brickSize;

		protected override int CalculateBrickY(int row)
		{
			return base.CalculateBrickY(row) + _gameState.FallingShapeRow * _brickSize;
		}
	}
}
