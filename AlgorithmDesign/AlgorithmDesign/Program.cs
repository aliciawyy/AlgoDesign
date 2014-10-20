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
			string filename0 = "QuickSort.txt";
			Console.WriteLine ("Enter the file name :");
			filename0 = Console.ReadLine();
			Console.WriteLine ("Enter the pivot :(0 for fist, 1 for last, 2 for 3 ways median)");
			int optmethod = Convert.ToInt32(Console.ReadLine ());
			string filename = datapath + filename0;//
			List<int> data = ReadFile.ReadIntFile (filename);

			long countcomp = QuickSort.CountComparison (data, optmethod);

			Console.WriteLine ("File name : {0}", filename);
			Console.WriteLine ("The Length of the data is {0}", data.Count);
			Console.WriteLine ("The number of comparisons of the data is ");
			Console.Write (countcomp);
		}

		static string datapath = "/home/alicia/Codes/CSharp/MyFirstCsharp/data/"; 
	}
}
