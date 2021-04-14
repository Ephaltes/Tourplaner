using frontend.CustomControls.Dialog;
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
            services.AddSingleton<UpSertRouteViewModel>();
            services.AddSingleton<UpSertLogViewModel>();

            Log.Debug("Create ViewModel Extension");
            //CreateViewModel
            services.AddSingleton<ITourplanerViewModelAbstractFactory, TourplanerViewModelAbstractFactory>();
            services.AddSingleton<CreateViewModel<HomeViewModel>>(x => x.GetRequiredService<HomeViewModel>);
            services.AddSingleton<CreateViewModel<SettingsViewModel>>(x => x.GetRequiredService<SettingsViewModel>);
            services.AddSingleton<CreateViewModel<UpSertRouteViewModel>>(x => x.GetRequiredService<UpSertRouteViewModel>);
            services.AddSingleton<CreateViewModel<UpSertLogViewModel>>(x => x.GetRequiredService<UpSertLogViewModel>);
        }
    }
}