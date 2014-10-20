using System;
using System.Collections.Generic;

namespace AlgorithmDesign
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			 //MergeSortTest();
			QuickSortTest ();

		}

		static void MergeSortTest()
		{
			string filename = datapath + "IntegerArray.txt";
			List<int> data = ReadFile.ReadIntFile (filename);

			long countinv = MergeSort.CountInverse (data);

			Console.WriteLine ("File name : {0}", filename);
			Console.WriteLine ("The Length of the data is {0}", data.Count);
			Console.WriteLine ("The number of inverse pairs in the data is ");
			Console.Write (countinv);
		}

		static void QuickSortTest()
		{
			string filename = datapath + "1000.txt";//"QuickSort.txt";
			List<int> data = ReadFile.ReadIntFile (filename);

			long countcomp = QuickSort.CountComparison (data);

			Console.WriteLine ("File name : {0}", filename);
			Console.WriteLine ("The Length of the data is {0}", data.Count);
			Console.WriteLine ("The number of comparisons of the data is ");
			Console.Write (countcomp);
		}

		static string datapath = "/home/alicia/Codes/CSharp/MyFirstCsharp/data/"; 
	}
}
