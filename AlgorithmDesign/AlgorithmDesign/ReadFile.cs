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
				
			List<int> v = new List<int> (); // New double list

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
	}
}

