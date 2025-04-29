
using FiloCar.Application.Bases;
using FiloCar.Application.Features.Vehicles.Rules;
using FiloCar.Application.Interface.AutoMapper;
using FiloCar.Application.Interface.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Http;
using FiloCar.Domain.Entity;
using System.Runtime.InteropServices;
using FiloCar.Application.Features.Vehicles.Exceptions;

namespace FiloCar.Application.Features.Vehicles.Commands.CreateVehicle
{
    public class CreateVehicleCommandHandler : BaseHandler, IRequestHandler<CreateVehicleCommandRequest, Unit>
    {
        private readonly VehicleRules _vehicleRules;

        public CreateVehicleCommandHandler(VehicleRules vehicleRules, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
            : base(mapper, unitOfWork, httpContextAccessor)
        {
            _vehicleRules = vehicleRules;
        }

        public async Task<Unit> Handle(CreateVehicleCommandRequest request, CancellationToken cancellationToken)
        {
            var vehicles = await _unitOfWork.GetReadRepository<Vehicle>().GetAllAsync(); // ünitOfWork'ten okuma repository'sini alıyoruz. Veritabanındaki tüm araçları alıyoruz.

            await _vehicleRules.VehiclePlateNumber(vehicles, request.PlateNumber); // Araç plaka numarasının kurallara uygun olup olmadığını kontrol ediyoruz.

            var vehicle = _mapper.Map<Vehicle>(request); // İsteği araç nesnesine dönüştürüyoruz. 
            vehicle.AddTime = DateTime.UtcNow; // Araç nesnesinin oluşturulma tarihini ayarlıyoruz.
            await _unitOfWork.GetWriteRepository<Vehicle>().AddAsync(vehicle); // Araç nesnesini yazma repository'sine ekliyoruz.

            var saveResult = await _unitOfWork.SaveAsync();

            if (saveResult > 0)
            {
                return Unit.Value;
            }

            throw new VehiclePlateNumberException("Vehicle could not be created");

        }
        

    }
}
