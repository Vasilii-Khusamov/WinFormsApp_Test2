﻿using WinFormTimer = System.Windows.Forms.Timer;

namespace WinFormsApp_Test2
{
	internal class Game
	{
		private GameRenderer _gameRenderer = new GameRenderer(new Printer[0]);

		private Rule[] _rules = new Rule[0];

		private GameState _gameState = new GameState();

		public GameState GameState { get { return _gameState; } set { _gameState = value; } }


		private WinFormTimer timer = new WinFormTimer()
		{
			Interval = 33
		};

		public Game(GameRenderer gameRenderer, GameState gameState, Rule[] rules)
		{
			_gameRenderer = gameRenderer;
			_gameState = gameState;
			_rules = rules;
			timer.Tick += Tick;
		}

		public void Start()
		{
			foreach (Rule rule in _rules)
			{
				rule.Start();
			}
			timer.Start();
		}

		private void Tick(object? sender, EventArgs e)
		{
			foreach (Rule rule in _rules)
			{
				rule.Tick();
			}
			_gameRenderer.Render();
		}
	}
}
