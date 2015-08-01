using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmDesign
{
    /// <summary>
    /// ConnectedGraph stores a directioned or undirected graph without the edges lengths.
    /// </summary>
    public class ConnectedGraph
    {
        private List<List<int>> _vertexNeighborList;

        public List<List<int>> VertexNeighborList => _vertexNeighborList;
        public int NbOfVertices => _vertexNeighborList.Count;
        

        public ConnectedGraph(List<List<int>> vertexNeighborList)
        {
            _vertexNeighborList = vertexNeighborList.ToList();
        } 

        public ConnectedGraph DeepClone()
        {
            var newGraph = _vertexNeighborList.Select(p => p.ToList()).ToList();
            return new ConnectedGraph(newGraph);
        }

        public bool IsVertexHasNeighbor(int vertex, int neighbor) => _vertexNeighborList[vertex].Contains(neighbor);

        public List<int> GetNeighborsOf(int vertexId) => _vertexNeighborList[vertexId];

        public void ClearNeighborsOf(int vertex)
        {
            _vertexNeighborList[vertex].Clear();
        }

        public void RemoveAndReplaceANeighborIfHas(int vertex, int neighborInQuestion, int candidate)
        {
            var allNeighbors = _vertexNeighborList[vertex];
            if (allNeighbors.Contains(neighborInQuestion))
            {
                allNeighbors.Remove(neighborInQuestion);
                allNeighbors.Add(candidate);
            }
        }

        public void RemoveSelfCirclesOf(int vertex)
        {
            _vertexNeighborList[vertex].RemoveAll(vertex.Equals);
        }

        public override string ToString()
        {
            var vertices = _vertexNeighborList.Select(p => string.Join(", ", p)).ToList();
            var result = string.Empty;
            for (int i = 0; i < vertices.Count; ++i)
                result += $"Vertex Id {i} has neighbors {vertices[i]}\n";
            return result;
        }
    }
}
