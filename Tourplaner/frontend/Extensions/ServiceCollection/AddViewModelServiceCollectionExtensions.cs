using System;
using frontend.API;
using frontend.CustomControls;
using frontend.CustomControls.Dialog;
using frontend.Navigation;
using frontend.ViewModels;
using frontend.ViewModels.Factories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace frontend.Extensions.ServiceCollection
{
    public static class AddViewModelIServiceCollectionExtensions
    {
        public static void AddViewModels(this IServiceCollection services)
        {

            // ViewModels
            services.AddScoped<MainWindowViewModel>();
            services.AddTransient<HomeViewModel>();
            services.AddSingleton<SettingsViewModel>();
            services.AddTransient<CreateRouteViewModel>(CreateRoute);
            services.AddSingleton<EditRouteViewModel>(EditRoute);
            services.AddTransient<UpSertLogViewModel>(UpsertLog);


            //CreateViewModel
            services.AddSingleton<ITourplanerViewModelAbstractFactory, TourplanerViewModelAbstractFactory>();
            services.AddSingleton<CreateViewModel<HomeViewModel>>(x => x.GetRequiredService<HomeViewModel>);
            services.AddSingleton<CreateViewModel<SettingsViewModel>>(x => x.GetRequiredService<SettingsViewModel>);
            services.AddSingleton<CreateViewModel<CreateRouteViewModel>>(x => x.GetRequiredService<CreateRouteViewModel>);
            services.AddSingleton<CreateViewModel<EditRouteViewModel>>(x => x.GetRequiredService<EditRouteViewModel>);
            services.AddSingleton<CreateViewModel<UpSertLogViewModel>>(x => x.GetRequiredService<UpSertLogViewModel>);
        }

        private static CreateRouteViewModel CreateRoute(IServiceProvider service)
        {
            return new CreateRouteViewModel(service.GetRequiredService<INavigator>(),
               service.GetRequiredService<ITourService>(),
               service.GetRequiredService<IUserInteractionService>()
            );
        }
        
        private static UpSertLogViewModel UpsertLog(IServiceProvider service)
        {
            return new UpSertLogViewModel(service.GetRequiredService<INavigator>(),
                service.GetRequiredService<ITourService>(),
                service.GetRequiredService<IUserInteractionService>()
                );
        }
        
        private static EditRouteViewModel EditRoute(IServiceProvider service)
        {
            return new EditRouteViewModel(service.GetRequiredService<INavigator>(),
                service.GetRequiredService<ITourService>(),
                service.GetRequiredService<IUserInteractionService>()
            );
        }
    }
}