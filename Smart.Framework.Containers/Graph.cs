using System;
using System.Collections.Generic;
using System.Linq;
using Smart.Framework.Containers.Interfaces;

namespace Smart.Framework.Containers
{
  public class Graph : IGraph
  {
    private readonly List<IEdge> _edgeList = new();
    private readonly List<IVertex> _vertexList = new();

    public void AddVertex(IVertex vertex)
    {
      if (vertex == null) throw new ArgumentNullException(nameof(vertex));

      if (vertex.Owner == this) throw new GraphItemAlreadyExistsException(vertex);

      _vertexList.Add(vertex);
      vertex.Owner = this;
    }

    public void RemoveVertex(IVertex vertex)
    {
      bool EdgeContainsVertexPredicate(IEdge edge)
      {
        return edge.Vertex1 == vertex || edge.Vertex2 == vertex;
      }

      if (vertex == null)
        throw new ArgumentNullException(nameof(vertex));

      if (vertex.Owner != this) throw new GraphItemNotExistsException(vertex);

      if (_vertexList.Remove(vertex))
      {
        foreach (var edge in _edgeList.Where(EdgeContainsVertexPredicate)) edge.Owner = null;
        _edgeList.RemoveAll(EdgeContainsVertexPredicate);
        vertex.Owner = null;
      }
    }

    public IEdge Connect(IVertex vertex1, IVertex vertex2)
    {
      if (vertex1 == null)
        throw new ArgumentNullException(nameof(vertex1));
      if (vertex2 == null)
        throw new ArgumentNullException(nameof(vertex2));

      var result = new Edge(vertex1, vertex2);
      _edgeList.Add(result);
      result.Owner = this;
      return result;
    }

    public int DisconnectAll(IVertex vertex1, IVertex vertex2)
    {
      bool EdgeConnectedVertexesPredicate(IEdge edge)
      {
        return edge.Vertex1 == vertex1 && edge.Vertex2 == vertex2 || edge.Vertex1 == vertex2 && edge.Vertex2 == vertex1;
      }

      if (vertex1 == null)
        throw new ArgumentNullException(nameof(vertex1));
      if (vertex2 == null)
        throw new ArgumentNullException(nameof(vertex2));
      if (vertex1.Owner != this)
        throw new GraphItemNotExistsException(vertex1);
      if (vertex2.Owner != this)
        throw new GraphItemNotExistsException(vertex2);

      return _edgeList.RemoveAll(EdgeConnectedVertexesPredicate);
    }

    public bool Disconnect(IEdge edge)
    {
      if (edge == null)
        throw new ArgumentNullException(nameof(edge));
      if (edge.Owner != this)
        throw new GraphItemNotExistsException(edge);

      var result = _edgeList.Remove(edge);
      if (result)
        edge.Owner = null;

      return result;
    }

    public IEnumerable<IVertex> Vertexes => _vertexList;

    public IEnumerable<IEdge> Edges => _edgeList;

    public IGraphBase Owner { get; set; }
  }
}