using System.Collections.Generic;
using System.Linq;
using GraphViz.Core.Domain;

namespace GraphViz.Core.Extensions
{
    public static class GraphFileExtensions
    {
        public static Graph ToGraph(this List<GraphFile> graphFiles)
        {
            return new Graph
            {
                Nodes = graphFiles.Select(g => g.Node)
                                  .Distinct(Node.IdComparer)
                                  .OrderBy(m => m.Id)
                                  .ToList(),
                Edges = graphFiles.SelectMany(g => g.Edges)
                                  .Distinct(Edge.SourceIdTargetIdComparer)
                                  .OrderBy(e => e.SourceId).ThenBy(e => e.TargetId)
                                  .ToList()
            };
        }
    }
}