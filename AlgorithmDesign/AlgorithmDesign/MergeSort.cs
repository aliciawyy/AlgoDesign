using System;
using System.Collections.Generic;


namespace AlgorithmDesign
{
	public class MergeSort
	{
		public static long CountInverse(List<int> data)
		{
			count = 0;
			Sort (data, 0, data.Count - 1);
			return count;
		}

		public static void Sort (List<int> data, int lo, int hi)
		{
			if (lo >= hi) {
				return;
			}
			int mid = (hi - lo) / 2 + lo;
			Sort (data, lo, mid);
			Sort (data, mid + 1, hi);
			Merge (data, lo, mid, hi);
		}

		static void Merge (List<int> data, int lo, int mid, int hi)
		{
			int i = lo;
			int j = mid + 1;

			int[] aux = new int [data.Count];
			data.CopyTo (aux);

			for (int k = lo; k <= hi; ++k) {
				if (i > mid) {
					data [k] = aux [j++];
				} else if (j > hi) {
					data [k] = aux [i++];
				} else if (aux [i] <= aux [j]) {
					data [k] = aux [i++];
				} else {
					data [k] = aux [j++];
					count += (mid + 1 - i);
				}
			}
		}

		public static long count { get; private set;}
	}
}

