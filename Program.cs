using WinFormTimer = System.Windows.Forms.Timer;

namespace WinFormsApp_Test2
{
    internal static class Program
    {
        static MainForm MainForm;

        const int BrickSize = 30;
        const int CupThickness = 10;
        const int CupOffsetX = 15;
        const int CupOffsetY = 5;



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
            GameState gameState = new GameState();



            



            int mainFormHeight = cupRows * BrickSize + CupThickness + CupOffsetY + 45;
            int mainFormWidth = cupCols * BrickSize + CupThickness * 2 + CupOffsetX * 2 + 15 + 200;





            MainForm = new MainForm();
            MainForm.Size = new(mainFormWidth, mainFormHeight);
            Graphics mainGraphics = Graphics.FromHwnd(MainForm.Handle);

            SecondBufferPrinter secondBufferPrinter = new SecondBufferPrinter(mainGraphics, mainFormWidth, mainFormHeight);
            Graphics secondGraphics = secondBufferPrinter.SecondGraphics;

            ClearPrinter clearPrinter = new ClearPrinter(secondGraphics);
            CupPrinter cupPrinter = new CupPrinter(CupOffsetX, CupOffsetY, secondGraphics, gameState);
            FallingShapePrinter fallingShapePrinter  = new FallingShapePrinter(CupOffsetX, CupOffsetY, secondGraphics, gameState);

            GameRenderer gameRenderer = new GameRenderer(new Printer[] { clearPrinter, cupPrinter, fallingShapePrinter, secondBufferPrinter });



            Game game = new Game(gameRenderer, gameState, new Rule[0]);

            game.GameState.Cup = new Brush[cupRows, cupCols];

            for (int row = 0; row < cupRows; row++)
            {
                for (int col = 0; col < cupCols; col++)
                {
                    game.GameState.Cup[row, col] = new SolidBrush(Color.FromArgb(0));
                }
            }

            game.GameState.FallingShape = RandomShapeCreator.Create();



            Application.Run(MainForm);
        }

    }
}