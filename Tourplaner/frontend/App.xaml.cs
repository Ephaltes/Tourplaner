using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Formats.Asn1;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using frontend.Extensions.HostBuilder;
using frontend.Navigation;
using frontend.ViewModels;
using frontend.ViewModels.Factories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;

namespace frontend
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        private IServiceProvider ServiceProvider { get;  set; }
 
        private IConfiguration Configuration { get;  set; }
 
        protected override void OnStartup(StartupEventArgs e)
        {
            StartLogger();
            
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
 
            Configuration = builder.Build();

            Log.Debug(Configuration.GetConnectionString("DefaultConnection"));    

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
 
            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            Log.Debug("Show MainWindow");    
        }
 
        private void ConfigureServices(IServiceCollection services)
        {
            services.AddNavigation();
            services.AddViews();
            services.AddViewModels();
            Log.Debug("finished ConfigureServices");
        }
        
        private static void StartLogger()
        {
            var logfile = Directory.GetCurrentDirectory() + "/log.txt";

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Debug()
                .WriteTo.File(logfile, LogEventLevel.Verbose,
                    "{NewLine}{Timestamp:HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}",
                    rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}