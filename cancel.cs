using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace PerfTestDLLFA
{
    public class cancel
    {
        private readonly ILogger _logger;
        private readonly IServiceUpdater serviceUpdater;

        public cancel(ILoggerFactory loggerFactory, IServiceUpdater _serviceUpdater)
        {
            _logger = loggerFactory.CreateLogger<cancel>();
            this.serviceUpdater = _serviceUpdater;
        }

        [Function("cancel")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            serviceUpdater.CancelHttpSender();

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
