using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmDesign
{
	public class TwoSumGame
	{
		public static int TwoSum(List<long> integerArray, int start, int end)
		{
			int ncount = 0;
			var integerSet = new HashSet<long>(integerArray);

		    for (int targetSum = start; targetSum <= end; ++targetSum)
		        if (integerSet.Any(i => (targetSum - i) != i & integerSet.Contains(targetSum - i)))
                    ++ncount;
		    Console.WriteLine ("The existing sum number is {0}.", ncount);
			return ncount;
		}
	}
}

