using System;
using frontend.API;
using frontend.CustomControls;
using frontend.Navigation;
using frontend.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestWebservice_RemoteCompiling.Helpers;
using Serilog;

namespace frontend.Extensions.ServiceCollection
{
    public static class AddServicesIServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            Log.Debug("adding Navigator");
            services.AddScoped<ITourService, TourServiceAPI>();
            services.AddScoped<IHttpHelper>(CreateHttpHelper);
            services.AddScoped<IUserInteractionService, UserInteractionService>();
        }
        
        private static HttpHelper CreateHttpHelper(IServiceProvider service)
        {
            return new HttpHelper("https://localhost:5001/");
        }
    }
}