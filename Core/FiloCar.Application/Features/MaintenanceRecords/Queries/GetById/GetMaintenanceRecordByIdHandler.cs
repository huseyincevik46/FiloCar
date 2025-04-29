

using FiloCar.Application.Exceptions;
using FiloCar.Application.Features.Vehicles.Queries.GetById;
using FiloCar.Application.Features.Vehicles.Rules;
using FiloCar.Application.Interface.AutoMapper;
using FiloCar.Application.Interface.Repositories;
using FiloCar.Application.Rules;
using FiloCar.Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FiloCar.Application.Features.MaintenanceRecords.Queries.GetById
{
    public class GetMaintenanceRecordByIdHandler : IRequestHandler<GetMaintenanceRecordByIdQuery, GetMaintenanceRecordByIdResponse>
    {
        private readonly IReadRepository<MaintenanceRecord> _maintenanceRecord;
        private readonly IMapper _mapper;
        private readonly MaintenanceRecordRules _maintenanceRecordRules;

        public GetMaintenanceRecordByIdHandler(IReadRepository<MaintenanceRecord> maintenanceRecord, IMapper mapper, MaintenanceRecordRules maintenanceRecordRules)
        {
            _maintenanceRecord = maintenanceRecord;
            _mapper = mapper;
            _maintenanceRecordRules = maintenanceRecordRules;
        }

        public async Task<GetMaintenanceRecordByIdResponse> Handle(GetMaintenanceRecordByIdQuery request, CancellationToken cancellationToken)
        {

            // Doğrulama
            request.Validate();

            // İptal kontrolü
            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                // Kayıtları al
                var record = await _maintenanceRecord.GetAsync(
                predicate: x => x.Id == request.Id,
                include: source => source.Include(x => x.Vehicle));

                // Kural kontrolü – aracın olup olmadığını kontrol et
                await _maintenanceRecordRules.VehicleShouldExistWhenSelected(record.Vehicle);

                // DTO'ya maplenip geri dönülüyor – sadece aracı dön
                return _mapper.Map<GetMaintenanceRecordByIdResponse>(record);


            }
            catch (NotFoundException nfEx)
            {
                // Kural ihlali için özel bir durum
                throw new BadRequestException(nfEx.Message);
            }
            catch (Exception ex)
            {
                // Beklenmedik bir hata varsa
                throw new BadRequestException("Beklenmeyen bir hata oluştu: " + ex.Message);
            }

        }
    }

}
