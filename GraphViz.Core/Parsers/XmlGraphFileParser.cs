using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using GraphViz.Core.Domain;
using GraphViz.Core.Loggers;

namespace GraphViz.Core.Parsers
{
    public class XmlGraphFileParser : IGraphFileParser
    {
        private const string SelectorNode = "node";
        private const string SelectorId = "id";
        private const string SelectorLabel = "label";
        private const string SelectorAdjacentNodes = "adjacentNodes";

        private readonly ILogger _logger;

        public XmlGraphFileParser(ILogger logger)
        {
            _logger = logger;
        }
        
        public GraphFile Parse(string filePath)
        {
            var element = XElement.Load(filePath);
            var nodeElement = element.DescendantsAndSelf(SelectorNode).FirstOrDefault();

            if (nodeElement == null)
            {
                _logger.Log("Invalid Xml format. Can't find Node");
                return null;
            }

            var id = GetIntValue(nodeElement.Element(SelectorId)?.Value);
            var name = nodeElement.Element(SelectorLabel)?.Value;
            if (!id.HasValue || string.IsNullOrWhiteSpace(name))
            {
                _logger.Log($"Invalid {SelectorId} or {SelectorLabel}");
                return null;
            }

            var node = new Node
            {
                Id = id.Value,
                Name = name
            };

            var edges = nodeElement.Element(SelectorAdjacentNodes)
                ?.Elements()
                .Select(m => new Edge
                {
                    SourceId = node.Id,
                    TargetId = GetIntValue(m?.Value) ?? -1
                }).Where(e => e.TargetId != -1).ToList();

            return new GraphFile {Node = node, Edges = edges ?? new List<Edge>() };
        }

        private int? GetIntValue(string strValue)
        {
            int intValue;
            if (int.TryParse(strValue, out intValue))
                return intValue;

            return null;
        }
    }
}