using MediatR;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using TourService.Entities;

namespace TourService.Query
{
    public class GeneratePDFQuery: IRequest<CustomResponse<byte[]>>
    {
        public int Id { get; set; }

        public GeneratePDFQuery(int id)
        {
            Id = id;
        }
    }
}