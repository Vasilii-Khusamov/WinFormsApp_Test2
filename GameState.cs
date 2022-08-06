namespace WinFormsApp_Test2
{
	internal class GameState
	{
		public Brush[,] Cup { get; set; } = new Brush[0, 0];
		public int CupCols => Cup.GetUpperBound(1) + 1;
		public int CupRows => Cup.GetUpperBound(0) + 1;

		public int Score { get; set; }
		public string State { get; set; } = "pause";

		public Brush[,] FallingShape { get; set; } = new Brush[0, 0];
		public int FallingShapeX { get; set; }
		public int FallingShapeY { get; set; }
		public int FallingShapeCol { get; set; }
		public int FallingShapeRow { get; set; }

		public int FallingShapeCols => FallingShape.GetUpperBound(1) + 1;
		public int FallingShapeRows => FallingShape.GetUpperBound(0) + 1;

		public Brush[,] NextShape { get; set; } = new Brush[0, 0];

		public GameState Clone()
		{
			return new GameState()
			{
				Cup = (Brush[,])Cup.Clone(),
				FallingShape = (Brush[,])FallingShape.Clone(),
				FallingShapeCol = FallingShapeCol,
				FallingShapeRow = FallingShapeRow,
				NextShape = (Brush[,])NextShape.Clone(),
				Score = Score,
				State = (string)State.Clone()
			};
		}
	}
}