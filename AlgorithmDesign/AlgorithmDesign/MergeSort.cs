using System;
using System.Collections.Generic;


namespace AlgorithmDesign
{
	public class MergeSort<T> : SortingAlgo <T> where T : IComparable
	{
		long countinv;

		public MergeSort() 
		{
			countinv = 0;
		}

		public long CountNumber (List<T> data)
		{
			Sort (data, 0, data.Count - 1);
			return countinv;
		}

		public void Display (List<T> data, string filename, long countnumb)
		{
			Console.WriteLine ("File name : {0}", filename);
			Console.WriteLine ("The Length of the data is {0}", data.Count);
			Console.WriteLine ("The number of inversion paris of the data is {0}", countnumb);
		}
			
		public void Sort (List<T> data, int lo, int hi)
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
					countinv += (mid + 1 - i);
				}
			}
		}


	}
}

