using System;
using System.Collections.Generic;

namespace AlgorithmDesign
{
	public class TwoSumGame
	{
		readonly static int start = -10000;
		readonly static int end   =  10000;

		public static int TwoSum( List<long> v )
		{
			int ncount = 0;
			var theset = new HashSet<long> ();

			theset.UnionWith (v);

			for (int target = start; target <= end; ++target) {
				if (CheckSum (theset, target)) {
					++ncount;
				}
			}
				
			Console.WriteLine ("The existing sum number is {0}.", ncount);
			return ncount;
		}

		static bool CheckSum(HashSet<long> theset, int target)
		{
			foreach (long i in theset) {
				long res = (long)target - i;
				if (i == res) {
					continue;
				} else if ( theset.Contains(res) ) {
					return true;
				}
			}
			return false;
		}

	}
}

