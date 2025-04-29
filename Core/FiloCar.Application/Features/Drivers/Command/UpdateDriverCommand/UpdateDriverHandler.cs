using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiloCar.Application.Exceptions;
using FiloCar.Application.Features.Drivers.Exceptions;
using FiloCar.Application.Interface.UnitOfWorks;
using FiloCar.Domain.Entity;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FiloCar.Application.Features.Drivers.Command.UpdateDriverCommand
{
    public  class UpdateDriverHandler : IRequestHandler<UpdateDriverRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateDriverHandler> _logger;
        public async Task<Unit> Handle(UpdateDriverRequest request, CancellationToken cancellationToken)
        {

            try
            {
                var driver = await _unitOfWork.GetReadRepository<Driver>().GetAsync(x => x.DriverId == request.DriverId);

                if (driver == null)
                {
                    _logger.LogError("Driver not found with id: {DriverId}", request.DriverId);
                    throw new Exception("Driver not found");
                }

                driver.DriverId = request.DriverId;
                driver.FirstName = request.FirstName;
                driver.LastName = request.LastName;
                driver.FullName = request.FullName;
                driver.IsActive = request.IsActive;
                driver.DepartmanId = request.DepartmanId;
                driver.LicenseNumber = request.LicenseNumber;
                driver.PhoneNumber = request.PhoneNumber;

                if (request.DepartmanId.HasValue)
                {
                    driver.DepartmanId = request.DepartmanId.Value;
                }

                await _unitOfWork.GetWriteRepository<Driver>().UpdateAsync(driver);
                await _unitOfWork.SaveAsync();

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
