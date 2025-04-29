using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiloCar.Application.Bases;
using FiloCar.Application.Exceptions;
using FiloCar.Application.Interface.AutoMapper;
using FiloCar.Application.Interface.UnitOfWorks;
using FiloCar.Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace FiloCar.Application.Features.Vehicles.Commands.RemoveVehicle
{
    public class RemoveVehicleCommandHandler : BaseHandler, IRequestHandler<RemoveVehicleCommandRequest, Unit>
    {
        public RemoveVehicleCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
            : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(RemoveVehicleCommandRequest request, CancellationToken cancellationToken)
        {
            var vehicle = await _unitOfWork.GetReadRepository<Vehicle>().GetAsync(x => x.VehicleId == request.VehicleId);

            if (vehicle == null)
                throw new NotFoundException("Araç bulunamadı.");

            if (vehicle.IsActive)
            {
                vehicle.IsActive = false;

                await _unitOfWork.GetWriteRepository<Vehicle>().UpdateAsync(vehicle);
                await _unitOfWork.SaveAsync();
            }

            return Unit.Value;
        }
    }

}
