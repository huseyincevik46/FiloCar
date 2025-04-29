using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace FiloCar.Application.Features.Vehicles.Queries.GetAllVehicle
{
    public class GetAllVehicleQueryResponse 
    {
        public int VehicleId { get; set; }
        public int? DepartmanId { get; set; }
        public string PlateNumber { get; set; }
        public string Brand { get; set; } 
        public string Model { get; set; } 
        public int Year { get; set; }
        public int Km { get; set; }
        public string? DepartmanName { get; set; }
        public string? FuelType { get; set; } 
    }
}
