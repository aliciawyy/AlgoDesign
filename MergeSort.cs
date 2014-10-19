using System;
using System.Collections.Generic;
using System.IO;


namespace Algorithms
{

	class Program
	{
		static void Main()
		{
			string filename = "./data/IntegerArray.txt";
			List<double> data = TestReadAndWrite.ReadDataFile (filename);

			long countinv = MergeSort.CountInverse (data);

			Console.WriteLine ("File name : {0}", filename);
			Console.WriteLine ("The Length of the data is {0}", data.Count);
			Console.WriteLine ("The number of inverse pairs in the data is ");
			Console.Write (countinv);
		}
	}
	/// <summary>
	/// Implementation of the algorithm merge sort.
	/// </summary>
	public class MergeSort
	{
		public static long CountInverse(List<double> data)
		{
			count = 0;
			Sort (data, 0, data.Count - 1);
			return count;
		}

		public static void Sort (List<double> data, int lo, int hi)
		{
			if (lo >= hi) {
				return;
			}
			int mid = (hi - lo) / 2 + lo;
			Sort (data, lo, mid);
			Sort (data, mid + 1, hi);
			Merge (data, lo, mid, hi);
	//		Console.WriteLine ("The count is {0} between lo {1} and hi {2}", count, lo, hi);
		}

		static void Merge (List<double> data, int lo, int mid, int hi)
		{
			int i = lo;
			int j = mid + 1;

			double[] aux = new double [data.Capacity];
			data.CopyTo (aux);

			for (int k = lo; k <= hi; ++k) {
				if (i > mid) {
					data [k] = aux [j++];
				} else if (j > hi) {
					data [k] = aux [i++];
				} else if (aux [i] <= aux [j]) {
					data [k] = aux [i++];
				} else {
					data [k] = aux [j++];
					count += (mid + 1 - i);
				}
			}
		}

		public static long count { get; private set;}
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
			List<double> v = new List<double> (); // New double list

			using (FileStream fs = File.OpenRead (filename))
			using (TextReader reader = new StreamReader (fs)) 
			{
				while (reader.Peek () > -1) {
					string s = reader.ReadLine ();
					Console.WriteLine (s);
					v.Add (Convert.ToDouble (s));
				}
			}

			Console.WriteLine ("About the vector v");
			Console.WriteLine (v[v.Capacity-1]);
		}

		public static List<double> ReadDataFile(string filename)
		{
			List<double> v = new List<double> (); // New double list

			using (FileStream fs = File.OpenRead (filename))
			using (TextReader reader = new StreamReader (fs)) 
			{
				while (reader.Peek () > -1) {
					string s = reader.ReadLine ();
					v.Add (Convert.ToDouble (s));
				}
			}

			return v;
		}
	}
}

