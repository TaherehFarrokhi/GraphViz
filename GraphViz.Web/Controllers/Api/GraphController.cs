using System.Web.Http;
using GraphViz.Core.Domain;
using GraphViz.Core.Repositories;

namespace GraphViz.Web.Controllers.Api
{
    public class GraphController : ApiController
    {
        private readonly IGraphRepository _repository;

        public GraphController(IGraphRepository repository)
        {
            _repository = repository;
        }

        public Graph Get()
        {
            return _repository.LoadGraph();
        }
    }
}
