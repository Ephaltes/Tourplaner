using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using frontend.API;
using frontend.CustomControls;
using frontend.Entities;
using frontend.Navigation;
using frontend.ViewModels;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using TourService.Entities;
using Utility;

namespace UnitTest_frontend
{
    public class CreateRouteViewModelTest
    {
        private CreateRouteViewModel viewModel;
        private Mock<INavigator> mockNavigator;
        private Mock<ITourService> mockTourService;
        private Mock<IUserInteractionService> mockUserInteractionService;
        
        [SetUp]
        public void Setup()
        {
            mockNavigator = new Mock<INavigator>();
            mockTourService = new Mock<ITourService>();
            mockUserInteractionService = new Mock<IUserInteractionService>();

            viewModel = new CreateRouteViewModel(mockNavigator.Object, mockTourService.Object,
                mockUserInteractionService.Object);
            
            viewModel.Description = "description";
            viewModel.Destination = "destination";
            viewModel.Name = "routeName";
            viewModel.Origin = "Origin";
            viewModel.EstimatedDistance = 22.3;
            viewModel.ImageSource = new byte[5];
        }

        [Test]
        public async Task CreateRouteViewModel_InputErrors_Description()
        {
            viewModel.Description = "";
            
          Assert.That(viewModel.GetErrors(nameof(viewModel.Description)) != null);
        }
        
        [Test]
        public async Task CreateRouteViewModel_InputErrors_Destination()
        {
            viewModel.Destination = "";
            
            Assert.That(viewModel.GetErrors(nameof(viewModel.Destination)) != null);
        }
        
        [Test]
        public async Task CreateRouteViewModel_InputErrors_Name()
        {
            viewModel.Name = "";
            
            Assert.That(viewModel.GetErrors(nameof(viewModel.Name)) != null);
        }
        
        [Test]
        public async Task CreateRouteViewModel_InputErrors_Origin()
        {
            viewModel.Origin = "";
            
            Assert.That(viewModel.GetErrors(nameof(viewModel.Origin)) != null);
        }
        
        [Test]
        public async Task CreateRouteViewModel_InputErrors_EstimatedDistance()
        {
            viewModel.EstimatedDistance = 0;
            Assert.That(viewModel.GetErrors(nameof(viewModel.EstimatedDistance)) != null);
        }
        
        [Test]
        public async Task CreateRouteViewModel_InputErrors_ImageSource()
        {
            viewModel.ImageSource = null;
            Assert.That(viewModel.GetErrors(nameof(viewModel.ImageSource)) != null);
        }
        
        [Test]
        public async Task CreateRouteViewModel_Successful()
        {
            Assert.That(!viewModel.HasErrors);
        }
        
        

    }
}