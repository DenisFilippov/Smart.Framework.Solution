using System;
using System.Runtime.Serialization;
using Smart.Framework.Containers.Interfaces;

namespace Smart.Framework.Containers
{
  [Serializable]
  public class GraphItemAlreadyExistsException : Exception
  {
    public GraphItemAlreadyExistsException(IGraphBase item)
    {
      Item = item;
    }

    public GraphItemAlreadyExistsException(IGraphBase item, string message) : base(message)
    {
      Item = item;
    }

    public GraphItemAlreadyExistsException(IGraphBase item, string message, Exception inner) : base(message, inner)
    {
      Item = item;
    }

    protected GraphItemAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public IGraphBase Item { get; }
  }
}