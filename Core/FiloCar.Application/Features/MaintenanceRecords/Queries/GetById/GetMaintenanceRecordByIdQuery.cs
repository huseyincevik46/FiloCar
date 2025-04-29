using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiloCar.Application.Exceptions;
using FiloCar.Domain.Entity;
using MediatR;

namespace FiloCar.Application.Features.MaintenanceRecords.Queries.GetById
{
    public class GetMaintenanceRecordByIdQuery : IRequest<GetMaintenanceRecordByIdResponse>
    {
        public int Id { get; set; }

        public GetMaintenanceRecordByIdQuery(int Id)
        {
            Id = Id;
        }

        public void Validate()
        {
            if (Id <= 0)
                throw new BadRequestException("VehicleId pozitif bir tamsayı olmalıdır.");
        }
    }
    
}
