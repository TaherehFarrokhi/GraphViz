using GraphViz.Core.Domain;

namespace GraphViz.Core.Parsers
{
    public interface IGraphFileParser
    {
        GraphFile Parse(string filePath);
    }
}