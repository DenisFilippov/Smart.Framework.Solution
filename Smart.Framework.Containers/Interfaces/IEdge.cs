namespace Smart.Framework.Containers.Interfaces
{
  public interface IEdge : IGraphBase
  {
    IVertex Vertex1 { get; }

    IVertex Vertex2 { get; }
  }
}