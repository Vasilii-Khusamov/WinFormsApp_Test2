using WinFormTimer = System.Windows.Forms.Timer;

namespace WinFormsApp_Test2
{
    internal static class Program
    {
        static CupPrinter CupPrinter;
        static Cup Cup = new Cup();
        static BrickBrushPalette BrickBrushPalette = new BrickBrushPalette();
        static MainForm MainForm;
        static Graphics Graphics;
        static Graphics SecondGraphics;
        static BufferedGraphics BufferedGraphics;
        static Shape FallingShape;
        static ShapePrinter FallingShapePrinter;

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


            WinFormTimer gameTimer = new WinFormTimer();
            gameTimer.Interval = 33;
            gameTimer.Tick += Tick;

            int MainFormWidth = Cup.Cols * BrickSize + CupThickness * 2 + CupOffsetX * 2 + 15 + 200;
            int MainFormHeight = Cup.Rows * BrickSize + CupThickness + CupOffsetY + 45;

            MainForm = new MainForm();
            MainForm.Size = new(MainFormWidth, MainFormHeight);
            Graphics = Graphics.FromHwnd(MainForm.Handle);

            BufferedGraphicsContext bufferedGraphicsContext = BufferedGraphicsManager.Current;
            BufferedGraphics = bufferedGraphicsContext.Allocate(Graphics, new Rectangle(0, 0, MainFormWidth, MainFormHeight));
            SecondGraphics = BufferedGraphics.Graphics;

            CupPrinter = new CupPrinter(CupOffsetX, CupOffsetY, SecondGraphics, Cup);


            FallingShape = CreateRandomShape();
            FallingShape.Row = 17;
            FallingShape.Col = 0;
            FallingShapePrinter = new(CupOffsetX, CupOffsetY, SecondGraphics, FallingShape);

            gameTimer.Start();
            Application.Run(MainForm);
        }

        private static void Tick(object? sender, EventArgs e)
        {
            SecondGraphics.Clear(Color.Black);
            CupPrinter.Print();
            FallingShapePrinter.Print();
            BufferedGraphics.Render(Graphics);
            
        }

        private static Shape CreateRandomShape()
        {
            int newBrickBrushIndex = new Random().Next(1, BrickBrushPalette.Palette.Length - 1);
            int randomIndex = new Random().Next(0, Tetramino.Palette.Length - 1);
            int[,] shapeTemplate = Tetramino.Palette[randomIndex];

            int templateRows = shapeTemplate.GetUpperBound(0) + 1;
            int templateCols = shapeTemplate.Length / templateRows;

            Shape randomShape = new(templateRows, templateCols);

            for(int row = 0; row < templateRows; row++)
            {
                for(int col = 0; col < templateCols; col++)
                {
                    randomShape.Bricks[row,col] = shapeTemplate[row, col] * newBrickBrushIndex;
                }
            }

            return randomShape;
        }
    }
}