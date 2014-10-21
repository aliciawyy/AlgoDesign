using System;
using System.Collections.Generic;

namespace AlgorithmDesign
{
	class MainClass
	{
		static readonly string datapath = "/home/alicia/Codes/CSharp/MyFirstCsharp/data/"; 
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

			TypeOfSortingAlgo optmethod = (TypeOfSortingAlgo) Convert.ToInt32(Console.ReadLine ());

			string filename0;
			Console.WriteLine ("Enter the file name (IntegerArray.txt by default):");
			filename0 = Console.ReadLine();
			if (filename0 == "") {
				filename0 = "IntegerArray.txt";
				Console.WriteLine ("Load the default data file {0}", filename0);
			}

			string filename = datapath + filename0;
			List<int> data = ReadFile.ReadIntFile (filename);

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

			default:
				goto case 1;
			}

			long nresult = sortingalgo.CountNumber(data);
			sortingalgo.Display (data, filename, nresult);
		}
	}
}
