using System.IO;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Sqit.ApiGateway.Aggregators;

namespace Sqit.ApiGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new WebHostBuilder()
                .UseKestrel(options =>
                {
                    options.ListenLocalhost(3000);
                })
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config
                        .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                        .AddJsonFile("appsettings.json", true, true)
                        .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
                        .AddJsonFile("ocelot.json")
                        .AddEnvironmentVariables();
                })
                .ConfigureServices(s => {
                    s.AddOcelot()
                     .AddTransientDefinedAggregator<CustomerWithOrdersAggregator>();
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    //add your logging
                })
                .UseIISIntegration()
                .Configure(app =>
                {
                    app.UseOcelot().Wait();
                })
                .Build()
                .Run();

        }
    }
}