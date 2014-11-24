using System;
using System.Collections.Generic;


namespace AlgorithmDesign
{
	public class MergeSort<T> : SortingAlgo <T> where T : IComparable <T> 
	{
		public override void Display(List<T> data, string filename, long incountnumb)
		{
			Console.WriteLine ("MergeSort -- Count inversion pairs:");
			base.Display (data, filename, incountnumb);
		}
			
		public override void Sort (List<T> data, int lo, int hi)
		{
			if (lo >= hi) {
				return;
			}
			int mid = (hi - lo) / 2 + lo;
			Sort (data, lo, mid);
			Sort (data, mid + 1, hi);
			Merge (data, lo, mid, hi);
		}

		//---------------------------- Private methods ------------------------------------------
		void Merge (List<T> data, int lo, int mid, int hi)
		{
			int i = lo;
			int j = mid + 1;

			T[] aux = new T [data.Count];
			data.CopyTo (aux);

			for (int k = lo; k <= hi; ++k) {
				if (i > mid) {
					data [k] = aux [j++];
				} else if (j > hi) {
					data [k] = aux [i++];
				} else if (aux [i].CompareTo(aux[j]) <= 0) {
					data [k] = aux [i++];
				} else {
					data [k] = aux [j++];
					countnumb += (mid + 1 - i);
				}
			}
		}

	}
}

