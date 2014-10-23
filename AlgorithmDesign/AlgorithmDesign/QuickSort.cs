using System;
using System.Collections.Generic;


namespace AlgorithmDesign
{
	public class QuickSort<T> : SortingAlgo <T> where T : IComparable <T> 
	{
		enum PivotPosition { First = 0, Final = 1, Median3ways = 2, RandomTerm = 3 }

		/// <summary>
		/// The flagpartition shows the position of the pivot
		/// 0 for First; 1 for Last; 2 for 3-ways median; 3 for random term
		/// </summary>
		PivotPosition flagpartition;

		public QuickSort(int pivotpos)
		{
			flagpartition = (PivotPosition) pivotpos;
		}

		public override void Display(List<T> data, string filename, long incountnumb)
		{
			Console.WriteLine ("QuickSort -- Count comparisons:");
			base.Display (data, filename, incountnumb);
		}

		public override void Sort (List<T> data, int lo, int hi)
		{
			if (lo >= hi) {
				return;
			}
			int j = Partition (data, lo, hi);
			Sort (data, lo, j - 1);
			Sort (data, j + 1, hi);
		}

		//---------------------------- Private methods ------------------------------------------
		int Partition(List<T> data, int lo, int hi)
		{
			countnumb += hi - lo;

			// Choose the pivot term
			int ind_pivot;

			switch (flagpartition) {
			case PivotPosition.First:
				break;
			case PivotPosition.Final:
				Exch (data, hi, lo);
				break;
			case PivotPosition.Median3ways:
				ind_pivot = Median (data, lo, hi, (int)(hi + lo) / 2);
				Exch (data, ind_pivot, lo);
				break;
			case PivotPosition.RandomTerm:
				Random rnd = new Random();
				ind_pivot = rnd.Next(lo, hi + 1);
				Exch (data, ind_pivot, lo);
				break;
			default:
				break;
			}

			T pivot = data [lo];

			int i = lo;
			for ( int j = lo + 1; j <= hi; ++j ) {
				if (data[j].CompareTo(pivot) < 0 && j != (++i)) {
					Exch (data, j, i);
				}
			}

			if (i != lo) { 
				Exch (data, lo, i);
			}

			return i;
		}

		void Exch (List<T> data, int i, int j)
		{
			T tmp = data [i];
			data [i] = data [j];
			data [j] = tmp;
		}
			
		int Median(List<T> data, int a, int b, int c) {

			if (data [a].CompareTo (data [b]) <= 0 && data [a].CompareTo (data [c]) >= 0) {
				return a;
			} else if (data [a].CompareTo (data [b]) >= 0 && data [a].CompareTo (data [c]) <= 0) {
				return a;
			} else if (data [b].CompareTo (data [a]) <= 0 && data [b].CompareTo (data [c]) >= 0) {
				return b;
			} else if (data [b].CompareTo (data [a]) >= 0 && data [b].CompareTo (data [c]) <= 0) {
				return b;
			} else {
				return c;
			}
		}

	}
}