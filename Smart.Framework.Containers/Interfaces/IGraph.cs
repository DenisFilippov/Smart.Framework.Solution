using System.Collections.Generic;

namespace Smart.Framework.Containers.Interfaces
{
  public interface IGraph : IGraphBase
  {
    IEnumerable<IVertex> Vertexes { get; }

    IEnumerable<IEdge> Edges { get; }

    void AddVertex(IVertex vertex);

    void RemoveVertex(IVertex vertex);

    IEdge Connect(IVertex vertex1, IVertex vertex2);

    int DisconnectAll(IVertex vertex1, IVertex vertex2);

    bool Disconnect(IEdge edge);
  }
}