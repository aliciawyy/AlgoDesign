using System;
using System.Collections.Generic;
using System.IO;

namespace AlgorithmDesign
{
	public class ReadFile
	{
		public static List<int> ReadIntFile(string filename)
		{
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

		public static void Test()
		{
			using (Stream s = new FileStream ("test.txt", FileMode.Create)) 
			{
				Console.WriteLine (s.CanRead);
				Console.WriteLine (s.CanWrite);
				Console.WriteLine (s.CanSeek);

				s.WriteByte (101);
				byte[] block = { 1, 2, 3, 4, 5 };
				s.Write (block, 0, block.Length);

				Console.WriteLine (s.Length);
				Console.WriteLine (s.Position);

				s.Position = 0; // Move back to the start

				byte[] block2 = new byte[5];
				Console.WriteLine (s.ReadByte ());
				Console.WriteLine (s.Read (block2, 0, block2.Length)); 
				Console.WriteLine (block2[2]);
			}
		}
	}
}

