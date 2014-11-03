using System;
using System.Collections.Generic;

namespace AlgorithmDesign
{
	public class KargetMinCut
	{
		static List<int> vertexarray;

		static public int countCrossingEdges(List<List<int> > dgraph, int randseed)
		{
			const int nsize = dgraph.Count;
			for (int i = 0; i < nsize; ++i) { // Populate the vertex list
				vertexarray.Add (i);
			}

			Random rand = new Random (randseed);
			while (vertexarray.Count > 2) {
				int indcontract = rand.Next(0, vertexarray.Count);
				vertexarray.RemoveAt(indcontract)

			}

		}
	}
}

