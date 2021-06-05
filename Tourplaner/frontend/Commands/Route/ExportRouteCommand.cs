using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using frontend.Extensions;
using frontend.Model;
using frontend.ViewModels;
using Newtonsoft.Json;
using Serilog;

namespace frontend.Commands.Route
{
    public class ExportRouteCommand : AsyncCommandBase
    {
        private HomeViewModel _homeViewModel;
        private readonly ILogger _logger = Log.ForContext<ExportRouteCommand>();

        public ExportRouteCommand(HomeViewModel homeViewModel)
        {
            _homeViewModel = homeViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                if (parameter is RouteModel model)
                {
                    var path = _homeViewModel.InteractionService.ShowSaveDialog("JSON File (*.json)|*.json");
                    if (!String.IsNullOrEmpty(path))
                    {
                        if (await ImportExportHelper.Export(model, path))
                        {
                            var info = new ProcessStartInfo(path);
                            info.CreateNoWindow = true;
                            info.UseShellExecute = true;
                            Process.Start(info);
                            return;
                        }
                    }
                }
                _homeViewModel.InteractionService.ShowErrorMessageBox(Languages.Strings.error_export_route);
                _logger.Error("Exporting Route Error");
            }
            catch (Exception e)
            {
                _homeViewModel.InteractionService.ShowErrorMessageBox(Languages.Strings.error_unexpected);
                _logger.Error($"Unexpected Error\n {e.Message}");
            }
        }
    }
}