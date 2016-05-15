using System.Collections.Generic;

namespace GraphViz.Core.Domain
{
    public class Graph
    {
        public Graph()
        {
            Nodes = new List<Node>();
            Edges = new List<Edge>();
        }

        public List<Node> Nodes { get; set; }
        public List<Edge> Edges { get; set; }
    }
}