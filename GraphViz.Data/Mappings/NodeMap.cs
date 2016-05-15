using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using GraphViz.Core.Domain;

namespace GraphViz.Data.Mappings
{
    public class NodeMap : EntityTypeConfiguration<Node>
    {
        public NodeMap()
        {
            ToTable("Node");

            HasKey(m => m.Id);

            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}