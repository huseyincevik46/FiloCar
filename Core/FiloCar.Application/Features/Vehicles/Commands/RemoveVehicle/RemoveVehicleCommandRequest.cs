using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace FiloCar.Application.Features.Vehicles.Commands.RemoveVehicle
{
    public class RemoveVehicleCommandRequest : IRequest<Unit>
    {
        public int VehicleId { get; set; }
    }
}
