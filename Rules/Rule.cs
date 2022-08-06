namespace WinFormsApp_Test2.Rules
{
	abstract internal class Rule
	{
		public abstract void Start();
		public abstract void Tick(GameState gameState);
	}
}
