using WinFormTimer = System.Windows.Forms.Timer;
using System.Diagnostics;
using System.Windows.Forms;
using WinFormsApp_Test2.Commands;
using WinFormsApp_Test2.Rules;
using WinFormsApp_Test2.Printers;
using WinFormsApp_Test2.Utils;
using WinFormsApp_Test2.GameData;
using WinFormsApp_Test2.Forms;

namespace WinFormsApp_Test2
{
	internal static class Program
	{
		const int BrickSize = 30;
		const int CupThickness = 10;
		const int CupOffsetX = 5;
		const int CupOffsetY = 5;
		const int cupRows = 20;
		const int cupCols = 10;

		/// <summary>
		/// Толщина стенок стакана. Единица измерения пиксели.
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

			#region Создание состояния игры.

			GameState gameState = new GameState();

			#endregion

			#region Главная форма игры.

			int mainFormHeight = cupRows * BrickSize + CupThickness + CupOffsetY + 45;
			int mainFormWidth = cupCols * BrickSize + CupThickness * 2 + CupOffsetX * 2 + 15 + 200;

			MainForm mainForm = new MainForm();
			mainForm.Size = new(mainFormWidth, mainFormHeight);

			#endregion

			#region Форма GameOver

			GameOverForm gameOverForm = new GameOverForm();
			gameOverForm.ButtonClick += (string clickedButtonName, object sender, EventArgs e) =>
			{
				switch (clickedButtonName)
				{
					case "restartButtonClick":
						gameState.FallingShape = RandomShapeCreator.Create();
						gameState.FallingShapeRow = -2;
						gameState.Score = 0;
						gameState.Status = "running";
						gameOverForm.Hide();
						mainForm.Show();
						break;
					case "newGameButtonClick":
						// TODO Запросить имя игрока.
						gameState.FallingShape = RandomShapeCreator.Create();
						gameState.FallingShapeRow = -2;
						gameState.Score = 0;
						gameState.Status = "running";
						gameOverForm.Hide();
						mainForm.Show();
						break;
					case "exitButtonClick":
						// TODO Сделать вызов метода, который останавливает игру.
						Application.Exit();
						break;
				}
			};

            #endregion

            #region Создание стакана и падающей фигуры.

            gameState.Cup = new Brush[cupRows, cupCols];
			for (int row = 0; row < cupRows; row++)
			{
				for (int col = 0; col < cupCols; col++)
				{
					gameState.Cup[row, col] = BrickBrushPalette.EmptyBrickBrush;
				}
			}

			gameState.FallingShape = RandomShapeCreator.Create();

			#endregion

			#region Создание принтеров.

			Graphics mainGraphics = Graphics.FromHwnd(mainForm.Handle);

			SecondBufferPrinter secondBufferPrinter = new SecondBufferPrinter(mainGraphics, mainFormWidth, mainFormHeight);
			Graphics secondGraphics = secondBufferPrinter.SecondGraphics;

			ClearPrinter clearPrinter = new ClearPrinter(secondGraphics);
			CupPrinter cupPrinter = new CupPrinter(CupOffsetX, CupOffsetY, secondGraphics, gameState, _cupThickness);
			FallingShapePrinter fallingShapePrinter = new FallingShapePrinter(CupOffsetX + _cupThickness, CupOffsetY, secondGraphics, gameState);
			ScorePrinter scorePrinter = new ScorePrinter(mainForm, gameState);
			GameOverPrinter gameOverPrinter = new GameOverPrinter(gameState, mainForm, gameOverForm);

			GameRenderer gameRenderer = new GameRenderer(
				new Printer[] { 
					clearPrinter, // Этот принтер дожен быть первым.
					cupPrinter, 
					fallingShapePrinter,
					scorePrinter,
					gameOverPrinter,
					secondBufferPrinter, // Этот принтер дожен быть последним.
				}
			);

			#endregion

			#region Создание и запуск игры.

			WinFormTimer timer = new WinFormTimer();
			timer.Interval = 16;
			
			Game game = new Game(gameRenderer, gameState, timer, new Rule[] { 
				new GameOverRule(),
				new FallingShapeRule(),
				new FallingShapeCollisionRule(),
				new LineCleaningRule(),
				new TestRule(),
			});
			game.Start();

			#endregion

			#region Создание команд.

			mainForm.KeyDown += (object? sender, KeyEventArgs e) => {
				switch (e.KeyCode)
				{
					case Keys.A: 
						game.AddCommand(new MoveLeftFallingShape());
						break;
					case Keys.D:
						game.AddCommand(new MoveRightFallingShape());
						break;
					case Keys.G:
						game.AddCommand(new CreateRandomShape());
						break;
					case Keys.S:
						game.AddCommand(new MoveDownFallingShape());
						break;
					case Keys.W:
						game.AddCommand(new RotateFallingShape());
						break;
				}
			};

			#endregion

			#region Запуск главной формы.

			Application.Run(mainForm);

			#endregion
		}
	}
}