using frontend.Navigation;
using frontend.ViewModels;
using frontend.ViewModels.Factories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace frontend.Extensions.HostBuilder
{
    public static class AddNavigationIServiceCollectionExtensions
    {
        public static void AddNavigation(this IServiceCollection services)
        {
            services.AddScoped<INavigator, Navigator>();
        }
    }
}