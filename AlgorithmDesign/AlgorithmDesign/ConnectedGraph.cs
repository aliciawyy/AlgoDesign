using System.Collections.Generic;
using System.Linq;

namespace AlgorithmDesign
{
    /// <summary>
    /// ConnectedGraph stores a directional graph without the edges lengths.
    /// </summary>
    public class ConnectedGraph
    {
        private readonly List<List<int>> _vertexNeighborList;

        public int NbOfVertices => _vertexNeighborList.Count;

        public ConnectedGraph(List<List<int>> vertexNeighborList)
        {
            _vertexNeighborList = vertexNeighborList.ToList();
        }
    }
}
