using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PerfTestDLL;

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
            services.AddHttpClient();
            //services.AddSingleton<IPerfClass, PerfClass>();
            services.AddSingleton<IServiceUpdater, ServiceUpdater>();
            services.AddSingleton<IThreadClass, ThreadClass>();
        })
        .Build();

        host.Run();
    }
}