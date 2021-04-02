using frontend.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace frontend.Extensions.ServiceCollection
{
    public static class AddViewsIServiceCollectionExtensions
    {
        public static void AddViews(this IServiceCollection services)
        {
            Log.Debug("AddViewsExtension");
            services.AddSingleton<MainWindow>(s => new MainWindow(s.GetRequiredService<MainWindowViewModel>()));
        }
    }
}