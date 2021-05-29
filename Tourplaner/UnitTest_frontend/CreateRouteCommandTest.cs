using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using frontend.API;
using frontend.Commands.Route;
using frontend.CustomControls;
using frontend.Extensions;
using frontend.Model;
using frontend.Navigation;
using Moq;
using NUnit.Framework;
using TourService.Entities;

namespace UnitTest_frontend
{
    public class CreateRouteCommandTest
    {
        private CreateRouteCommand createRouteCommand;
        private Mock<INavigator> mockNavigator;
        private Mock<ITourService> mockTourService;
        private Mock<IUserInteractionService> mockUserInteractionService;

        [SetUp]
        public void Setup()
        {
            mockNavigator = new Mock<INavigator>();
            mockTourService = new Mock<ITourService>();
            mockUserInteractionService = new Mock<IUserInteractionService>();

            var model = new RouteModel(mockTourService.Object);
            
            model.Description = "description";
            model.Destination = "destination";
            model.Name = "routeName";
            model.Origin = "Origin";
            model.EstimatedDistance = 22.3;
            model.ImageSource = new byte[5];
            model.Directions = new List<string>();
            model.Logs = new Lazy<ObservableCollection<LogModel>>();
            model.Id = 0;

            createRouteCommand = new CreateRouteCommand(mockTourService.Object, mockNavigator.Object,
                model, mockUserInteractionService.Object);
        }

        [Test]
        public async Task CreateRouteCommand_successful()
        {
            mockTourService.Setup(x => x.CreateRoute(It.IsAny<RouteEntity>())).ReturnsAsync(5);
            mockUserInteractionService.Setup(x => x.ShowErrorMessageBox(It.IsAny<string>(),It.IsAny<string>()));
            
            await createRouteCommand.ExecuteAsync(null);

            mockUserInteractionService.Verify(
                mock => mock.ShowErrorMessageBox(It.IsAny<string>(), It.IsAny<string>()),
                Times.Never);
        }
        
        [Test]
        public async Task CreateRouteCommand_fails()
        {
            mockTourService.Setup(x => x.CreateRoute(It.IsAny<RouteEntity>())).ReturnsAsync(0);
            mockUserInteractionService.Setup(x => x.ShowErrorMessageBox(It.IsAny<string>(),It.IsAny<string>()));
            
            await createRouteCommand.ExecuteAsync(null);

            mockUserInteractionService.Verify(
                x => x.ShowErrorMessageBox(It.IsAny<string>(), It.IsAny<string>()),
                Times.Once);
        }
    }
}