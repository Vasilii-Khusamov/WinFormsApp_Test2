namespace WinFormsApp_Test2.Printers
{
	internal class CupPrinter : BrickMapPrinter
	{
		GameState _gameState;

		/// <summary>
		/// Толщина стенок стакана. Единица измерения пиксели.
		/// </summary>
		private readonly int _cupThickness;

		/// <summary>
		/// Кисть для закрашивания фона стакана.
		/// </summary>
		private readonly SolidBrush _backgroundBrush = new SolidBrush(Color.Black);

		/// <summary>
		/// Кисть для закрашивания стенок стакана.
		/// </summary>
		private readonly SolidBrush _cupBrush = new SolidBrush(Color.Yellow);

		protected override Brush[,] BrickMap => _gameState.Cup;

		public CupPrinter(int offsetX, int offsetY, Graphics graphics, GameState gameState, int cupThickness)
			 : base(offsetX + cupThickness, offsetY, graphics)
		{
			_gameState = gameState;
			_cupThickness = cupThickness;
		}

		public override void Print()
		{
			PrintBackgroundAndWalls();
			base.Print();
		}

		/// <summary>
		/// Напечатать фон и стенки стакана.
		/// </summary>
		private void PrintBackgroundAndWalls()
		{
			int brickMapRows = BrickMap.GetUpperBound(0) + 1;
			int brickMapCols = BrickMap.GetUpperBound(1) + 1;

			_graphics.FillRectangle(
				 _cupBrush,
				 _offsetX - _cupThickness,
				 _offsetY,
				 brickMapCols * _brickSize + _cupThickness * 2,
				 brickMapRows * _brickSize + _cupThickness
			);

			_graphics.FillRectangle(
				 _backgroundBrush,
				 _offsetX,
				 _offsetY,
				 brickMapCols * _brickSize,
				 brickMapRows * _brickSize
			);
		}

	}
}
