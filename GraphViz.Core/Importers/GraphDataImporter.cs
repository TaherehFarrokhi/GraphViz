using System;
using System.IO;
using System.Linq;
using GraphViz.Core.Extensions;
using GraphViz.Core.Parsers;
using GraphViz.Core.Repositories;

namespace GraphViz.Core.Importers
{
    public class GraphDataImporter : IGraphDataImporter
    {
        private readonly IGraphFileParser _graphFileParser;
        private readonly IGraphRepository _graphRepository;

        public GraphDataImporter(IGraphFileParser graphFileParser, IGraphRepository graphRepository)
        {
            _graphFileParser = graphFileParser;
            _graphRepository = graphRepository;
        }

        public void Import(string folder)
        {
            if (!Directory.Exists(folder))
                throw new Exception($"Folder {folder} doesn't exist.");

            var files = Directory.GetFiles(folder, "*.xml");
            var graphFiles = files.Select(file => _graphFileParser.Parse(file))
                .Where(parsedGraph => parsedGraph != null)
                .ToList();

            
            // Validate the graph data 
            var graph = graphFiles.ToGraph();

            // Save to database
            _graphRepository.SaveGraph(graph);
        }
    }
}