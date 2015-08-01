using System;
using System.Collections.Generic;
using System.Linq;

using ConcurrentPriorityQueue;

namespace AlgorithmDesign
{
    

    public class ShortDist
    {
        /// <summary>
        /// The vertex id
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; private set; }

        /// <summary>
        /// The shortest distance from the source to the verte
        /// It needs to be updated each time.
        /// </summary>
        /// <value>The length.</value>
        public int Len { get; set; }

        public ShortDist(int id, int len) {
            Id = id;
            Len = len;
        }
    }

    // Inverse the priority
    public class InverseComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y - x;
        }
    }

    public class DijkstraSP
    {
        private readonly AdjacentGraph _adjacentGraph;

        public DijkstraSP(List<List<int>> dgraph, List<List<int>> dedge)
        {
            _adjacentGraph = new AdjacentGraph(dgraph, dedge);
        }

		static readonly int infdist = int.MaxValue;

		public static List<int> ComputeShortestPath(List<List<int>> dgraph, List<List<int>> dedge, int source, List<int> dest)
		{
			int nvert = dgraph.Count;

            // Initialization of the heap, it is implemented with a sorted List and binary search
            var vertheap = new ConcurrentPriorityQueue<ShortDist, int>(new InverseComparer());
            List<ShortDist> vertlist = new List<ShortDist>();
			for (int i = 0; i < nvert; ++i) {
				ShortDist vertex = new ShortDist (id: i, len: infdist);
				vertlist.Add (vertex);
                if (i == source) continue;
				vertheap.Enqueue( vertex, infdist ); // infdist is the priority
			}

			vertlist [source].Len = 0; // Update the shortest path from source to source

			for (int i = 0; i < dgraph [source].Count; ++i) {
				int neighbor = dgraph [source] [i];

				vertlist[neighbor].Len = dedge [source] [i]; // Update the shortest path of source's neighbor

				vertheap.UpdatePriority (vertlist [neighbor], vertlist [neighbor].Len);
			}

			//PrintShortPath (vertlist);
			//-----------------------------------------------------------
			while (vertheap.Count > 0) {

				ShortDist extractmin = vertheap.Dequeue ();

				 //Console.WriteLine ("The extractmin id = {0}, len = {1}, the heap size is {2}", 
				 //	extractmin.Id, extractmin.Len, vertheap.Count);
	
				int ind = extractmin.Id; // The vertex id of the min

				for (int i = 0; i < dgraph [ind].Count; ++i) {
					int neighbor = dgraph [ind] [i];

					if (vertheap.Contains (vertlist [neighbor])) {

						// The shortest path to neighbor = SP to min origin + dist between origin and neighbor
						vertlist [neighbor].Len = Math.Min(vertlist [neighbor].Len, vertlist [ind].Len + dedge [ind] [i]); 

						vertheap.UpdatePriority (vertlist [neighbor], vertlist [neighbor].Len);
					}
				}

				// PrintShortPath (vertlist);
			}

			//-----------------------------------------------------------
			List<int> result = new List<int> (new int[dest.Count]);

			for (int i = 0; i < dest.Count; ++i) {
				int ind = dest [i];
				result [i] = vertlist [ind].Len;
			}
				
			//-----------------------------------------------------------
			PrintResult (source, dest, result);
			return result;
		}

		static void PrintResult(int source, List<int> dest, List<int> distance)
		{
			Console.WriteLine ("From the source = {0}", source);
			Console.WriteLine ("To the following destinations:");

			int i;
			for (i = 0; i < (dest.Count-1); ++i) {
				Console.Write("{0},", dest [i]);
			}
			Console.Write ("{0}\n", dest [i]);
			Console.WriteLine ("The shortest path lengths are");
			for (i = 0; i < (distance.Count-1); ++i) {
				Console.Write("{0},", distance [i]);
			}
			Console.Write ("{0}\n", distance [i]);
		}
	}
}

