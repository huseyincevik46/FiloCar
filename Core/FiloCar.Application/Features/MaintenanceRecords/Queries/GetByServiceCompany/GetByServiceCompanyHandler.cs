using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiloCar.Application.Exceptions;
using FiloCar.Application.Features.MaintenanceRecords.Queries.GetByIdVehicle;
using FiloCar.Application.Interface.AutoMapper;
using FiloCar.Application.Interface.Repositories;
using FiloCar.Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FiloCar.Application.Features.MaintenanceRecords.Queries.GetByServiceCompany
{
    public class GetByServiceCompanyHandler : IRequestHandler<GetByServiceComapanyQuery, List<GetByServiceCompanyResponse>>
    {
        private readonly IReadRepository<MaintenanceRecord> _maintenanceRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetByServiceCompanyHandler> _logger; 
        public GetByServiceCompanyHandler(IMapper mapper, IReadRepository<MaintenanceRecord> maintenanceRepository, ILogger<GetByServiceCompanyHandler> logger)
        {
            _logger = logger;
            _mapper = mapper;
            _maintenanceRepository = maintenanceRepository;
        }
        public async Task<List<GetByServiceCompanyResponse>> Handle(GetByServiceComapanyQuery request, CancellationToken cancellationToken)
        {
            request.Validate();

            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                var record = await _maintenanceRepository.GetAsync(
                    predicate: x => x.ServiceCompanyName == request.ServiceCompanyName,
                    include: source => source.Include(x => x.Vehicle));

                if (record == null)
                {
                    _logger.LogWarning("Bakım kaydı bulunamadı. ServiceCompanyName: {ServiceCompanyName}", request.ServiceCompanyName);
                    throw new NotFoundException("Araç için bakım kaydı bulunamadı.");
                }

                return _mapper.Map<List<GetByServiceCompanyResponse>>(record);

            }
            catch (NotFoundException nfEx)
            {
                _logger.LogWarning(nfEx, "NotFoundException oluştu.");
                throw new BadRequestException(nfEx.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Beklenmeyen bir hata oluştu. VehicleId: {ServiceCompanyName}", request.ServiceCompanyName);
                throw new BadRequestException("Beklenmeyen bir hata oluştu: " + ex.Message);
            }
        }
    }
}
