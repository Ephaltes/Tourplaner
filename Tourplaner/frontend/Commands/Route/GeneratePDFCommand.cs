using System;
using System.IO;
using System.Threading.Tasks;
using frontend.API;
using frontend.Extensions;
using frontend.Model;
using frontend.ViewModels;
using Microsoft.Win32;
using RestWebservice_RemoteCompiling.Helpers;

namespace frontend.Commands.Route
{
    public class GeneratePDFCommand : AsyncCommandBase
    {
        private readonly IRouteService _routeService;
        private HomeViewModel _homeViewModel;
        public GeneratePDFCommand(IRouteService routeService, HomeViewModel homeViewModel)
        {
            _routeService = routeService;
            _homeViewModel = homeViewModel;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            if (parameter is RouteModel model)
            {
                var pdf = await _routeService.GeneratePDF(model.Id);
                var path = _homeViewModel.InteractionService.ShowSaveDialog();

                if (!String.IsNullOrEmpty(path))
                {
                    await File.WriteAllBytesAsync(path,pdf);
                }
                
            }
        }
    }
}