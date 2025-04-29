using System;
using System.Collections.Generic;
using System.Linq;

using FiloCar.Application.Exceptions;
using FiloCar.Application.Features.Drivers.Exceptions;
using FiloCar.Application.Interface.UnitOfWorks;
using FiloCar.Domain.Entity;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FiloCar.Application.Features.Drivers.Command.RemoveDriverCommand
{
    public class RemoveDriverHandler : IRequestHandler<RemoveDriverRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RemoveDriverHandler> _logger;
        public RemoveDriverHandler(IUnitOfWork unitOfWork, ILogger<RemoveDriverHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(RemoveDriverRequest request, CancellationToken cancellationToken)
        {

            try
            {
                // veritabanında sürücü arama
                var driver = await _unitOfWork.GetReadRepository<Driver>().GetAsync(x => x.DriverId == request.DriverId);

                // nullsa null ve hata gönder
                if (driver == null) 
                {
                    _logger.LogError("Driver not found with id: {DriverId}", request.DriverId);
                    throw new Exception("Driver not found");
                }
                // sürücü false ise hata fırlat
                if(driver.IsActive == false) 
                {
                    _logger.LogError("Driver with ID {DriverId} is already deactivated.", request.DriverId);
                    throw new Exception("Driver is already deactivated");
                }

                // sürücüyü false çek
                driver.IsActive = false;

                // Driverı güncelle
                await _unitOfWork.GetWriteRepository<Driver>().UpdateAsync(driver);
                // işlemi kaydet
                await _unitOfWork.SaveAsync();
                _logger.LogInformation($"Driver with ID {request.DriverId} has been deactivated successfully.");

                return Unit.Value;
            }
            catch (DriverException ex)
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
           
    

