using System;
using System.Collections.Generic;
using System.IO;

namespace AlgorithmDesign
{
	class MainClass
	{
		static readonly string datapath = Path.Combine(Directory.GetCurrentDirectory(), "../../../../data");

		enum TypeOfSortingAlgo { MergeSortType = 1, QuickSortType = 2 }

		public static void Main (string[] args)
		{
			SortingTest ();
		}

		static void SortingTest()
		{
			Console.WriteLine ("Enter the sorting algorithm you want to test:");
			Console.WriteLine ("1 - MergeSort (default)");
			Console.WriteLine ("2 - QuickSort");

			int optmethod0 = Convert.ToInt32(Console.ReadLine ());
			TypeOfSortingAlgo optmethod = (optmethod0 == 2) ? TypeOfSortingAlgo.QuickSortType : TypeOfSortingAlgo.MergeSortType;

			string filename0;
			Console.WriteLine ("Enter the file name (IntegerArray.txt by default):");
			filename0 = Console.ReadLine();
			if (filename0 == "") {
				filename0 = "IntegerArray.txt";
				Console.WriteLine ("Load the default data file {0}", filename0);
			}

			string filename = Path.Combine(datapath, filename0);
			List<int> data;
			try {
				data = ReadFile.ReadIntFile (filename);
			}
			catch (FileNotFoundException)
			{
				Console.WriteLine ("[Error]The file {0} doesn't exist. Program Exit.", filename);
				return;
			}

			SortingAlgo<int> sortingalgo;

			switch (optmethod) 
			{
			case TypeOfSortingAlgo.MergeSortType:
				Console.WriteLine ("[Info]Start MergeSort...");

				sortingalgo = new MergeSort<int> ();
				break;

			case TypeOfSortingAlgo.QuickSortType:
				Console.WriteLine ("[Info]Start QuickSort...");

				Console.WriteLine ("Enter the pivot position:(0 for fist, 1 for last, 2 for 3-ways median, 3 for random)");
				int pivotpos = Convert.ToInt32(Console.ReadLine ());

				sortingalgo = new QuickSort<int> (pivotpos);
				break;

			default: // Use MergeSort by default
				goto case TypeOfSortingAlgo.MergeSortType;
			}

			long nresult = sortingalgo.CountNumber(data);
			sortingalgo.Display (data, filename, nresult);
		}
	}
}
