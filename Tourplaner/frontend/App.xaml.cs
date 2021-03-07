using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using frontend.Navigation;
using frontend.ViewModels;
using frontend.ViewModels.Factories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace frontend
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        public IServiceProvider ServiceProvider { get; private set; }
 
        public IConfiguration Configuration { get; private set; }
 
        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
 
            Configuration = builder.Build();

            Console.WriteLine(Configuration.GetConnectionString("DefaultConnection"));    

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
 
            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
 
        private void ConfigureServices(IServiceCollection services)
        {
            // Views
          
            
            services.AddScoped<INavigator, Navigator>();
            
            //Factories
            
            services.AddSingleton<ITourplanerViewModelAbstractFactory, TourplanerViewModelAbstractFactory>();
            services.AddSingleton<IViewModelFactory<DefaultViewModel>, DefaultViewModelFactory>();
            services.AddSingleton<IViewModelFactory<TestViewModel>, TestViewModelFactory>();
            
            // ViewModels
            services.AddScoped<MainWindowViewModel>();
            services.AddSingleton<DefaultViewModel>();
            services.AddSingleton<TestViewModel>();
            
            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainWindowViewModel>()));

        }
    }
}