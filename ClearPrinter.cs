namespace WinFormsApp_Test2
{
	internal class ClearPrinter : Printer
	{
		private readonly Graphics _secondGraphics;

		public ClearPrinter(Graphics secondGraphics)
		{
			_secondGraphics = secondGraphics;
		}

		public override void Print()
		{
			_secondGraphics.Clear(Color.Black);
		}
	}
}
