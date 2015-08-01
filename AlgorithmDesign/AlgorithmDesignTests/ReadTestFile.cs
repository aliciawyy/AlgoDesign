using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AlgorithmDesignTests
{
	static class ReadTestFile
	{
		private static readonly string DataPath = Path.Combine(Directory.GetCurrentDirectory(), "../../../../data");

	    private static string GetFullName(string filename)
	    {
            string fullname = Path.Combine(DataPath, filename);
            FileInfo fi = new FileInfo(fullname);
	        if (!fi.Exists)
	            throw new FileNotFoundException(fullname);
	        return fullname;
	    }

		public static string GetFullNameInteractive()
		{
			var files = Directory.EnumerateFiles (DataPath, "*.txt").Select (f => Path.GetFileName (f));
			Console.WriteLine ("Data files in the data directory :");
			foreach (string fi in files) {
				Console.Write("{0} ", fi);
			}
			Console.WriteLine ("\nEnter the file name :");
			string filename = Console.ReadLine();
			return GetFullName(filename);
		}

	    public static List<long> ReadLongIntegerArray(string filename)
		{
		    string fullname = GetFullName(filename);
            var result = new List<long>();
			using (FileStream fs = File.OpenRead (fullname))
			using (TextReader reader = new StreamReader (fs)) 
			{
				while (reader.Peek () > -1) {
					string s = reader.ReadLine ();
                    result.Add (Convert.ToInt64 (s));
				}
			}
			return result;
		}

		public static List<int> ReadIntFile(string filename)
		{
            string fullname = GetFullName(filename);
            var result = new List<int> (); // New int list
			using (FileStream fs = File.OpenRead (fullname))
			using (TextReader reader = new StreamReader (fs)) 
			{
				while (reader.Peek () > -1) {
					string s = reader.ReadLine ();
                    result.Add (Convert.ToInt32 (s));
				}
			}
			return result;
		}

		/// <summary>
		/// Reads the adjacent list representation of a graph.
		/// 1 22 34 12
		/// 2 12 345 1 12
		/// ...
		/// The index starts from 1
		/// In each row, the first term is the index vertex and the remaining terms are the vertices connected to it.
		/// </summary>
		/// <returns>The adjacent list.</returns>
		/// <param name="filename">Filename.</param>
		public static List<List<int> > ReadAdjacentList(string filename)
		{
		    string fullname = GetFullName(filename);

            List<List<int> > v = new List<List<int> > (); // New int list

			using (FileStream fs = File.OpenRead (fullname))
			using (TextReader reader = new StreamReader (fs)) 
			{
				while (reader.Peek () > -1) {
					string[] tokens = reader.ReadLine().Split();
					List<int> u = new List<int> ();
					for (int i = 1; i < tokens.Length; ++i) {
						if (tokens[i] != "") {
							u.Add (int.Parse (tokens [i]) - 1);
						}
					}
					v.Add (u);
				}
			}

			return v;
		}

		public static void ReadAdjacentListWithEdges(string filename, out List<List<int>> dgraph, out List<List<int>> dedge)
		{
		    string fullname = GetFullName(filename);

			dgraph = new List<List<int>> ();
			dedge  = new List<List<int>> ();

			using (FileStream fs = File.OpenRead (fullname))
			using (TextReader reader = new StreamReader (fs)) 
			{
				while (reader.Peek () > -1) {
					List<int> nodelist = new List<int> ();
					List<int> edges     = new List<int> ();

					string[] tokens = reader.ReadLine().Split('\t', ' ');
					for (int i = 1; i < tokens.Length; ++i) {
						if (tokens[i] != "") {
							string[] item = tokens [i].Split (',');
							nodelist.Add(int.Parse (item[0]) - 1);
							edges.Add(int.Parse (item[1]));
						}
					}
					dgraph.Add (nodelist);
					dedge.Add (edges);
				}
			}
		}


		/// <summary>
		/// Reads all edges of a _directed_ graph. An example of input file is
		/// 1 2
		/// 2 425
		/// 2 33
		/// ...
		/// The index starts from 1 and each row contains two terms where the first is the tail and the second
		/// is the head
		/// </summary>
		/// <param name="filename">Filename.</param>
		/// <param name="tail">List of the tails</param>
		/// <param name="head">List of the head</param>
		public static void ReadAllEdges(string filename, List<int> tail, List<int> head)
		{
            string fullname = GetFullName(filename);
            tail.Clear ();
            head.Clear ();

			using (FileStream fs = File.OpenRead (fullname))
			using (TextReader reader = new StreamReader (fs)) 
			{
				while (reader.Peek () > -1) {
					string[] tokens = reader.ReadLine().Split();
					tail.Add (int.Parse (tokens [0]) - 1);
					head.Add (int.Parse (tokens [1]) - 1);
				}
			}
		}

		/// <summary>
		/// Converts all edges representation to adjacent list representation of a graph.
		/// </summary>
		/// <param name="tail">Tail.</param>
		/// <param name="head">Head.</param>
		/// <param name="nvert">number of vertices</param>
		/// <param name="dgraph">output adjacent list representation of the graph</param>
		public static void ConvertAllEdgesToAdjacentList(List<int> tail, List<int> head, int nvert, List<List<int> > dgraph)
		{
			if (dgraph != null) {
				dgraph.Clear ();
			} else {
				dgraph = new List<List<int>> ();
			}

			for (int i = 0; i < nvert; ++i) {
				List<int> u = new List<int> ();
				dgraph.Add (u);
			}

			for (int i = 0; i < tail.Count; ++i) {
				int ind = tail [i];
				dgraph[ind].Add (head [i]);
			}
		}

		public static void PrintGraph(List<List<int> > dgraph)
		{
			for (int i = 0; i < dgraph.Count; ++i) {
				Console.Write ("{0}: ", i);
				for (int j = 0; j < dgraph [i].Count; ++j) {
					Console.Write ("{0} ", dgraph [i] [j]);
				}
				Console.Write ("\n");
			}
		}
	}
}

