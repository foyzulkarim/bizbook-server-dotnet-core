using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;

namespace B2BCoreApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug().MinimumLevel
                .Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext().WriteTo
                .RollingFile("log-{Date}.txt").CreateLogger();

            Log.Information("starting web host");
            BuildWebHost(args).Run();

        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog()
                .Build();
    }
}