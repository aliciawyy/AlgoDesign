using System;
using System.Collections.Generic;

namespace AlgorithmDesign
{
	public interface SortingAlgo <T> where T : IComparable <T> 
	{
		long CountNumber (List<T> data);
		void Display (List<T> data, string filename, long countnumb);

		/// <summary>
		/// Sort the specified data, lo and hi are the low and high index boundaries.
		/// </summary>
		/// <param name="data">Data</param>
		/// <param name="lo">Low index boundary</param>
		/// <param name="hi">Hi index boundary</param>
		void Sort (List<T> data, int lo, int hi);
	}
}

