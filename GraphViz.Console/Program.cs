using System.Configuration;
using Autofac;
using GraphViz.Console.Loggers;
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
            var folder = ConfigurationManager.AppSettings["ImportFolder"];

            var importer = container.Resolve<IGraphDataImporter>();
            importer.Import(folder);

            System.Console.ReadKey();
        }

        private static IContainer CreateContainer()
        {
            var url = ConfigurationManager.AppSettings["GraphServiceUrl"];

            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(typeof (GraphRepository).Assembly, 
                                          typeof (XmlGraphFileParser).Assembly,
                                          typeof (ConsoleLogger).Assembly)
                .Where(d => d.Name.EndsWith("Logger") || 
                            d.Name.EndsWith("Repository") || 
                            d.Name.EndsWith("Importer") || 
                            d.Name.EndsWith("Parser"))
                .AsImplementedInterfaces().SingleInstance();

            builder.RegisterType<GraphDataServiceClient>()
                .AsImplementedInterfaces()
                .WithParameter("url", url)
                .SingleInstance();

            var container = builder.Build();
            return container;
        }
    }
}
