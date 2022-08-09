namespace WinFormsApp_Test2.GameData
{
	internal class Tetramino
	{
		public static readonly int[][,] Palette =
		{
			new int[,] {
				{0, 0, 0},
				{1, 1, 1},
				{0, 1, 0},
			},
			new int[,] {
				{0, 1, 0},
				{0, 1, 0},
				{1, 1, 0},
			},
			new int[,] {
				{0, 1, 0},
				{0, 1, 0},
				{0, 1, 1},
			},
			new int[,] {
				{0, 1, 0, 0},
				{0, 1, 0, 0},
				{0, 1, 0, 0},
				{0, 1, 0, 0},
			},
			new int[,] {
				{1, 1, 0},
				{0, 1, 1},
				{0, 0, 0},
			},
			new int[,] {
				{0, 1, 1},
				{1, 1, 0},
				{0, 0, 0},
			},
			new int[,] {
				{1, 1},
				{1, 1},
			}
		};
	}
}
