﻿
using FiloCar.Application.Bases;
using FiloCar.Application.Exceptions;
using FiloCar.Application.Features.Vehicles.Commands.CreateVehicle;
using FiloCar.Application.Interface.AutoMapper;
using FiloCar.Application.Interface.UnitOfWorks;
using FiloCar.Domain.Common;
using FiloCar.Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace FiloCar.Application.Features.Vehicles.Commands.UpdateVehicle
{
    public class UpdateVehicleCommandHandler : BaseHandler, IRequestHandler<UpdateVehicleCommandRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateVehicleCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _unitOfWork = unitOfWork; // UnitOfWork nesnesini alıyoruz.
        }

        public async Task<Unit> Handle(UpdateVehicleCommandRequest request, CancellationToken cancellationToken)
        {
            var vehicle = await _unitOfWork.GetReadRepository<Vehicle>()
                .GetAsync(x => x.VehicleId == request.VehicleId && x.IsActive == true); // Araç ID'sine göre aracı buluyoruz. Eğer araç aktif değilse veya bulunamazsa null dönecek.

            if (vehicle == null)
                throw new NotFoundException("Vehicle not found."); // Araç bulunamazsa hata fırlatıyoruz.

            // Mevcut entity üzerine mapleme (AutoMapper bu overload'u destekler)
            _mapper.Map(request, vehicle);

            await _unitOfWork.GetWriteRepository<Vehicle>().UpdateAsync(vehicle); // Güncellenmiş entity'yi yazma repository'sine ekliyoruz.
            await _unitOfWork.SaveAsync(); // Değişiklikleri kaydediyoruz.

            return Unit.Value;
        }

    }
}


