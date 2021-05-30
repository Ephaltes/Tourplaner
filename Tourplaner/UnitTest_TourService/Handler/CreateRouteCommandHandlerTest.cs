using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TourService.Command;
using TourService.Entities;
using TourService.Handler;
using TourService.Repository;

namespace UnitTest_TourService
{
    public class CreateRouteCommandHandlerTest
    {
        private Mock<IRouteRepository> mockRouteRepository;
        private Mock<IFileRepository> mockFileRepository;
        private CreateRouteCommand query;
        
        [SetUp]
        public void Setup()
        {
            mockRouteRepository = new Mock<IRouteRepository>();
            mockFileRepository = new Mock<IFileRepository>();

            RouteEntity entity = new RouteEntity();
            entity.Destination = "destination";
            entity.Description = "description";
            entity.Name = "name";
            entity.Origin = "origin";
            entity.ImageSource = new byte[64];
            entity.Directions = new List<string>();
            entity.Id = 0;
            entity.EstimatedDistance  = 50;

            query = new CreateRouteCommand(entity);
        }

        [Test]
        public async Task CreateRouteCommand_successful()
        {
            var handler = new CreateRouteCommandHandler(mockRouteRepository.Object, mockFileRepository.Object);
            var success = 1;
            
            mockRouteRepository.Setup(x => x.UpSert(It.IsAny<RouteEntity>())).ReturnsAsync(success);
            mockFileRepository.Setup(x => x.SaveFileToDisk(It.IsAny<string>(), It.IsAny<byte[]>())).ReturnsAsync(true);

            var response = await handler.Handle(query, new CancellationToken());
            
            Assert.That(response.Data == success && !string.IsNullOrEmpty(query.Entity.FileName));
        }
        
        [Test]
        public async Task CreateRouteCommand_fails_SaveFileToDisk()
        {
            var handler = new CreateRouteCommandHandler(mockRouteRepository.Object, mockFileRepository.Object);
            var success = 1;
            var errorCode = 400;
            
            mockRouteRepository.Setup(x => x.UpSert(It.IsAny<RouteEntity>())).ReturnsAsync(success);
            mockFileRepository.Setup(x => x.SaveFileToDisk(It.IsAny<string>(), It.IsAny<byte[]>())).ReturnsAsync(false);

            var response = await handler.Handle(query, new CancellationToken());
            
            Assert.That(response.StatusCode == errorCode);
        }
    }
}