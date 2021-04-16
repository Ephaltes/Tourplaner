using System;
using frontend.API;
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
            Log.Debug("Add ViewModel Extension");
            // ViewModels
            services.AddScoped<MainWindowViewModel>();
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<SettingsViewModel>();
            services.AddTransient<CreateRouteViewModel>(CreateRoute);
            services.AddTransient<EditRouteviewModel>(EditRoute);
            services.AddSingleton<UpSertLogViewModel>();

            Log.Debug("Create ViewModel Extension");
            //CreateViewModel
            services.AddSingleton<ITourplanerViewModelAbstractFactory, TourplanerViewModelAbstractFactory>();
            services.AddSingleton<CreateViewModel<HomeViewModel>>(x => x.GetRequiredService<HomeViewModel>);
            services.AddSingleton<CreateViewModel<SettingsViewModel>>(x => x.GetRequiredService<SettingsViewModel>);
            services.AddSingleton<CreateViewModel<CreateRouteViewModel>>(x => x.GetRequiredService<CreateRouteViewModel>);
            services.AddSingleton<CreateViewModel<EditRouteviewModel>>(x => x.GetRequiredService<EditRouteviewModel>);
            services.AddSingleton<CreateViewModel<UpSertLogViewModel>>(x => x.GetRequiredService<UpSertLogViewModel>);
        }

        private static CreateRouteViewModel CreateRoute(IServiceProvider service)
        {
            return new CreateRouteViewModel(service.GetRequiredService<ITourplanerViewModelAbstractFactory>(),
               service.GetRequiredService<INavigator>(),
               service.GetRequiredService<IRouteService>()
            );
        }
        
        private static EditRouteviewModel EditRoute(IServiceProvider service)
        {
            return new EditRouteviewModel(service.GetRequiredService<ITourplanerViewModelAbstractFactory>(),
                service.GetRequiredService<INavigator>(),
                service.GetRequiredService<IRouteService>(),
                service.GetRequiredService<HomeViewModel>()
            );
        }
    }
}