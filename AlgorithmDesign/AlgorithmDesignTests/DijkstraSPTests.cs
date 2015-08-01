using System.Collections.Generic;
using System.Linq;
using AlgorithmDesign;
using NUnit.Framework;

namespace AlgorithmDesignTests
{
    public class DijkstraTests
    {
        [Test]
        public void ComputeShortestPaths_largeDataSet()
        {
            var filename = "dijkstraData.txt";
            int source = 0;
            var destinations = new[] { 7, 37, 59, 82, 99, 115, 133, 165, 188, 197 };
            destinations = destinations.Select(p => p - 1).ToArray();
            var expectedResult = new[] { 2599, 2610, 2947, 2052, 2367, 2399, 2029, 2442, 2505, 3068 };

            List<List<int>> graphList;
            List<List<int>> edgeList;
            ReadTestFile.ReadAdjacentListWithEdges(filename, out graphList, out edgeList);
            var dijkstra = new Dijkstra(graphList, edgeList);
            var result = dijkstra.ComputeShortestPaths(source, destinations).ToArray();
            Assert.AreEqual(expectedResult.Length, result.Length);
            for (int i = 0; i < result.Length; ++i)
            {
                Assert.AreEqual(expectedResult[i], result[i]);
            }
        }
    }
}
