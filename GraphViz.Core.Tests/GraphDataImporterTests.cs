using System.Linq;
using GraphViz.Core.Domain;
using GraphViz.Core.Importers;
using GraphViz.Core.Loggers;
using GraphViz.Core.Parsers;
using GraphViz.Core.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace GraphViz.Core.Tests
{
    [TestClass]
    public class GraphDataImporterTests
    {
        [TestMethod]
        public void Suscees_when_import_files_are_correct()
        {
            // Given
            var logger = Substitute.For<ILogger>();
            var repository = Substitute.For<IGraphRepository>();

            var fileParser = new XmlGraphFileParser(logger);

            var importer = new GraphDataImporter(fileParser, repository);
            var folder = @"importer-Inputs";

            // When
            importer.Import(folder);

            // Then
            repository.Received().SaveGraph(Arg.Is<Graph>(m =>
                m != null &&
                m.Nodes.Count == 2 &&
                m.Edges.Count == 1 &&
                m.Nodes.Any(x => x.Name == "Amazon" && x.Id == 9) &&
                m.Nodes.Any(x => x.Name == "Apple" && x.Id == 10) &&
                m.Edges.Any(x => x.SourceId == 9 && x.TargetId == 10)
                ));
        }
    }
}