using System;
using System.Collections.Generic;

namespace AlgorithmDesign
{
	public class KargerMinCut
	{
		static List<int> vertexarray;

		static public int countCrossingEdges(List<List<int> > dgraph, int randseed)
		{
			vertexarray = new List<int> ();
			int nsize = dgraph.Count;
			for (int i = 0; i < nsize; ++i) { // Populate the vertex list
				vertexarray.Add (i);
			}

			Random rand = new Random (randseed);
			int vt1, vt2;
			while (vertexarray.Count > 2) {

				vt1 = Choose (vertexarray, rand, 0);

				vt2 = Choose (dgraph [vt1], rand, 0); // Find vt2 in the adjacent list of vt1
				Console.WriteLine ("Enter choosing  dgraph[vt1 = {0}].Count = {1} and vertexarray.Count = {2} and vt2 = {3}",vt1, dgraph [vt1].Count, vertexarray.Count, vt2);



				for (int j = 0; j < dgraph[vt1].Count; ++j ) {
					int vet = dgraph [vt1] [j];
					dgraph [vet].ForEach (i => i = (i == vt1) ? vt2 : i);	
					dgraph [vt2].Add (vet);
				}

				dgraph [vt1].Clear();
				for (int j = 0; j < dgraph [vt2].Count; ++j) {
					if (dgraph [vt2] [j] == vt2) {
						dgraph [vt2].RemoveAt (j--);
					}
				}
			
			}
				
			int mincut = dgraph [vertexarray [0]].Count;
			Console.WriteLine ("The remaining vertices are {0}.adj = {1} and {2}.adj = {3}.", 
				vertexarray [0], dgraph [vertexarray [0]].Count, 
				vertexarray [1], dgraph [vertexarray [1]].Count);
			return mincut;
		}

	    static int Choose(List<int> vertexarray, Random rand, int startind = 0)
		{

			int ind = rand.Next(startind, vertexarray.Count);
			int vertex = vertexarray [ind];
		
			vertexarray.RemoveAt (ind); // Remove the choosing item

			return vertex;
		}
	}
}

