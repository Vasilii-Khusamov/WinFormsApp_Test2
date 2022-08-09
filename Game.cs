using WinFormTimer = System.Windows.Forms.Timer;
using WinFormsApp_Test2.Commands;
using WinFormsApp_Test2.Rules;
using WinFormsApp_Test2.Printers;

namespace WinFormsApp_Test2
{
	internal class Game
	{
		private readonly Queue<Command> _commands = new Queue<Command>();

		private readonly GameRenderer _gameRenderer = new GameRenderer(Array.Empty<Printer>());

		private readonly Rule[] _rules = Array.Empty<Rule>();

		private readonly GameState _gameState = new GameState();

		public GameState GameState { get { return _gameState; } }

		private readonly WinFormTimer _timer;

		public Game(GameRenderer gameRenderer, GameState gameState, WinFormTimer timer, Rule[] rules)
		{
			_gameRenderer = gameRenderer;
			_gameState = gameState;
			_rules = rules;
			_timer = timer;
			_timer.Tick += Tick;
		}

		public void Start()
		{
			foreach (Rule rule in _rules)
			{
				rule.Start();
			}
			_timer.Start();
		}

		public void AddCommand(Command command)
		{
			_commands.Enqueue(command);
		}

		private void Tick(object? sender, EventArgs e)
		{
			// INPUT
			while (_commands.Count != 0)
			{
				Command command = _commands.Dequeue();
				command.Execute(_gameState);
			}
			// UPDATE
			foreach (Rule rule in _rules)
			{
				rule.Tick(_gameState);
			}
			// RENDER
			_gameRenderer.Render();
		}

	}
}
