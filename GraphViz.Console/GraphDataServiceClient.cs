using System;
using System.Net.Http;
using System.Text;
using GraphViz.Core.Domain;
using GraphViz.Core.Services;
using Newtonsoft.Json;

namespace GraphViz.Console
{
    public class GraphDataServiceClient : IGraphDataService
    {
        private readonly string _url;

        public GraphDataServiceClient(string url)
        {
            _url = url;
        }

        public void Save(Graph graph)
        {
            if (graph == null) throw new ArgumentNullException(nameof(graph));

            using (var httpClient = new HttpClient())
            {
                var content = JsonConvert.SerializeObject(graph);
                var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

                var result = httpClient.PostAsync(_url, stringContent).Result;
            }
        }
    }
}