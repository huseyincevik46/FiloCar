using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiloCar.Application.Exceptions;
using MediatR;

namespace FiloCar.Application.Features.MaintenanceRecords.Queries.GetByIdVehicle
{
    public class GetByIdVehicleQuery : IRequest<GetByIdVehicleResponse>
    {

        public int VehicleId { get; set; }

        public GetByIdVehicleQuery(int vehicleId)
        {
            VehicleId = vehicleId;
        }

        public void Validate()
        {
            if (VehicleId <= 0)
                throw new BadRequestException("VehicleId pozitif bir tamsayı olmalıdır.");
        }
    }
}
