using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using GraphViz.Core.Parsers;
using GraphViz.Data;

namespace GraphViz.Web
{
    public static class ContainerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(typeof (ContainerConfig).Assembly);

            builder.RegisterAssemblyTypes(typeof(GraphRepository).Assembly, typeof(XmlGraphFileParser).Assembly)
                .Where(d => d.Name.EndsWith("Logger") ||
                            d.Name.EndsWith("Repository") ||
                            d.Name.EndsWith("Importer") ||
                            d.Name.EndsWith("Parser"))
                .AsImplementedInterfaces().SingleInstance();

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}