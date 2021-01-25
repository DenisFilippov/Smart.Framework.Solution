namespace Smart.Framework.Containers.Interfaces
{
  public interface IGraphBase
  {
    IGraphBase Owner { get; set; }

    object Data { get; set; }
  }
}