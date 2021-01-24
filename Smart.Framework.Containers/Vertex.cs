using Smart.Framework.Containers.Interfaces;

namespace Smart.Framework.Containers
{
  public class Vertex : IVertex
  {
    public IGraphBase Owner { get; set; }
  }
}