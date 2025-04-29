using MediatR;
using System.Collections.Generic;

namespace FiloCar.Application.Features.Vehicles.Queries.GetAllVehicle
{
    public class GetAllVehicleQuery : IRequest<List<GetAllVehicleQueryResponse>>
    {
        public int? DepartmanId { get; set; } // departman için filtreleme
        public string? FuelType { get; set; } // yakıt türü için filtreleme
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}