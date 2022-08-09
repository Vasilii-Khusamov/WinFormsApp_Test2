namespace WinFormsApp_Test2.Printers
{
	abstract internal class BrickMapPrinter : Printer
	{
		protected const int _brickSize = 30;
		protected int _offsetX;
		protected int _offsetY;
		protected Graphics _graphics;

		public BrickMapPrinter(int offsetX, int offsetY, Graphics graphics)
		{
			_offsetX = offsetX;
			_offsetY = offsetY;
			_graphics = graphics;
		}

		protected abstract Brush[,] BrickMap { get; }

		public override void Print()
		{
			int rows = BrickMap.GetUpperBound(0) + 1;
			int cols = BrickMap.GetUpperBound(1) + 1;

			for (int row = 0; row < rows; row++)
			{
				for (int col = 0; col < cols; col++)
				{
					Brush brickBrush = BrickMap[row, col];
					int x = CalculateBrickX(col);
					int y = CalculateBrickY(row);
					int width = _brickSize;
					int height = _brickSize;

					_graphics.FillRectangle(brickBrush, x, y, width, height);
				}
			}
		}

		protected virtual int CalculateBrickX(int col)
		{
			return _offsetX + col * _brickSize;
		}
		protected virtual int CalculateBrickY(int row)
		{
			return _offsetY + row * _brickSize;
		}


	}
}
