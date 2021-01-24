using System;
using System.Runtime.Serialization;
using Smart.Framework.Containers.Interfaces;

namespace Smart.Framework.Containers
{
  [Serializable]
  public class GraphItemNotExistsException : Exception
  {
    public GraphItemNotExistsException(IGraphBase item)
    {
      Item = item;
    }

    public GraphItemNotExistsException(IGraphBase item, string message) : base(message)
    {
      Item = item;
    }

    public GraphItemNotExistsException(IGraphBase item, string message, Exception inner) : base(message, inner)
    {
      Item = item;
    }

    protected GraphItemNotExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public IGraphBase Item { get; }
  }
}