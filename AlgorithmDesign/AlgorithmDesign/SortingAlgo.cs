using System;
using System.Collections.Generic;

namespace AlgorithmDesign
{
	public abstract class SortingAlgo <T> where T : IComparable <T> 
	{
		/// <summary>
		/// Counts the number. This is the target function.
		/// </summary>
		/// <returns>The number.</returns>
		/// <param name="data">The List of data for counting.</param>
		public long CountNumber (List<T> data)
		{
			countnumb = 0;
			Sort (data, 0, data.Count - 1);
			return countnumb;
		}

		public virtual void Display (List<T> data, string filename, long countnumb)
		{
			Console.WriteLine ("File name : {0}", filename);
			Console.WriteLine ("The Length of the data is {0}", data.Count);
			Console.WriteLine ("The number of count is {0}", countnumb);
		}

		/// <summary>
		/// Sort the specified data, lo and hi are the low and high index boundaries.
		/// </summary>
		/// <param name="data">Data</param>
		/// <param name="lo">Low index boundary</param>
		/// <param name="hi">Hi index boundary</param>
		public abstract void Sort (List<T> data, int lo, int hi);

		protected long countnumb { get; set; }
	}
}

