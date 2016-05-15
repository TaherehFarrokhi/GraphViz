using System;
using System.IO;
using System.Linq;
using GraphViz.Core.Extensions;
using GraphViz.Core.Loggers;
using GraphViz.Core.Parsers;
using GraphViz.Core.Services;

namespace GraphViz.Core.Importers
{
    public class GraphDataImporter : IGraphDataImporter
    {
        private readonly IGraphFileParser _graphFileParser;
        private readonly IGraphDataService _graphDataService;
        private readonly ILogger _logger;

        public GraphDataImporter(IGraphFileParser graphFileParser, 
                                 IGraphDataService graphDataService, 
                                 ILogger logger)
        {
            _graphFileParser = graphFileParser;
            _graphDataService = graphDataService;
            _logger = logger;
        }

        public void Import(string folder)
        {
            try
            {
                _logger.Log("Import has started");
                if (!Directory.Exists(folder))
                    throw new Exception($"Folder {folder} doesn't exist.");

                _logger.Log("Read the list of the files to import");
                var files = Directory.GetFiles(folder, "*.xml");
                var graphFiles = files.Select(file => _graphFileParser.Parse(file))
                    .Where(parsedGraph => parsedGraph != null)
                    .ToList();

                _logger.Log("Aggregate the files to a single graph");

                // Aggregate the graph data 
                var graph = graphFiles.ToGraph();

                _logger.Log("Graph sent to related service to persist");

                _graphDataService.Save(graph);

                _logger.Log("Import successfully saved");
            }
            catch (Exception e)
            {
                _logger.Log($"Import failed due to error: {e.Message}", LogLevel.Error);
            }
        }
    }
}