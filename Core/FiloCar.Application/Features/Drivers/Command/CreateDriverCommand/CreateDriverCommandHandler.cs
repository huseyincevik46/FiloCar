
using FiloCar.Application.Bases;
using FiloCar.Application.Exceptions;
using FiloCar.Application.Features.Drivers.Rules;
using FiloCar.Application.Interface.AutoMapper;
using FiloCar.Application.Interface.Repositories;
using FiloCar.Application.Interface.UnitOfWorks;
using FiloCar.Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;


namespace FiloCar.Application.Features.Drivers.Command.CreateDriverCommand
{
    public class CreateDriverCommandHandler : BaseHandler, IRequestHandler<CreateDriverCommandRequest, Unit>
    {
        private readonly DriverRules _rules;
        private readonly IReadRepository<Driver> _repo;
        private readonly ILogger<CreateDriverCommandHandler> _logger;
       
        private readonly IUnitOfWork _unitOfWork;

        public CreateDriverCommandHandler(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IReadRepository<Driver> repo,
            ILogger<CreateDriverCommandHandler> logger,
            DriverRules rules,
            IHttpContextAccessor httpContextAccessor
        ) : base(mapper, unitOfWork,httpContextAccessor )
        {
            _repo = repo;
            _logger = logger;
            _rules = rules;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateDriverCommandRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                // İş kurallarını kontrol et
                await _rules.CheckDriverIdNullOrEmpty(request.DriverId);
                await _rules.CheckDriverName(request.FirstName);

                // Eğer böyle bir sürücü zaten var mı kontrolü yapılıyor
                var existingDriver = await _repo.GetAsync(d => d.DriverId == request.DriverId);
                if (existingDriver != null)
                    throw new BusinessException("Bu DriverId ile kayıtlı bir sürücü zaten mevcut.");

                // Mapping
                var commandDriver = _mapper.Map<Driver>(request);

                // Kaydetme
                await _unitOfWork.GetWriteRepository<Driver>().AddAsync(commandDriver);
                await _unitOfWork.SaveAsync();

                return Unit.Value;
            }
            catch (BusinessException ex)
            {
                _logger.LogError(ex, "Business exception occurred while creating driver.");
                throw new Exception(ex.Message);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, "Not found exception occurred while creating driver.");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred while creating driver.");
                throw new Exception("Beklenmeyen bir hata oluştu: " + ex.Message);
            }
        }
    }
}
