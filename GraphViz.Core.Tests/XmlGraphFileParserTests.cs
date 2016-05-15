using System;
using GraphViz.Core.Loggers;
using GraphViz.Core.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace GraphViz.Core.Tests
{
    [TestClass]
    public class XmlGraphFileParserTests
    {
        [TestMethod]
        public void Success_when_parsing_a_proper_file()
        {
            // Given
            var logger = Substitute.For<ILogger>();
            var parser = new XmlGraphFileParser(logger);
            var filePath = @"inputs\success.xml";

            // When
            var graphFile = parser.Parse(filePath);

            // Then
            Assert.IsNotNull(graphFile);
            Assert.IsNotNull(graphFile.Node);
            Assert.IsNotNull(graphFile.Edges);

            Assert.AreEqual(9, graphFile.Node.Id);
            Assert.AreEqual("Amazon", graphFile.Node.Name);

            Assert.AreEqual(1, graphFile.Edges.Count);
            Assert.AreEqual(9, graphFile.Edges[0].SourceId);
            Assert.AreEqual(10, graphFile.Edges[0].TargetId);
        }

        [TestMethod]
        public void Success_when_parsing_a_file_with_invalid_node()
        {
            // Given
            var logger = Substitute.For<ILogger>();
            var parser = new XmlGraphFileParser(logger);
            var filePath = @"inputs\Error-No-Node.xml";

            // When
            var graphFile = parser.Parse(filePath);

            // Then
            Assert.IsNull(graphFile);
            logger.Received().Log(Arg.Any<string>());
        }

    }
}
