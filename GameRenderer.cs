namespace WinFormsApp_Test2
{
	internal class GameRenderer
	{
		private Printer[] Printers;

		public GameRenderer(Printer[] printers)
		{
			Printers = printers;
		}

		public void Render()
		{
			foreach (Printer printer in Printers)
			{
				printer.Print();
			}
		}
	}
}
