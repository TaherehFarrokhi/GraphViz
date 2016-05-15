using System.Collections.Generic;

namespace GraphViz.Core.Domain
{
    public class GraphFile
    {
        public Node Node { get; set; }
        public List<Edge> Edges { get; set; }
    }
}