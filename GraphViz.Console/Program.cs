using Autofac;
using GraphViz.Core.Importers;
using GraphViz.Core.Parsers;
using GraphViz.Data;

namespace GraphViz.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = CreateContainer();
            var folder = @"C:\_git.tahereh\GraphViz\Inputs";

            var importer = container.Resolve<IGraphDataImporter>();
            importer.Import(folder);
        }

        private static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(typeof (GraphRepository).Assembly, typeof (XmlGraphFileParser).Assembly)
                .Where(d => d.Name.EndsWith("Logger") || 
                            d.Name.EndsWith("Repository") || 
                            d.Name.EndsWith("Importer") || 
                            d.Name.EndsWith("Parser"))
                .AsImplementedInterfaces().SingleInstance();

            var container = builder.Build();
            return container;
        }
    }
}
