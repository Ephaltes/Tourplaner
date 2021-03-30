﻿using frontend.ViewModels;
using frontend.ViewModels.Factories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace frontend.Extensions.ServiceCollection
{
    public static class AddViewModelIServiceCollectionExtensions
    {
        public static void AddViewModels(this IServiceCollection services)
        {
            // ViewModels
            services.AddScoped<MainWindowViewModel>();
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<SettingsViewModel>();
            
            //CreateViewModel
            services.AddSingleton<ITourplanerViewModelAbstractFactory, TourplanerViewModelAbstractFactory>();
            services.AddSingleton<CreateViewModel<HomeViewModel>>(x => x.GetRequiredService<HomeViewModel>);
            services.AddSingleton<CreateViewModel<SettingsViewModel>>(x => x.GetRequiredService<SettingsViewModel>);
        }
    }
}