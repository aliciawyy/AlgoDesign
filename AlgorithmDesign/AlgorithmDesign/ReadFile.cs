using System;
using System.Collections.Generic;
using System.IO;

namespace AlgorithmDesign
{
	public class ReadFile
	{
		public static List<int> ReadIntFile(string filename)
		{
			FileInfo fi = new FileInfo (filename);
			if (!fi.Exists) {
				throw new FileNotFoundException ();
			}
				
			List<int> v = new List<int> (); // New int list

			using (FileStream fs = File.OpenRead (filename))
			using (TextReader reader = new StreamReader (fs)) 
			{
				while (reader.Peek () > -1) {
					string s = reader.ReadLine ();
					v.Add (Convert.ToInt32 (s));
				}
			}

			return v;
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
			FileInfo fi = new FileInfo (filename);
			if (!fi.Exists) {
				throw new FileNotFoundException ();
			}

			List<List<int> > v = new List<List<int> > (); // New int list

			using (FileStream fs = File.OpenRead (filename))
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
			FileInfo fi = new FileInfo (filename);
			if (!fi.Exists) {
				throw new FileNotFoundException ();
			}

			tail.Clear ();
			head.Clear ();

			using (FileStream fs = File.OpenRead (filename))
			using (TextReader reader = new StreamReader (fs)) 
			{
				while (reader.Peek () > -1) {
					string[] tokens = reader.ReadLine().Split();
					tail.Add (int.Parse (tokens [0]) - 1);
					head.Add (int.Parse (tokens [1]) - 1);
				}
			}
				
			return;
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
	}
}

