using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FiloCar.Application.Exceptions;
using FiloCar.Application.Features.Vehicles.Rules;
using FiloCar.Application.Interface.AutoMapper;
using FiloCar.Application.Interface.Repositories;
using FiloCar.Application.Rules;
using FiloCar.Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FiloCar.Application.Features.MaintenanceRecords.Queries.GetAllWithFilters
{
    public class GetAllWithFiltersHandler : IRequestHandler<GetAllWithFiltersQuery, List<GetAllWithFiltersResponse>>
    {
        private readonly IReadRepository<MaintenanceRecord> _maintenanceaRecordsReadRepository;
        private readonly IMapper _mapper;
        private readonly MaintenanceRecordRules _maintenanceRecordRules;

        public GetAllWithFiltersHandler(IReadRepository<MaintenanceRecord> maintenanceaRecordsReadRepository, IMapper mapper, MaintenanceRecordRules maintenanceRecordRules)
        {
            _maintenanceaRecordsReadRepository = maintenanceaRecordsReadRepository ?? throw new ArgumentNullException(nameof(maintenanceaRecordsReadRepository)); ;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); ; 
            _maintenanceRecordRules = maintenanceRecordRules ?? throw new ArgumentNullException(nameof(maintenanceRecordRules));
        }


        public async Task<List<GetAllWithFiltersResponse>> Handle(GetAllWithFiltersQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                // Filtre koşulu oluşturuluyor
                Expression<Func<MaintenanceRecord, bool>>? predicate = null;

                if (request.MaintenanceDate.HasValue) // filtreleme varsa 
                {
                    predicate = x => x.MaintenanceDate.Date == request.MaintenanceDate.Value.Date;
                }

                var vehicles = await _maintenanceaRecordsReadRepository.GetAllByPagingAsync( // Sayfalandırma
                    predicate: predicate,
                    include: q => q.Include(x => x.Vehicle),
                    enableTracking: false,
                    currentPage: request.PageNumber,
                    pageSize: request.PageSize
                );

                // DTO'ya mapleniyor
                var response = _mapper.Map<List<GetAllWithFiltersResponse>>(vehicles);
                return response;
            }
            catch (Exception ex)
            {
                // Hata loglama yapılabilir burada
                throw new BusinessException("Bakım kayıtları filtrelenirken bir hata oluştu.", ex);
            }
        }

    }
}
