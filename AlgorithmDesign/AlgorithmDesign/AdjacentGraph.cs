using System;
using System.Collections.Generic;

namespace AlgorithmDesign
{
    class AdjacentGraph
    {
        private readonly List<Vertex> _vertices;
        public List<Vertex> Vertices { get { return _vertices; } }

        public int NbOfVertices => _vertices.Count;

        public AdjacentGraph(List<List<int>> dgraph, List<List<int>> dedge)
        {
            if (dgraph.Count != dedge.Count)
            {
                throw new ArgumentException(
                    $"The number of vertices '{dgraph.Count}' in the graph doesn't match that of edges '{dedge.Count}.'");
            }
            _vertices = new List<Vertex>();
            for (int i = 0; i < dgraph.Count; ++i)
            {
                _vertices.Add(new Vertex(i, dgraph[i], dedge[i]));
            }
        }
    }

    class Vertex
    {
        private readonly int _id;
        public int Id => _id;

        private readonly List<Tuple<int, int>> _neighborAndDistance;
        public List<Tuple<int, int>> NeighborAndDistance { get { return _neighborAndDistance; } }

        public Vertex(int id, IList<int> neighborList, IList<int> distanceList)
        {
            _id = id;
            if (neighborList.Count != distanceList.Count)
            {
                throw new ArgumentException(
                    $"The number of neighbors '{neighborList.Count}' doesn't match that of distanceList " +
                    $"'{distanceList.Count}' for the vertex '{id}'.");
            }
            _neighborAndDistance = new List<Tuple<int, int>>();
            for (int i = 0; i < neighborList.Count; ++i)
            {
                _neighborAndDistance.Add(new Tuple<int, int>(neighborList[i], distanceList[i]));
            }
        }
    }
}
