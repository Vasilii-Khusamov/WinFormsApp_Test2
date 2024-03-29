﻿namespace WinFormsApp_Test2.Printers
{
	/// <summary>
	/// Класс построен на основе примера со страницы:
	/// https://docs.microsoft.com/ru-ru/dotnet/api/system.drawing.bufferedgraphics?view=windowsdesktop-3.1
	/// </summary>
	internal class SecondBufferPrinter : Printer
	{
		private Graphics _mainGraphics;
		private Graphics _secondGraphics;
		private BufferedGraphics _bufferedGraphics;

		public SecondBufferPrinter(Graphics mainGraphics, int mainFormWidth, int mainFormHeight)
		{
			_mainGraphics = mainGraphics;

			BufferedGraphicsContext bufferedGraphicsContext = BufferedGraphicsManager.Current;
			_bufferedGraphics = bufferedGraphicsContext.Allocate(mainGraphics, new Rectangle(0, 0, mainFormWidth, mainFormHeight));
			_secondGraphics = _bufferedGraphics.Graphics;
		}

		public Graphics SecondGraphics
		{
			get { return _secondGraphics; }
		}

		public override void Print()
		{
			_bufferedGraphics.Render(_mainGraphics);
		}
	}
}
