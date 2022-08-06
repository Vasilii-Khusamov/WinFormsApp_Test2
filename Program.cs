using WinFormTimer = System.Windows.Forms.Timer;
using System.Diagnostics;
using System.Windows.Forms;
using WinFormsApp_Test2.Commands;

namespace WinFormsApp_Test2
{
	internal static class Program
	{
		const int BrickSize = 30;
		const int CupThickness = 10;
		const int CupOffsetX = 5;
		const int CupOffsetY = 5;

		/// <summary>
		/// ������� ������ �������. ������� ��������� �������.
		/// </summary>
		private const int _cupThickness = 10;

		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();

			const int cupRows = 20;
			const int cupCols = 10;

			int mainFormHeight = cupRows * BrickSize + CupThickness + CupOffsetY + 45;
			int mainFormWidth = cupCols * BrickSize + CupThickness * 2 + CupOffsetX * 2 + 15 + 200;

			MainForm mainForm = new MainForm();
			mainForm.Size = new(mainFormWidth, mainFormHeight);

			// �������� ��������� ����.

			GameState gameState = new GameState();

			// �������� ������� � �������� ������.

			gameState.Cup = new Brush[cupRows, cupCols];
			for (int row = 0; row < cupRows; row++)
			{
				for (int col = 0; col < cupCols; col++)
				{
					gameState.Cup[row, col] = BrickBrushPalette.EmptyBrickBrush;
				}
			}

			gameState.FallingShape = RandomShapeCreator.Create();
			
			// �������� ���������.

			Graphics mainGraphics = Graphics.FromHwnd(mainForm.Handle);

			SecondBufferPrinter secondBufferPrinter = new SecondBufferPrinter(mainGraphics, mainFormWidth, mainFormHeight);
			Graphics secondGraphics = secondBufferPrinter.SecondGraphics;

			ClearPrinter clearPrinter = new ClearPrinter(secondGraphics);
			CupPrinter cupPrinter = new CupPrinter(CupOffsetX, CupOffsetY, secondGraphics, gameState, _cupThickness);
			FallingShapePrinter fallingShapePrinter = new FallingShapePrinter(CupOffsetX + _cupThickness, CupOffsetY, secondGraphics, gameState);

			GameRenderer gameRenderer = new GameRenderer(
				new Printer[] { 
					clearPrinter,
					cupPrinter, 
					fallingShapePrinter, 
					secondBufferPrinter 
				}
			);

			// �������� � ������ ����.

			Game game = new Game(gameRenderer, gameState, new Rule[0]);
			game.Start();

			// ������ ������� �����.

			Application.Run(mainForm);
		}

	}
}