using System;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.TestHelper;
using NUnit.Framework;
using TourService.Command;
using TourService.Entities;
using TourService.Validation;

namespace UnitTest_TourService.Validation
{
    public class CreateRouteCommandValidatorTest
    {
        private CreateRouteCommand query;
        private CreateRouteCommandValidator validator;
        
        [SetUp]
        public void Setup()
        {
            var entity = new RouteEntity();
            entity.Destination = "destination";
            entity.Description = "description";
            entity.Name = "name";
            entity.Origin = "origin";
            entity.ImageSource = new byte[64];

            query = new CreateRouteCommand(entity);
            validator = new CreateRouteCommandValidator();
        }

        [Test]
        public async Task CreateRouteCommandValidation_successful()
        {
            var result = validator.TestValidate(query);
            
            Assert.That(result.IsValid);
        }
        
        [Test]
        public async Task CreateRouteCommandValidation_fails_Destination()
        {
            query.Entity.Destination = String.Empty;
            var result = validator.TestValidate(query);
            var error = result.ShouldHaveValidationErrorFor(x => x.Entity.Destination);
            
            Assert.That(error.Count() == 1);
        }
        
        [Test]
        public async Task CreateRouteCommandValidation_fails_Description()
        {
            query.Entity.Description = String.Empty;
            var result = validator.TestValidate(query);
            var error = result.ShouldHaveValidationErrorFor(x => x.Entity.Description);
            
            Assert.That(error.Count() == 1);
        }
        
        [Test]
        public async Task CreateRouteCommandValidation_fails_Name()
        {
            query.Entity.Name = String.Empty;
            var result = validator.TestValidate(query);
            var error = result.ShouldHaveValidationErrorFor(x => x.Entity.Name);
            
            Assert.That(error.Count() == 1);
        }
        
        [Test]
        public async Task CreateRouteCommandValidation_fails_Origin()
        {
            query.Entity.Origin = String.Empty;
            var result = validator.TestValidate(query);
            var error = result.ShouldHaveValidationErrorFor(x => x.Entity.Origin);
            
            Assert.That(error.Count() == 1);
        }
        
        [Test]
        public async Task CreateRouteCommandValidation_fails_ImageSource()
        {
            query.Entity.ImageSource = null;
            var result = validator.TestValidate(query);
            var error = result.ShouldHaveValidationErrorFor(x => x.Entity.ImageSource);
            
            Assert.That(error.Count() == 1);
        }


    }
}