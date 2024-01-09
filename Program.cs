using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

internal class Program
{
    private static void Main(string[] args)
    {

        // TEST TEST TEST
        var host = new HostBuilder()
        .ConfigureFunctionsWorkerDefaults()
        .ConfigureServices(services =>
        {
            services.AddApplicationInsightsTelemetryWorkerService();
            services.ConfigureFunctionsApplicationInsights();
        })
        .Build();

        host.Run();
    }
}