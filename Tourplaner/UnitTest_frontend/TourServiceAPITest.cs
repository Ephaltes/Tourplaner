using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using frontend.API;
using frontend.Entities;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using TourService.Entities;
using Utility;

namespace UnitTest_frontend
{
    public class TourServiceAPITest
    {
        private TourServiceAPI service;
        private Mock<IHttpHelper> mockHelper;
        
        [SetUp]
        public void Setup()
        {
            mockHelper = new Mock<IHttpHelper>();
            service = new TourServiceAPI(mockHelper.Object);
        }

        [Test]
        public async Task GetRouteInformation_successful()
        {
            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            var responseObject = new ResponseObject();
            responseObject.data = new MapQuestServiceResponse();
            var jsonString = JsonConvert.SerializeObject(responseObject);
            responseMessage.Content = new StringContent(jsonString);

            mockHelper.Setup(x => x.ExecuteGet(It.IsAny<string>())).ReturnsAsync(responseMessage);

            var response = await service.GetRouteInformation("start", "destination");
            
            Assert.That(response != null);
        }
        
        [Test]
        public async Task GetRouteInformation_fails_statuscode()
        {
            var responseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);
            var responseObject = new ResponseObject();
            responseObject.data = new MapQuestServiceResponse();
            var jsonString = JsonConvert.SerializeObject(responseObject);
            responseMessage.Content = new StringContent(jsonString);

            mockHelper.Setup(x => x.ExecuteGet(It.IsAny<string>())).ReturnsAsync(responseMessage);

            var response = await service.GetRouteInformation("start", "destination");
            
            Assert.That(response == null);
        }
        
        [Test]
        public async Task GetRouteInformation_fails_noContent()
        {
            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            responseMessage.Content = null;

            mockHelper.Setup(x => x.ExecuteGet(It.IsAny<string>())).ReturnsAsync(responseMessage);

            var response = await service.GetRouteInformation("start", "destination");
            
            Assert.That(response == null);
        }
        
        [Test]
        public async Task GetRouteInformation_fails_noData()
        {
            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            var responseObject = new ResponseObject();
            responseObject.data = null;
            var jsonString = JsonConvert.SerializeObject(responseObject);
            responseMessage.Content = new StringContent(jsonString);

            mockHelper.Setup(x => x.ExecuteGet(It.IsAny<string>())).ReturnsAsync(responseMessage);

            var response = await service.GetRouteInformation("start", "destination");
            
            Assert.That(response == null);
        }
        
        [Test]
        public async Task CreateLog_successful()
        {
            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            var entity = new RouteEntity();
            var responseObject = new ResponseObject();
            responseObject.data = 5;
            var jsonString = JsonConvert.SerializeObject(responseObject);
            responseMessage.Content = new StringContent(jsonString);

            mockHelper.Setup(x => x.ExecutePost(It.IsAny<string>(),It.IsAny<object>())).ReturnsAsync(responseMessage);

            var response = await service.CreateRoute(entity);
            
            Assert.That(response == 5);
        }
        
        [Test]
        public async Task CreateLog_fails_statuscode()
        {
            var responseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);
            var responseObject = new ResponseObject();
            var entity = new RouteEntity();
            responseObject.data = null;
            var jsonString = JsonConvert.SerializeObject(responseObject);
            responseMessage.Content = new StringContent(jsonString);

            mockHelper.Setup(x => x.ExecutePost(It.IsAny<string>(),It.IsAny<object>())).ReturnsAsync(responseMessage);

            var response = await service.CreateRoute(entity);
            
            Assert.That(response == -1);
        }
        
        [Test]
        public async Task CreateLog_fails_content()
        {
            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            var responseObject = new ResponseObject();
            var entity = new RouteEntity();
            responseObject.data = null;
            var jsonString = JsonConvert.SerializeObject(responseObject);
            responseMessage.Content = new StringContent(jsonString);

            mockHelper.Setup(x => x.ExecutePost(It.IsAny<string>(),It.IsAny<object>())).ReturnsAsync(responseMessage);

            var response = await service.CreateRoute(entity);
            
            Assert.That(response == 0);
        }
        
        
        [Test]
        public async Task GetAllRoutes_successful()
        {
            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            var responseObject = new ResponseObject();
            responseObject.data = new List<RouteEntity>() {new RouteEntity()};
            var jsonString = JsonConvert.SerializeObject(responseObject);
            responseMessage.Content = new StringContent(jsonString);

            mockHelper.Setup(x => x.ExecuteGet(It.IsAny<string>())).ReturnsAsync(responseMessage);

            var response = await service.GetAllRoutes();
            
            Assert.That(response != null && response.Count == 1);
        }
        
        [Test]
        public async Task GetAllRoutes_fails_statuscode()
        {
            var responseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);
            var responseObject = new ResponseObject();
            responseObject.data = new MapQuestServiceResponse();
            var jsonString = JsonConvert.SerializeObject(responseObject);
            responseMessage.Content = new StringContent(jsonString);

            mockHelper.Setup(x => x.ExecuteGet(It.IsAny<string>())).ReturnsAsync(responseMessage);

            var response = await service.GetAllRoutes();
            
            Assert.That(response != null && response.Count == 0);
        }
        
        [Test]
        public async Task GetAllRoutes_fails_noData()
        {
            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            var responseObject = new ResponseObject();
            responseObject.data = null;
            var jsonString = JsonConvert.SerializeObject(responseObject);
            responseMessage.Content = new StringContent(jsonString);

            mockHelper.Setup(x => x.ExecuteGet(It.IsAny<string>())).ReturnsAsync(responseMessage);

            var response = await service.GetAllRoutes();
            
            Assert.That(response != null && response.Count == 0);
        }
        
        [Test]
        public async Task GetAllRoutes_fails_noContent()
        {
            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            responseMessage.Content = null;

            mockHelper.Setup(x => x.ExecuteGet(It.IsAny<string>())).ReturnsAsync(responseMessage);

            var response = await service.GetAllRoutes();
            
            Assert.That(response != null && response.Count == 0);
        }
        
        [Test]
        public async Task GetAllRoutes_fails_noArray()
        {
            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            var responseObject = new ResponseObject();
            responseObject.data = new RouteEntity();
            var jsonString = JsonConvert.SerializeObject(responseObject);
            responseMessage.Content = new StringContent(jsonString);

            mockHelper.Setup(x => x.ExecuteGet(It.IsAny<string>())).ReturnsAsync(responseMessage);

            var response = await service.GetAllRoutes();
            
            Assert.That(response != null && response.Count == 0);
        }

        

        
    }
}