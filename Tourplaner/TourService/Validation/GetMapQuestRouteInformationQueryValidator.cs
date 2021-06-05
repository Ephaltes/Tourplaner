using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Serilog;
using TourService.Query;
using TourService.Repository;

namespace TourService.Validation
{
    public class GetMapQuestRouteInformationQueryValidator : CustomAbstractValidator<GetMapQuestRouteInformationQuery>
    {
        private readonly ILogger _logger = Log.ForContext<RouteRepository>();
        private readonly IConfiguration _configuration;
        public GetMapQuestRouteInformationQueryValidator(IConfiguration configuration)
        {
            _configuration = configuration;

            RuleFor(x => x.From)
                .NotEmpty()
                .WithMessage("Origin is Empty");
            
            RuleFor(x => x.To)
                .NotEmpty()
                .WithMessage("Destination is Empty");

            RuleFor(x => x.Language)
                .NotEmpty()
                .WithMessage("Language is empty")
                .Must(SupportedLanguage)
                .WithMessage("Language is not supported");
        }

        private bool SupportedLanguage(string language)
        {
            try
            {
                var languageList = _configuration.GetSection("MapQuestSupportedLanguage")
                    .GetChildren()
                    .ToArray()
                    .Select(x=>x.Value)
                    .ToList();

                return languageList.Any(x => x == language.ToLower());
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                return false;
            }
        }
    }
}