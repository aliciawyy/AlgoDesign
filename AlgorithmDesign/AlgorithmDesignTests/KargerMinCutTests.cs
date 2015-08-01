using System;
using System.Collections.Generic;
using System.Linq;
using AlgorithmDesign;
using NUnit.Framework;

namespace AlgorithmDesignTests
{
    public class KargerMinCutTests
    {
        [Test]
        public void FindKargerMinCut_MinimumNbCorrect()
        {
            string filename = "kargerMinCut.txt";
            const int expectedMinCuts = 17;
            List<List<int>> data = ReadTestFile.ReadAdjacentList(filename);
            int result = KargerMinCut.GetMininumulCuts(data, data.Count);
            Assert.AreEqual(expectedMinCuts, result);
        }
    }

    public class ConnectedGraphTests
    {
        [Test]
        public void DeepClone_NoImpactOnClonedObj()
        {
            var originalGraph = new List<List<int>>();
            const int N = 4;
            for (int i = 0; i < N; ++i)
                originalGraph.Add(new List<int> {1, 2});
            var orig = new ConnectedGraph(originalGraph);
            var cloned = orig.DeepClone();
            cloned.VertexNeighborList[1][1] = 3;
            cloned.VertexNeighborList.RemoveAt(2);
            Assert.AreEqual(2, orig.VertexNeighborList[1][1]);
            Console.WriteLine("Orig\n" + orig +"\nCloned\n"+ cloned);
        }

        [Test]
        public void RemoveAndReplaceANeighborIfHas_AsExpected()
        {
            var rawGraph = new List<List<int>>
            {
                new List<int> {1},
                new List<int> {2},
                new List<int> {1},
                new List<int> {0, 2}
            };
            var graph = new ConnectedGraph(rawGraph);
            Console.WriteLine(graph);
            int theVertex = 0;
            int vertexInQuestion = 1;
            int candidate = 2;
            graph.RemoveAndReplaceANeighborIfHas(theVertex, vertexInQuestion, candidate);
            Assert.False(graph.IsVertexHasNeighbor(theVertex, vertexInQuestion));
            Assert.True(graph.IsVertexHasNeighbor(theVertex, candidate));
            Console.WriteLine(graph);
        }
    }
}
