using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using frontend.API;
using frontend.Extensions;
using frontend.Model;
using frontend.Navigation;
using frontend.ViewModels;
using Newtonsoft.Json;

namespace frontend.Commands.Route
{
    public class ImportRouteCommand : AsyncCommandBase
    {
        private HomeViewModel _homeViewModel;
        private ITourService _tourService;
        private INavigator _navigator;

        public ImportRouteCommand(HomeViewModel homeViewModel, ITourService tourService, INavigator navigator)
        {
            _homeViewModel = homeViewModel;
            _tourService = tourService;
            _navigator = navigator;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var path = _homeViewModel.InteractionService.ShowOpenFileDialog();
            if (path != null && path.Length > 0)
            {
                var routeEntities = await ImportExportHelper.Import(path);

                foreach (var routeEntity in routeEntities)
                {
                    routeEntity.Id = 0;
                    routeEntity.Id = await _tourService.CreateRoute(routeEntity);

                    foreach (var logEntity in routeEntity.Logs)
                    {
                        logEntity.Id = 0;
                        logEntity.Route_id = routeEntity.Id;
                        await _tourService.CreateLog(logEntity);
                    }
                }
            }
            _navigator.ChangeViewModel(ViewType.Home);
        }
    }
}