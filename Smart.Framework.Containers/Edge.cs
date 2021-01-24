using System;
using Smart.Framework.Containers.Interfaces;

namespace Smart.Framework.Containers
{
  public class Edge : IEdge
  {
    public Edge(IVertex vertex1, IVertex vertex2)
    {
      Vertex1 = vertex1 ?? throw new ArgumentNullException(nameof(vertex1));
      Vertex2 = vertex2 ?? throw new ArgumentNullException(nameof(vertex2));
    }

    public IVertex Vertex1 { get; }

    public IVertex Vertex2 { get; }

    public IGraphBase Owner { get; set; }
  }
}