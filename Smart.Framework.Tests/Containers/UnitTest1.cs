using System.Linq;
using NUnit.Framework;
using Smart.Framework.Containers;
using Smart.Framework.Containers.Interfaces;

namespace Smart.Framework.Tests.Containers
{
  public class Tests
  {
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CreateVertexTest()
    {
      IVertex vertex = new Vertex();
      Assert.IsTrue(vertex.Data == null, "Vertex property Data must be null by default.");
      Assert.IsTrue(vertex.Owner == null, "Vertex property Owner must be null by default.");
      Assert.Pass();
    }

    [Test]
    public void CreateGraphTest()
    {
      IVertex vertex1 = new Vertex();
      IVertex vertex2 = new Vertex();
      IGraph graph = new Graph();
      graph.AddVertex(vertex1);
      graph.AddVertex(vertex2);
      Assert.IsTrue(vertex1.Owner == graph, "Vertex property must be not null.");
      Assert.IsTrue(vertex2.Owner == graph, "Vertex property must be not null.");
      var edge = graph.Connect(vertex1, vertex2);
      Assert.IsTrue(graph.Vertexes.Count() == 2, "Vertex count must be 2.");
      Assert.IsTrue(graph.Edges.Count() == 1, "Edge count must be 1.");
      Assert.IsTrue(graph.Disconnect(edge), "Disconnection error.");
      Assert.IsTrue(!graph.Edges.Any(), "Edge count must be 0.");
      graph.RemoveVertex(vertex1);
      graph.RemoveVertex(vertex2);
      Assert.IsTrue(!graph.Vertexes.Any(), "Vertex count must be 0.");
      Assert.IsTrue(vertex1.Owner == null, "Vertex property must be null.");
      Assert.IsTrue(vertex2.Owner == null, "Vertex property must be null.");
      Assert.Pass();
    }
  }
}