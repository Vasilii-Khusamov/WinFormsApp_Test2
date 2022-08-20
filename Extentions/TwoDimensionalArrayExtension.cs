using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp_Test2.Extentions
{
	internal static class TwoDimensionalArrayExtension
	{
		/// <summary>
		/// Возвращает размер двухмерного массива.
		/// </summary>
		/// <typeparam name="T">Тип ячейки массива</typeparam>
		/// <param name="array">Исходный массив</param>
		/// <returns>Возвращает количество строк (Item1) и колонок (Item2)</returns>
		public static (int, int) GetSize<T>(this T[,] array)
		{
			int rows = array.GetUpperBound(0) + 1;
			int columns = array.Length / rows;
			return (rows, columns);
		}
	}
}