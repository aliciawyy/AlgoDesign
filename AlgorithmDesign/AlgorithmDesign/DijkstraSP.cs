using System;
using System.Collections.Generic;
using System.Linq;

using ConcurrentPriorityQueue;

namespace AlgorithmDesign
{
    public class Dijkstra
    {
        private readonly AdjacentGraph _adjacentGraph;

        public Dijkstra(List<List<int>> dgraph, List<List<int>> dedge)
        {
            _adjacentGraph = new AdjacentGraph(dgraph, dedge);
        }

        public Dijkstra(AdjacentGraph adjacentGraph)
        {
            _adjacentGraph = adjacentGraph;
        }

        public IEnumerable<int> ComputeShortestPaths(int source, IEnumerable<int> destinations)
        {
            IList<int> distancesToSource;
            var verticesHeap = InitializeVerticesHeapAndDistanceList(source, out distancesToSource);
            while (verticesHeap.Count > 0)
            {
                var minSourceVertex = verticesHeap.Dequeue();
                foreach (var neighborAndDistance in minSourceVertex.NeighborAndDistanceList)
                {
                    int neighbor = neighborAndDistance.Key;
                    // if neighbor is no longer in the heap, we don't need to do anything on
                    // it to add additional distance to the shortest distance achieved
                    if (verticesHeap.Contains(_adjacentGraph.Vertices[neighbor]))
                    {
                        int originalDist = distancesToSource[neighbor];
                        int potentialNewDist = distancesToSource[minSourceVertex.Id] + neighborAndDistance.Value;
                        if (potentialNewDist < originalDist)
                        {
                            distancesToSource[neighbor] = potentialNewDist;
                            verticesHeap.UpdatePriority(_adjacentGraph.Vertices[neighbor], potentialNewDist);
                        }
                    }
                }
            }
            return destinations.Select(dest => distancesToSource[dest]);
        }

        private ConcurrentPriorityQueue<Vertex, int> InitializeVerticesHeapAndDistanceList(int source, out IList<int> distancesToSource)
        {
            distancesToSource = new List<int>(_adjacentGraph.NbOfVertices);
            var verticesHeap = new ConcurrentPriorityQueue<Vertex, int>(new InverseComparer());
            for (int i = 0; i < _adjacentGraph.NbOfVertices; ++i)
            {
                if (source == i)
                {
                    distancesToSource.Add(0);
                    continue;
                }
                distancesToSource.Add(int.MaxValue);
                verticesHeap.Enqueue(_adjacentGraph.Vertices[i], int.MaxValue);
            }
            var sourceVertex = _adjacentGraph.Vertices[source];
            foreach (var neighborAndDistance in sourceVertex.NeighborAndDistanceList)
            {
                int neighbor = neighborAndDistance.Key;
                int distance = neighborAndDistance.Value;
                distancesToSource[neighbor] = distance;
                verticesHeap.UpdatePriority(_adjacentGraph.Vertices[neighbor], distance);
            }
            return verticesHeap;
        }

        // Inverse the priority
        public class InverseComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return y - x;
            }
        }
    }
}

