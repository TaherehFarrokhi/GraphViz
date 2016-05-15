using System.Data.Entity;
using GraphViz.Core.Domain;
using GraphViz.Data.Mappings;

namespace GraphViz.Data.Context
{
    public class GraphVizContext : DbContext
    {
        public GraphVizContext(): base("Name=GraphVizContext")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.AddFromAssembly(typeof(GraphVizContext).Assembly);
        }
    }
}