using System;
using System.Collections.Generic;

namespace AlgorithmDesign
{
    // Adjacent graph with directions
    class AdjacentGraph
    {
        private readonly List<Vertex> _vertices;

        // The list position i == Vertex.Id
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

        private readonly IDictionary<int, int> _neighborAndDistance;
        public IDictionary<int, int> NeighborAndDistance { get { return _neighborAndDistance; } }

        public Vertex(int id, IList<int> neighborList, IList<int> distanceList)
        {
            _id = id;
            if (neighborList.Count != distanceList.Count)
            {
                throw new ArgumentException(
                    $"The number of neighbors '{neighborList.Count}' doesn't match that of distanceList " +
                    $"'{distanceList.Count}' for the vertex '{id}'.");
            }
            _neighborAndDistance = new Dictionary<int, int>();
            for (int i = 0; i < neighborList.Count; ++i)
            {
                _neighborAndDistance.Add(neighborList[i], distanceList[i]);
            }
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var otherVertex = obj as Vertex;
            if (otherVertex == null)
            {
                throw new ArgumentNullException("The object is of type " + obj.GetType());
            }
            return _id == otherVertex.Id;
        }
    }
}
