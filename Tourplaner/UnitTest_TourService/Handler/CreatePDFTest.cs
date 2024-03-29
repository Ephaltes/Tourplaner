using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Serilog;
using TourService.Entities;
using TourService.Handler;
using TourService.Query;
using TourService.RazorToString;
using TourService.Repository;

namespace UnitTest_TourService
{
    public class CreatePDFTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task CreateRoutePDFTest()
        {
            List<LogEntity> logEntities = new List<LogEntity>();
            GeneratePDFQuery query = new GeneratePDFQuery(1);
            var rendererService = new Mock<IViewRenderService>();
            var routeRepository = new Mock<IRouteRepository>();
            var logRepository = new Mock<ILogRepository>();
            var fileRepository = new Mock<IFileRepository>();
            var handler = new GeneratePDFQueryHandler(rendererService.Object, routeRepository.Object, logRepository.Object,fileRepository.Object);

            RouteEntity routeEntity = new RouteEntity
            {
                Description = "description",
                Destination = "destination",
                Directions = new List<string>(){"hello","right"},
                Id = 1,
                Name = "Name",
                Origin = "Origin",
                ImageSource = File.ReadAllBytes(Directory.GetCurrentDirectory() + $"/images/placeholder.png"),
            };

            LogEntity logEntity = new LogEntity();
            logEntity.Id = 1;
            logEntity.StartDate = new DateTime(2020,10,25,10,30,54);
            logEntity.EndDate = new DateTime(2020,10,27,10,30,54);
            logEntity.Origin = "Origin_log";
            logEntity.Destination = "Destination_log";
            logEntity.Distance = 55.34;
            logEntity.Rating = 5.3;
            logEntity.Note = "I am thirsty";
            logEntity.MovementMode = MovementMode.Bicycle;
            logEntity.Mood = Mood.Good;
            logEntity.BPM = 232;
            logEntity.StartTime = logEntity.StartDate.TimeOfDay;
            logEntity.EndTime = logEntity.EndDate.TimeOfDay;
            
            logEntities.Add(logEntity);
            logEntities.Add(logEntity);
            logEntities.Add(logEntity);
            
            
            rendererService.Setup(x => 
                x.RenderToStringAsync(It.IsAny<string>(), It.IsAny<object>())).ReturnsAsync("Hello World");

            routeRepository.Setup(x => x.Get(It.IsAny<int>())).ReturnsAsync(routeEntity);
            logRepository.Setup(x => x.GetAllForRoute(It.IsAny<int>())).ReturnsAsync(logEntities);
            fileRepository.Setup(x => x.ReadFileFromDisk(It.IsAny<string>()))
                .ReturnsAsync(File.ReadAllBytes(Directory.GetCurrentDirectory() + $"/images/placeholder.png"));

            var response = await handler.Handle(query, new CancellationToken());
            Assert.That(response.Data.Length==26703);
        }

        [Test]
        public async Task CreateStatisticPDFTest()
        {
            List<LogEntity> logEntities = new List<LogEntity>();
            List<RouteEntity> routeEntities = new List<RouteEntity>();
            var rendererService = new Mock<IViewRenderService>();
            var routeRepository = new Mock<IRouteRepository>();
            var logRepository = new Mock<ILogRepository>();
            var query = new GenerateStatisticQuery();
            var handler = new GenerateStatisticQueryHandler(rendererService.Object,routeRepository.Object,logRepository.Object);
            
            rendererService.Setup(x => 
                x.RenderToStringAsync(It.IsAny<string>(), It.IsAny<object>())).ReturnsAsync("Generate Statistics");

            routeRepository.Setup(x => x.GetAll()).ReturnsAsync(routeEntities);
            logRepository.Setup(x => x.GetAll()).ReturnsAsync(logEntities);

            var output = await handler.Handle(query, new CancellationToken());
            
            Assert.That(output.Data.Length == 33986);
            
        }
    }
}