using WinFormsApp_Test2.GameData;
using WinFormsApp_Test2.Utils;

namespace WinFormsApp_Test2.Rules
{
    internal class GameOverRule : Rule
    {
        public override void Start()
        {

        }

        public override void Tick(GameState gameState)
        {
            if
            (
            gameState.FallingShapeSlideTimer <= 0
            && Collision.CheckFallingShapeCupCollision(gameState)
            )
            {
                gameState.Status = "gameOver";

                for (int cupRow = 0; cupRow < gameState.CupRows; cupRow++)
                {
                    for (int cupCol = 0; cupCol < gameState.CupCols; cupCol++)
                    {
                        gameState.Cup[cupRow, cupCol] = BrickBrushPalette.EmptyBrickBrush;
                    }
                }
                for (int fallingShapeRow = 0; fallingShapeRow < gameState.FallingShapeRows; fallingShapeRow++)
                {
                    for (int fallingShapeCol = 0; fallingShapeCol < gameState.FallingShapeCols; fallingShapeCol++)
                    {
                        gameState.FallingShape[fallingShapeRow, fallingShapeCol] = BrickBrushPalette.EmptyBrickBrush;
                    }
                }
            }
        }
    }
}
