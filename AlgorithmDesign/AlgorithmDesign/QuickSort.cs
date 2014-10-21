using System;
using System.Collections.Generic;


namespace AlgorithmDesign
{
	public static class QuickSort
	{
		public static long CountComparison(List<int> data, int optmethod)
		{
			countcomp = 0;

			flagpartition = optmethod;// 0 for First; 1 for Last; 2 for middle

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

			// Choose the pivot term
			switch (flagpartition) {
			case 1:
				Exch (data, hi, lo);
				break;
			case 2:
				int ind_pivot = Median (data, lo, hi, (int)(hi + lo) / 2);
				Exch (data, ind_pivot, lo);
				break;
			default:
				break;
			}

			int pivot = data [lo];

			int i = lo;
			for ( int j = lo + 1; j <= hi; ++j ) {
				if (data [j] < pivot) {
					Exch (data, j, ++i);
				}
			}
				
			//Console.WriteLine ("The position of the pivot data[{0}] = {1} is {2}", ind_pivot, data[ind_pivot], i);

			if (i != lo) { 
				Exch (data, lo, i);
			}

			return i;
		}

		static void Exch (List<int> data, int i, int j)
		{
			int tmp = data [i];
			data [i] = data [j];
			data [j] = tmp;
		}

		static int Median(List<int> data, int a, int b, int c) {

			if ( (data[a] - data[b]) * (data[c] - data[a]) >= 0 ) // a >= b and a <= c OR a <= b and a >= c
				return a;
			else if ( (data[b] - data[a]) * (data[c] - data[b]) >= 0 ) // b >= a and b <= c OR b <= a and b >= c
				return b;
			else
				return c;
		}

		static int flagpartition;

		public static long countcomp { get; private set;}
	}
}