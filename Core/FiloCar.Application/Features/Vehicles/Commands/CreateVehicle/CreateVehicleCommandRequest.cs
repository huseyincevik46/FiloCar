using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace FiloCar.Application.Features.Vehicles.Commands.CreateVehicle
{
    public class CreateVehicleCommandRequest : IRequest<Unit>
    {
  
        public string PlateNumber { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Year { get; set; }
        public int Km { get; set; }
        public bool IsActive { get; set; } = true;
        public int? DepartmanId { get; set; }
        public string FuelType { get; set; } = null!;
    }
}
