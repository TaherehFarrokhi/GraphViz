using GraphViz.Core.Domain;

namespace GraphViz.Core.Services
{
    public interface IGraphDataService
    {
        void Save(Graph graph);
    }
}