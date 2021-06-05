using System;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.TestHelper;
using Moq;
using NUnit.Framework;
using TourService.Command;
using TourService.Entities;
using TourService.Query;
using TourService.Repository;
using TourService.Validation;

namespace UnitTest_TourService.Validation
{
    public class GetLogsQueryValidatorTest
    {
        private GetLogsQuery query;
        private GetLogsQueryValidator validator;
        
        [SetUp]
        public void Setup()
        {
            var routeRepositoryMock = new Mock<IRouteRepository>();
            var entity = new RouteEntity();
            routeRepositoryMock.Setup(x => x.Get(It.Is<int>(i => i == 1))).ReturnsAsync(entity);

            query = new GetLogsQuery(1);
            validator = new GetLogsQueryValidator(routeRepositoryMock.Object);
        }

        [Test]
        public async Task GetLogsQueryValidation_successful()
        {
            var result = validator.TestValidate(query);
            Assert.That(result.IsValid);
        }
        
        
        [Test]
        public async Task GetLogsQuery_fails_IdExistsMethod()
        {
            query.Id = 5;
            var result = validator.TestValidate(query);
            var error = result.ShouldHaveValidationErrorFor(x => x.Id);
            
            Assert.That(error.Count() == 1);
        }
    }
}