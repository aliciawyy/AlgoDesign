using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmDesign
{
    public class KargerMinCut
    {
        public static int GetMininumulCuts(List<List<int>> rawGraph, int nbOfTries)
        {
            var result = new List<int>();
            for (int i = 0; i < nbOfTries; ++i)
            {
                result.Add(CountCrossingEdges(rawGraph, i));
            }
            return result.Min();
        }

        public static int CountCrossingEdges(List<List<int>> rawGraph, int randomSeed)
        {
            var origGraph = new ConnectedGraph(rawGraph);
            var graph = origGraph.DeepClone();

            var allVertices = new List<int> ();
            for (int i = 0; i < graph.NbOfVertices; ++i) // Populate the vertex list
                allVertices.Add(i);

            Random random = new Random (randomSeed);
            while (allVertices.Count > 2)
            {
                int vertexToRemove = PickAndRemoveVertex(allVertices, random);
                var neighborsOfVertexToRemove = new List<int>(graph.GetNeighborsOf(vertexToRemove));
                if (neighborsOfVertexToRemove.Count == 0) continue;
                int vertexCandidate = PickVertex(neighborsOfVertexToRemove, random);
                // For undirected graph, here we suppose that all the neighbors of X also have X as neighbor
                neighborsOfVertexToRemove.ForEach(
                    vertex => graph.ReplaceANeighborIfHas(vertex, vertexToRemove, vertexCandidate)
                    );
                graph.GetNeighborsOf(vertexCandidate).AddRange(neighborsOfVertexToRemove);
                graph.RemoveSelfCirclesOf(vertexCandidate);
                graph.ClearNeighborsOf(vertexToRemove);   
            }
            int mincut = graph.GetNeighborsOf(allVertices[0]).Count;
            return mincut;
        }

        static int PickAndRemoveVertex(IList<int> vertices, Random random)
        {
            int index = random.Next(0, vertices.Count);
            int value = vertices[index];
            vertices.RemoveAt(index);
            return value;
        }

        static int PickVertex(IList<int> vertices, Random random)
        {
            int index = random.Next(0, vertices.Count);
            return vertices[index];
        }
    }
}