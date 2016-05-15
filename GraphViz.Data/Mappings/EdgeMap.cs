using System.Data.Entity.ModelConfiguration;
using GraphViz.Core.Domain;

namespace GraphViz.Data.Mappings
{
    public class EdgeMap : EntityTypeConfiguration<Edge>
    {
        public EdgeMap()
        {
            ToTable("Edge");

            HasKey(m => new {m.SourceId, m.TargetId});
        }
    }
}