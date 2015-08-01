using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;


namespace AlgorithmDesign
{
	class MainClass
	{
		enum TypeOfSortingAlgo { MergeSortType = 1, QuickSortType = 2 }

		private static Stopwatch aTimer;

		//-------------------------------------------------------------------------------------------------
		public static void Main (string[] args)
		{
			aTimer = new Stopwatch ();
			while (true) {

				string filename = ReadFile.GetInputFileName ();

				try {
					//SortingTest (filename);
					//CountSCC (filename);
					//minCutTest(filename);
					GetMedianSum(filename);
				}
				catch (FileNotFoundException e)
				{
					Console.WriteLine ("[Error]The file {0} doesn't exist. Program Exit.", e.FileName);
					return;
				}

				aTimer.Stop ();
				Console.WriteLine ("The elapse time is {0} ms.", aTimer.ElapsedMilliseconds);

				Console.WriteLine ("Continue to test ? (Y/N)");
				string flagcont = Console.ReadLine ();
				if (flagcont == "N")
					break;
			}
		}

		//-------------------------------------------------------------------------------------------------
		static void GetMedianSum(string filename)
		{
			List<int> v = ReadFile.ReadIntFile (filename);
			Console.WriteLine ("Finished loading the array of {0} terms.", v.Count);

			aTimer.Reset ();
			aTimer.Start ();

			MedianSeeker.CountMedian (v);
		}

		//-------------------------------------------------------------------------------------------------
		static void CountSCC(string filename)
		{
			List<int> tail = new List<int> ();
			List<int> head = new List<int> ();

			ReadFile.ReadAllEdges (filename, tail, head);
			Console.WriteLine ("[Info]Finished loading a graph with {0} edges.", tail.Count);

			aTimer.Reset ();
			aTimer.Start ();

			StronglyConnectedComponents.ComputeSCCAPI (tail, head);
		}


		//-------------------------------------------------------------------------------------------------
		static void minCutTest(string filename)
		{
			aTimer.Reset ();
			aTimer.Start ();

			List<List<int> > data = ReadFile.ReadAdjacentList (filename);

			Console.WriteLine ("Start Karger min cut.");
			List<int> num = new List<int> ();
			int N = data.Count;

			List<List<int> > dgraph = new List<List<int> > ();
			for (int i = 0; i < N*2; ++i) {
				
				dgraph.Clear ();
				data.ForEach( item => dgraph.Add( new List<int> (item) ) );

				int mincut = KargerMinCut.countCrossingEdges (dgraph, i);
				num.Add (mincut);
				Console.WriteLine ("The {0}-th mincut is {1}.", i, mincut);
			}
			Console.WriteLine ("The mincut is {0}.", num.Min());
		}

		//-------------------------------------------------------------------------------------------------
		static void SortingTest(string filename)
		{
			Console.WriteLine ("Enter the sorting algorithm you want to test:");
			Console.WriteLine ("1 - MergeSort (default)");
			Console.WriteLine ("2 - QuickSort");

			int optmethod0 = Convert.ToInt32(Console.ReadLine ());
			TypeOfSortingAlgo optmethod = (optmethod0 == 2) ? TypeOfSortingAlgo.QuickSortType : TypeOfSortingAlgo.MergeSortType;

			List<int> data = ReadFile.ReadIntFile (filename);

			aTimer.Reset ();
			aTimer.Start ();

			SortingAlgo<int> sortingalgo;

			switch (optmethod) 
			{
			case TypeOfSortingAlgo.MergeSortType:
				Console.WriteLine ("[Info]Start MergeSort...");

				sortingalgo = new MergeSort<int> ();
				break;

			case TypeOfSortingAlgo.QuickSortType:
				Console.WriteLine ("[Info]Start QuickSort...");

				Console.WriteLine ("Enter the pivot position:\n0 for fist\n1 for last\n2 for 3-ways median\n3 for random");
				Console.WriteLine ("4 for median order");
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
