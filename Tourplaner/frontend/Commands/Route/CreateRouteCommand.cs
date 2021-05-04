﻿using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using frontend.API;
using frontend.Entities;
using frontend.Extensions;
using frontend.Model;
using frontend.Navigation;
using frontend.ViewModels;

namespace frontend.Commands.Route
{
    public class CreateRouteCommand : AsyncCommandBase
    {
        private readonly ITourService _service;
        private readonly INavigator _navigator;
        private RouteModel _routeModel;
        
        public CreateRouteCommand(ITourService service, INavigator navigator, RouteModel routeModel)
        {
            _service = service;
            _navigator = navigator;
            _routeModel = routeModel;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            int response = await _service.CreateRoute(_routeModel.ToEntity());
            _navigator.ChangeViewModel(ViewType.Home);
        }
    }
}