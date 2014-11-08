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

		public static List<List<int> > ReadAdjacentGraph(string filename)
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

		public static void ReadSCC(string filename, ref List<int> tail, ref List<int> head)
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
					tail.Add (int.Parse (tokens [0]));
					head.Add (int.Parse (tokens [1]));
				}
			}
				
			return;
		}
	}
}

