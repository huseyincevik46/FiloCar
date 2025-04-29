using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace FiloCar.Application.Features.Vehicles.Commands.UpdateVehicle
{
    public  class UpdateVehicleCommandRequest : IRequest<Unit>
    {
       public int VehicleId { get; set; }
       public int Departman { get; set; } 
        public string Model { get; set; }
        public string Brand { get; set; }
        public int Year { get; set; }
        public int Km { get; set; }
        public bool IsActive { get; set; } = true;
        public string PlateNumber { get; set; } = null!;

    }
}
