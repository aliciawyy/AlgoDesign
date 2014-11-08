
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmDesign
{
	/// <summary>
	/// This class implement the Kosaraju's Algorithm to compute the Strongly Connected Components.
	/// </summary>
	/// <test>5105043 edges ~ 3200 ms</test>
	public class StronglyConnectedComponents
	{
		static List<bool> marked;
		static List<int>  finishtime;
		static List<int>  leader;
		static int  t;
		static int  s;

		// tail -> head
		public static void ComputeSCC(List<int> tail, List<int> head)
		{
			// Number of vertices, start from 0 to (nvertex - 1)
			int nvertex = Math.Max(tail.Max(), head.Max()) + 1;
			Console.WriteLine ("[Info]The whole graph contains {0} nodes.", nvertex);

			// Initialization
			marked = new List<bool>    ( new bool[nvertex] );
			finishtime = new List<int> ( new int [nvertex] );
			leader = new List<int>     ( new int [nvertex] );

			s = -1;

			// Get the Reverse Graph
			List<List<int> > RevGraph = ConvertEdgesToAdjGraph (head, tail, nvertex);

			DFSLoopNormal (RevGraph);

			// Set the exploring order by the inverse of the finishing time.
			List<int> theOrder = new List<int> ( new int[nvertex] );
			for (int i = 0; i < nvertex; ++i) {
				theOrder [finishtime [i]] = i;
			}

			// Get the normal Graph
			List<List<int> > dGraph = ConvertEdgesToAdjGraph (tail, head, nvertex);

			DFSLoopOrder (dGraph, theOrder);

			PrintCountResult (leader);
		}

		static void DFSLoopOrder ( List<List<int> > dgraph, List<int> theOrder )
		{
			t = 0;
			for ( int i = 0; i < dgraph.Count; ++i ) {
				marked [i] = false;
			}

			for (int i = dgraph.Count - 1; i >= 0; --i) {
				int ind = theOrder [i];
				if (!marked [ind]) {
					s = ind;
					DFS (dgraph, ind);
				}
			}
		}

		static void DFSLoopNormal(List<List<int> > dgraph)
		{
			t = 0;
			for ( int i = 0; i < dgraph.Count; ++i ) {
				marked [i] = false;
			}

			for (int i = dgraph.Count - 1; i >= 0; --i) {
				if (!marked [i]) { // if the node i not explored, search the node i
					s = i;
					DFS (dgraph, i);
				}
			}
		}

		static void DFS(List<List<int> > dgraph, int node)
		{
			marked [node] = true;
			for (int i = 0; i < dgraph [node].Count; ++i) {
				int ind = dgraph [node] [i];
				if ( !marked [ind] ) {
					DFS(dgraph, ind);
				}
			}
			finishtime [node] = t++;
			leader [node] = s;
		}

		//----------------------------------------------------------------------------------------------
		static void PrintCountResult (List<int> leader)
		{
			IDictionary<int, int> dic = new Dictionary<int, int> ();
			for ( int i = 0; i < leader.Count; ++i ) {
				int ind = leader [i];
				if (dic.ContainsKey (ind)) {
					dic [ind] += 1;
				} else {
					dic.Add (ind, 1);
				}
			}

			foreach (KeyValuePair<int, int> item in dic.OrderByDescending( n => n.Value ).Take(Math.Min(5, dic.Count))) {
				Console.WriteLine ("The SCC with the leader {0} contains {1} nodes.", item.Key, item.Value);
			}
		}

		//----------------------------------------------------------------------------------------------
		static List<List<int> > ConvertEdgesToAdjGraph(List<int> tail, List<int> head, int nvert)
		{
			// Initialization
			List<List<int> > v = new List<List<int>> ();
			for (int i = 0; i < nvert; ++i) {
				List<int> u = new List<int> ();
				v.Add (u);
			}

			for (int i = 0; i < tail.Count; ++i) {
				int ind = tail [i];
				v [ind].Add (head [i]);
			}

			return v;
		}
	}
}

