using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;


namespace AlgorithmDesign
{
	class MainClass
	{
		static readonly string datapath = Path.Combine(Directory.GetCurrentDirectory(), "../../../../data");

		enum TypeOfSortingAlgo { MergeSortType = 1, QuickSortType = 2 }

		private static Stopwatch aTimer;

		//-------------------------------------------------------------------------------------------------
		public static void Main (string[] args)
		{

			aTimer = new Stopwatch ();
			while (true) {
				//SortingTest ();
				CountSCC ();

				Console.WriteLine ("Continue to test ? (Y/N)");
				string flagcont = Console.ReadLine ();
				if (flagcont == "N")
					break;
			}

			return;
		}

		//-------------------------------------------------------------------------------------------------
		static void CountSCC()
		{
			var files = Directory.EnumerateFiles (datapath, "*.txt").Select (f => Path.GetFileName (f));
			Console.WriteLine ("Data files in the data directory :");
			foreach (string fi in files) {
				Console.Write("{0} ", fi);
			}
			Console.WriteLine ("\nEnter the file name :");
			string filename = Console.ReadLine();
			string fullname = Path.Combine(datapath, filename);
		
			List<int> tail = new List<int> ();
			List<int> head = new List<int> ();

			ReadFile.ReadSCC (fullname, ref tail, ref head);
			Console.WriteLine ("[Info] Finished loading a graph with {0} edges.", tail.Count);
		}


		//-------------------------------------------------------------------------------------------------
		static void minCutTest()
		{
			var files = Directory.EnumerateFiles (datapath, "*.txt").Select (f => Path.GetFileName (f));
			Console.WriteLine ("Data files in the data directory :");
			foreach (string fi in files) {
				Console.Write("{0} ", fi);
			}
			Console.WriteLine ("\nEnter the file name :");
			string filename = Console.ReadLine();
			string fullname = Path.Combine(datapath, filename);

			List<List<int> > data = ReadFile.ReadAdjacentGraph (fullname);

			Console.WriteLine ("Start Karger min cut.");
			List<int> num = new List<int> ();
			int N = data.Count;

			List<List<int> > dgraph = new List<List<int>> ();
			for (int i = 0; i < N*2; ++i) {
				
				dgraph.Clear ();
				foreach (List<int> k in data) {
					List<int> u = new List<int> ();
					foreach (int d in k) {
						u.Add (d);
					}
					dgraph.Add (u);
				}
					
				int mincut = KargerMinCut.countCrossingEdges (dgraph, i);
				num.Add (mincut);
				Console.WriteLine ("The {0}-th mincut is {1}.", i, mincut);
			}
			Console.WriteLine ("The mincut is {0}.", num.Min());
		}

		//-------------------------------------------------------------------------------------------------
		static void SortingTest()
		{
			Console.WriteLine ("Enter the sorting algorithm you want to test:");
			Console.WriteLine ("1 - MergeSort (default)");
			Console.WriteLine ("2 - QuickSort");

			int optmethod0 = Convert.ToInt32(Console.ReadLine ());
			TypeOfSortingAlgo optmethod = (optmethod0 == 2) ? TypeOfSortingAlgo.QuickSortType : TypeOfSortingAlgo.MergeSortType;

			string filename0;

			var files = Directory.EnumerateFiles (datapath, "*.txt").Select (f => Path.GetFileName (f));
			Console.WriteLine ("Data files in the data directory :");
			foreach (string fi in files) {
				Console.Write("{0} ", fi);
			}
			Console.WriteLine ("\nEnter the file name (IntegerArray.txt by default):");
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

			aTimer.Reset ();
			aTimer.Start ();

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

			aTimer.Stop ();
			sortingalgo.Display (data, filename, nresult);

			Console.WriteLine ("The elapse time is {0} ms.", aTimer.ElapsedMilliseconds);
		}
	}
}
