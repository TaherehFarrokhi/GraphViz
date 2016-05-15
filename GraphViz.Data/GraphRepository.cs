using System.Linq;
using GraphViz.Core.Domain;
using GraphViz.Core.Repositories;
using GraphViz.Data.Context;

namespace GraphViz.Data
{
    public class GraphRepository : IGraphRepository
    {
        public void SaveGraph(Graph graph)
        {
            using (var context = new GraphVizContext())
            {
                //Remove all previous records
                context.Database.ExecuteSqlCommand("DELETE FROM Edge");
                context.Database.ExecuteSqlCommand("DELETE FROM Node");
                context.SaveChanges();

                //Add all nodes and edges
                context.Set<Node>().AddRange(graph.Nodes);
                context.SaveChanges();

                context.Set<Edge>().AddRange(graph.Edges);
                context.SaveChanges();
            }
        }

        public Graph LoadGraph()
        {
            using (var context = new GraphVizContext())
            {
                var nodes = context.Set<Node>().ToList();
                var edges = context.Set<Edge>().ToList();

                return new Graph { Nodes = nodes, Edges = edges };
            }
        }
    }
}
