namespace WinFormsApp_Test2.GameData
{
	internal class BrickBrushPalette
	{
		public static Brush EmptyBrickBrush
		{
			get
			{
				const int EmptyBrickBrushIndex = 0;
				return Palette[EmptyBrickBrushIndex];
			}
		}

		public static SolidBrush[] Palette = {
			new SolidBrush(Color.FromArgb(0, Color.Black)),
			new SolidBrush(Color.Red),
			new SolidBrush(Color.Orange),
			new SolidBrush(Color.Yellow),
			new SolidBrush(Color.Green),
			new SolidBrush(Color.Blue),
			new SolidBrush(Color.Cyan),
			new SolidBrush(Color.DarkViolet),
		};

	}
}