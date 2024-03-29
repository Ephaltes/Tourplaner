﻿using frontend.Navigation;
using frontend.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace frontend.Extensions.ServiceCollection
{
    public static class AddNavigationIServiceCollectionExtensions
    {
        public static void AddNavigation(this IServiceCollection services)
        {

            services.AddScoped<INavigator, Navigator>();
        }
    }
}