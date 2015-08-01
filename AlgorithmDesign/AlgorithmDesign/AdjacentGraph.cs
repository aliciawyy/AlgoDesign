using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmDesign
{
    /// <summary>
    /// AdjacentGraph stores a directional graph with length of edges.
    /// </summary>
    public class AdjacentGraph
    {
        // The list position i == Vertex.Id
        private readonly List<Vertex> _vertices;
        public List<Vertex> Vertices => _vertices;
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

        public IEnumerable<int> DijkstraShortestPaths(int source, IEnumerable<int> destinations)
        {
            var dijkstra = new Dijkstra(this);
            return dijkstra.ComputeShortestPaths(source, destinations);
        }

        public override string ToString()
        {
            return string.Join("\n", _vertices);
        }
    }

    public class Vertex
    {
        private readonly int _id;
        public int Id => _id;

        private readonly IDictionary<int, int> _neighborAndDistanceList;
        public IDictionary<int, int> NeighborAndDistanceList => _neighborAndDistanceList;

        public Vertex(int id, IList<int> neighborList, IList<int> distanceList)
        {
            _id = id;
            if (neighborList.Count != distanceList.Count)
            {
                throw new ArgumentException(
                    $"The number of neighbors '{neighborList.Count}' doesn't match that of distanceList " +
                    $"'{distanceList.Count}' for the vertex '{id}'.");
            }
            _neighborAndDistanceList = new Dictionary<int, int>();
            for (int i = 0; i < neighborList.Count; ++i)
            {
                _neighborAndDistanceList.Add(neighborList[i], distanceList[i]);
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

        public override string ToString()
        {
            var result = $"Vertex Id is {_id} with neighbors and corresponding distances ";
            result += string.Join("; ", _neighborAndDistanceList.Select(p => $"{p.Key}, {p.Value}"));
            return result;
        }
    }
}
