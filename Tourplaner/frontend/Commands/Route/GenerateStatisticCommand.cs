﻿using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using frontend.API;
using frontend.Extensions;
using frontend.Model;
using frontend.ViewModels;
using Microsoft.Win32;

namespace frontend.Commands.Route
{
    public class GenerateStatisticCommand : AsyncCommandBase
    {
        private readonly ITourService _tourService;
        private HomeViewModel _homeViewModel;

        public GenerateStatisticCommand(ITourService tourService, HomeViewModel homeViewModel)
        {
            _tourService = tourService;
            _homeViewModel = homeViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var pdf = await _tourService.GenerateStatistic();
            if (pdf == null || pdf.Length == 0)
                return;

            var path = _homeViewModel.InteractionService.ShowSaveDialog();

            if (!String.IsNullOrEmpty(path))
            {
                await File.WriteAllBytesAsync(path, pdf);
                var info = new ProcessStartInfo(path);
                info.CreateNoWindow = true;
                info.UseShellExecute = true;
                Process.Start(info);
            }
        }
    }
}