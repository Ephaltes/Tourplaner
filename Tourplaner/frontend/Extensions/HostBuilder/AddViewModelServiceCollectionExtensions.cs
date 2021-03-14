using frontend.ViewModels;
using frontend.ViewModels.Factories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace frontend.Extensions.HostBuilder
{
    public static class AddViewModelIServiceCollectionExtensions
    {
        public static void AddViewModels(this IServiceCollection services)
        {
            // ViewModels
            services.AddScoped<MainWindowViewModel>();
            services.AddSingleton<DefaultViewModel>();
            services.AddSingleton<TestViewModel>();
            
            //CreateViewModel
            services.AddSingleton<ITourplanerViewModelAbstractFactory, TourplanerViewModelAbstractFactory>();
            services.AddSingleton<CreateViewModel<DefaultViewModel>>(x => x.GetRequiredService<DefaultViewModel>);
            services.AddSingleton<CreateViewModel<TestViewModel>>(x => x.GetRequiredService<TestViewModel>);
        }
    }
}