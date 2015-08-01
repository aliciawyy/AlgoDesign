using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmDesign
{
    public class MedianSeeker
    {
        public static int CountMedian( List<int> v )
        {
            int nsize = v.Count;
            int medsum = 0;
            List<int> vsorted = new List<int> (nsize); 
            for (int i = 0; i < nsize; ++i)
            {
                vsorted.Add (v [i]);
                medsum += vsorted.OrderBy (t => t).Take(i/2 + 1).Max();
            }
            int res = medsum % nsize;
            Console.WriteLine ("The sum and residual of medians are {0} and {1}.", medsum, res);
            return res;
        }
    }
}

