

using GraphViz.Core.Domain;

namespace GraphViz.Core.Repositories
{
    public interface IGraphRepository
    {
        void SaveGraph(Graph graph);
        Graph LoadGraph();
    }
}
