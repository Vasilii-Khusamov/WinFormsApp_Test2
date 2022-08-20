using WinFormsApp_Test2.Utils;
using WinFormsApp_Test2.GameData;


namespace WinFormsApp_Test2.Rules
{
    internal class LineCleaningRule : Rule
    {
        public override void Start()
        {

        }

        public override void Tick(GameState gameState)
        {
            bool[] rowsForClearing = new bool[gameState.CupRows];

            for (int row = 0; row <= gameState.Cup.GetUpperBound(0); row++)
            {
                for (int col = 0; col <= gameState.Cup.GetUpperBound(1); col++)
                {
                    if (gameState.Cup[row, col] != BrickBrushPalette.EmptyBrickBrush)
                    {
                        if (col == gameState.Cup.GetUpperBound(1))
                        {
                            rowsForClearing[row] = true;
                        }
                    }
                    else break;
                }
            }

            gameState.Cup = BrickMapOperations.ClearLines(gameState.Cup, rowsForClearing);

            int rowsClearedNumber = 0;

            foreach (bool rowForClearing in rowsForClearing)
            {
                if (rowForClearing) rowsClearedNumber++;
            }

            if (rowsClearedNumber == 4) gameState.Score += 1000;
            else gameState.Score += rowsClearedNumber * 100;
        }
    }
}
