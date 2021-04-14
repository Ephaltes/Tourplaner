using frontend.API;
using frontend.Navigation;
using frontend.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace frontend.Extensions.ServiceCollection
{
    public static class AddServicesIServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            Log.Debug("adding Navigator");
            services.AddScoped<IRouteService, RouteService>();
        }
    }
}