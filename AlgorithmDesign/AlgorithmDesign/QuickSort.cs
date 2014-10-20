using System;
using System.Collections.Generic;


namespace AlgorithmDesign
{
	public class QuickSort
	{
		public static long CountComparison(List<int> data)
		{
			countcomp = 0;

			flagpartition = 0;// 0 for First; 1 for Last; 2 for middle

			Sort (data, 0, data.Count - 1);
			return countcomp;
		}

		static void Sort (List<int> data, int lo, int hi)
		{
			if (lo >= hi) {
				return;
			}
			int j = Partition (data, lo, hi);
			Sort (data, lo, j - 1);
			Sort (data, j + 1, hi);
		}

		static int Partition(List<int> data, int lo, int hi)
		{
			countcomp += hi - lo;

			int ind_pivot = 0;

			if (flagpartition == 0) {
				ind_pivot = lo;
			}

			int pivot = data [ind_pivot];

			int i = lo;
			for ( int j = lo + 1; j <= hi; ++j ) {
				if (data [j] < pivot) {
					Exch (data, j, ++i);
				}
			}
				
			//Console.WriteLine ("The position of the pivot data[{0}] = {1} is {2}", ind_pivot, data[ind_pivot], i);

			if (i != lo) { 
				Exch (data, ind_pivot, i);
			}

			return i;
		}

		static void Exch (List<int> data, int i, int j)
		{
			int tmp = data [i];
			data [i] = data [j];
			data [j] = tmp;
		}

		static int flagpartition;

		public static long countcomp { get; private set;}
	}
}