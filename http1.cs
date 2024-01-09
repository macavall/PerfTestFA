using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using PerfTestDLL;

namespace PerfTestDLLFA
{
    public class http1
    {
        private readonly ILogger _logger;
        private readonly IServiceUpdater serviceUpdater;


        public http1(ILoggerFactory loggerFactory, IServiceUpdater serviceUpdater)
        {
            _logger = loggerFactory.CreateLogger<http1>();
            this.serviceUpdater = serviceUpdater;
        }

        [Function("http1")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            serviceUpdater.StartHttpSender();

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
