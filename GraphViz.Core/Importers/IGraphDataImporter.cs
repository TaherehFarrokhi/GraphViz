using GraphViz.Core.Domain;

namespace GraphViz.Core.Importers
{
    public interface IGraphDataImporter
    {
        void Import(string folder);
    }
}