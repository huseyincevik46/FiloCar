
using FiloCar.Application.Bases;
using FiloCar.Application.Exceptions;
using FiloCar.Application.Interface.AutoMapper;
using FiloCar.Application.Interface.UnitOfWorks;
using FiloCar.Application.Rules;
using FiloCar.Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace FiloCar.Application.Features.MaintenanceRecords.Command.CreateCommandRecord
{
    public class CreateMaintenanceRecordHandler : BaseHandler , IRequestHandler<CreateMaintenanceRecordRequest, Unit>
    {
        private readonly MaintenanceRecordRules _rules;

        public CreateMaintenanceRecordHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, MaintenanceRecordRules rules) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _rules = rules;
        }

      
        public async Task<Unit> Handle(CreateMaintenanceRecordRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // Kuralları kontrol etme
                var vehicle = await _unitOfWork.GetReadRepository<Vehicle>().GetAsync(x => x.VehicleId == request.VehicleId);
                await _rules.VehicleShouldExistWhenSelected(vehicle); // vehicleId kontrolü
                await _rules.MaintenanceDateCannotBeInFuture(request.MaintenanceDate); // tarih kontrolü

                // Mapleme
                var commandRecord = _mapper.Map<MaintenanceRecord>(request);

                // Kayıt işlemi
                await _unitOfWork.GetWriteRepository<MaintenanceRecord>().AddAsync(commandRecord);
                await _unitOfWork.SaveAsync();

                return Unit.Value;
            }
            catch (BusinessException ex)
            {
                // İş kurallarına dair exception'lar
                throw new BusinessException(ex.Message); // veya: return Result.Failure(ex.Message);
            }
            catch (NotFoundException ex)
            {
                // Özel not found hatası
                throw new NotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                // Diğer tüm hatalar (loglanabilir)
                throw new Exception("Beklenmeyen bir hata oluştu: " + ex.Message);
            }


        }
    }
   
}
