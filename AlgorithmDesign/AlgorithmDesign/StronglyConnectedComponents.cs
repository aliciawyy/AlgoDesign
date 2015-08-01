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
		public static void ComputeSCCAPI(List<int> tail, List<int> head)
		{
			// Number of vertices, start from 0 to (nvertex - 1)
			int nvertex = Math.Max(tail.Max(), head.Max()) + 1;
			Console.WriteLine ("[Info]The whole graph contains {0} nodes.", nvertex);

			List<List<int>> ReverseGraph = new List<List<int>> ();
			List<List<int>> NormalGraph = new List<List<int>> ();

			ReadFile.ConvertAllEdgesToAdjacentList (head, tail, nvertex, ReverseGraph);
			ReadFile.ConvertAllEdgesToAdjacentList (tail, head, nvertex, NormalGraph);

			ComputeSCC (NormalGraph, ReverseGraph);
		}
			
		public static void ComputeSCC(List<List<int>> NormalGraph, List<List<int>> ReverseGraph)
		{
			// Initialization
			int nvertex = NormalGraph.Count;

			marked = new List<bool>    ( new bool[nvertex] );
			finishtime = new List<int> ( new int [nvertex] );
			leader = new List<int>     ( new int [nvertex] );

			s = -1;

			//--------------------------------------
			DFSLoop (ReverseGraph);

			// Set the exploring order by the inverse of the finishing time.
			List<int> theOrder = new List<int> ( new int[nvertex] );
			for (int i = 0; i < nvertex; ++i) {
				theOrder [finishtime [i]] = i;
			}

			//--------------------------------------
			DFSLoopOrder (NormalGraph, theOrder);

			PrintCountResult (leader);
		}

		// Read from theReverseOrder[Count - 1] to theReverseOrder[0]
		static void DFSLoopOrder ( List<List<int> > dgraph, List<int> theReverseOrder )
		{
			t = 0;
			for ( int i = 0; i < dgraph.Count; ++i ) {
				marked [i] = false;
			}

			for (int i = dgraph.Count - 1; i >= 0; --i) {
				int ind = theReverseOrder [i];
				if (!marked [ind]) {
					s = ind;
					DFS (dgraph, ind);
				}
			}
		}

		static void DFSLoop(List<List<int> > dgraph)
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
	}
}

