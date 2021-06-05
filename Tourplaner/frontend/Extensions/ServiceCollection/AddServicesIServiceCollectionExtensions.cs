using System;
using frontend.API;
using frontend.CustomControls;
using frontend.Navigation;
using frontend.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Utility;

namespace frontend.Extensions.ServiceCollection
{
    public static class AddServicesIServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
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