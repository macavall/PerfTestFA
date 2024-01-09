using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using PerfTestDLL;

namespace PerfTestDLLFA
{
    public class threads
    {
        private readonly ILogger _logger;
        private readonly IThreadClass threadClass;

        public threads(ILoggerFactory loggerFactory, IThreadClass _threadClass)
        {
            _logger = loggerFactory.CreateLogger<threads>();
            threadClass = _threadClass;
        }

        [Function("threads")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            threadClass.StartHighThreadCount();

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
