using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiloCar.Application.Bases;
using FiloCar.Application.Exceptions;
using FiloCar.Application.Features.MaintenanceRecords.Queries.GetById;
using FiloCar.Application.Interface.AutoMapper;
using FiloCar.Application.Interface.Repositories;
using FiloCar.Application.Rules;
using FiloCar.Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FiloCar.Application.Features.MaintenanceRecords.Queries.GetByIdVehicle
{
    public class GetByIdVehicleHandler : IRequestHandler<GetByIdVehicleQuery, GetByIdVehicleResponse>
    {
        private readonly IReadRepository<MaintenanceRecord> _maintenanceRecord; 
        private readonly IMapper _mapper;
        private readonly ILogger<GetByIdVehicleHandler> _logger; // << BURASI

        public GetByIdVehicleHandler(IReadRepository<MaintenanceRecord> maintenanceRecord, IMapper mapper, ILogger<GetByIdVehicleHandler> logger)
        {
            _maintenanceRecord = maintenanceRecord;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GetByIdVehicleResponse> Handle(GetByIdVehicleQuery request, CancellationToken cancellationToken)
        {
            request.Validate();

            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                

                var record = await _maintenanceRecord.GetAsync(
                    predicate: x => x.VehicleId == request.VehicleId,
                    include: source => source.Include(x => x.Vehicle));

                if (record == null)
                {
                    _logger.LogWarning("Bakım kaydı bulunamadı. VehicleId: {VehicleId}", request.VehicleId); 
                    throw new NotFoundException("Araç için bakım kaydı bulunamadı.");
                }

               

                return _mapper.Map<GetByIdVehicleResponse>(record);
            }
            catch (NotFoundException nfEx)
            {
                _logger.LogWarning(nfEx, "NotFoundException oluştu."); 
                throw new BadRequestException(nfEx.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Beklenmeyen bir hata oluştu. VehicleId: {VehicleId}", request.VehicleId);
                throw new BadRequestException("Beklenmeyen bir hata oluştu: " + ex.Message);
            }
        }
    }


}
