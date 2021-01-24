using System;
using System.Runtime.Serialization;

namespace Smart.Framework.Core
{
  [Serializable]
  public class SmartPropertyException : Exception
  {
    public SmartPropertyException()
    {
    }

    public SmartPropertyException(string message) : base(message)
    {
    }

    public SmartPropertyException(string message, Exception inner) : base(message, inner)
    {
    }

    protected SmartPropertyException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
  }
}