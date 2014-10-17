using System;
using System.IO;


namespace Algorithms
{

	class Program
	{
		static void Main()
		{
			string filename = "../../data/tinyW.txt";
			TestReadAndWrite.ReadFileTest (filename);
		}
	}
	/// <summary>
	/// Implementation of the algorithm merge sort.
	/// </summary>
	public class MergeSort
	{
		public MergeSort ()
		{
		}
	}

	public class TestReadAndWrite
	{
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

		public static void ReadFileTest(string filename)
		{
			using (FileStream fs = File.OpenRead (filename))
			using (TextReader reader = new StreamReader (fs)) 
			{
				while (reader.Peek () > -1) {
					Console.WriteLine (reader.ReadLine ());
				}
			}
		}
	}
}

