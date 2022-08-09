using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp_Test2.Extentions
{
	internal static class TwoDimensionalArrayExtension
	{
		public static (int, int) GetSize<T>(this T[,] array)
		{
			int rows = array.GetUpperBound(0) + 1;
			int columns = array.Length / rows;
			return (rows, columns);
		}
	}
}
