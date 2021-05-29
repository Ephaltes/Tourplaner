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
    public class CreateLogCommandValidatorTest
    {
        private CreateLogCommand query;
        private CreateLogCommandValidator validator;
        
        [SetUp]
        public void Setup()
        {
            var entity = new LogEntity();
            entity.Destination = "destination";
            entity.Distance = 232.32;
            entity.Origin = "origin";
            entity.Rating = 5.3;
            entity.Route_id = 1;
            entity.EndDate = DateTime.Now.AddDays(5);
            entity.EndTime = DateTime.Now.TimeOfDay;
            entity.StartDate = DateTime.Now;
            entity.StartTime = DateTime.Now.TimeOfDay;
            entity.BPM = 233;
            
            query = new CreateLogCommand(entity);
            validator = new CreateLogCommandValidator();
        }

        [Test]
        public async Task CreateLogCommandValidation_successful()
        {
            var result = validator.TestValidate(query);
            
            Assert.That(result.IsValid);
        }
        
        [Test]
        public async Task CreateLogCommandValidation_fails_Destination()
        {
            query.Entity.Destination = String.Empty;
            var result = validator.TestValidate(query);
            var error = result.ShouldHaveValidationErrorFor(x => x.Entity.Destination);
            
            Assert.That(error.Count() == 1);
        }
        [Test]
        public async Task CreateLogCommandValidation_fails_Distance()
        {
            query.Entity.Distance = -1;
            var result = validator.TestValidate(query);
            var error = result.ShouldHaveValidationErrorFor(x => x.Entity.Distance);
            
            Assert.That(error.Count() == 1);
        }
        [Test]
        public async Task CreateLogCommandValidation_fails_Origin()
        {
            query.Entity.Origin = String.Empty;
            var result = validator.TestValidate(query);
            var error = result.ShouldHaveValidationErrorFor(x => x.Entity.Origin);
            
            Assert.That(error.Count() == 1);
        }
        [Test]
        public async Task CreateLogCommandValidation_fails_Rating()
        {
            query.Entity.Rating = -1;
            var result = validator.TestValidate(query);
            var error = result.ShouldHaveValidationErrorFor(x => x.Entity.Rating);
            
            Assert.That(error.Count() == 1);
        }
        [Test]
        public async Task CreateLogCommandValidation_fails_RouteId()
        {
            query.Entity.Route_id = -1;
            var result = validator.TestValidate(query);
            var error = result.ShouldHaveValidationErrorFor(x => x.Entity.Route_id);
            
            Assert.That(error.Count() == 1);
        }
        [Test]
        public async Task CreateLogCommandValidation_fails_EndDateSmallerStartDate()
        {
            query.Entity.EndDate = DateTime.Now;
            query.Entity.StartDate = DateTime.Now.AddDays(5);
            var result = validator.TestValidate(query);
            var error = result.ShouldHaveValidationErrorFor(x => x.Entity.EndDate);
            
            Assert.That(error.Count() == 1);
        }
        [Test]
        public async Task CreateLogCommandValidation_fails_EndTime()
        {
            query.Entity.EndTime = TimeSpan.Zero;
            var result = validator.TestValidate(query);
            var error = result.ShouldHaveValidationErrorFor(x => x.Entity.EndTime);
            
            Assert.That(error.Count() == 1);
        }
        [Test]
        public async Task CreateLogCommandValidation_fails_StartTime()
        {
            query.Entity.StartTime = TimeSpan.Zero;
            var result = validator.TestValidate(query);
            var error = result.ShouldHaveValidationErrorFor(x => x.Entity.StartTime);
            
            Assert.That(error.Count() == 1);
        }
        [Test]
        public async Task CreateLogCommandValidation_fails_BPMTooHigh()
        {
            query.Entity.BPM = 251;
            var result = validator.TestValidate(query);
            var error = result.ShouldHaveValidationErrorFor(x => x.Entity.BPM);
            
            Assert.That(error.Count() == 1);
        }
        [Test]
        public async Task CreateLogCommandValidation_fails_BPMTooLow()
        {
            query.Entity.BPM = 0;
            var result = validator.TestValidate(query);
            var error = result.ShouldHaveValidationErrorFor(x => x.Entity.BPM);
            
            Assert.That(error.Count() == 1);
        }
        
    }
}