using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiloCar.Application.Bases;
using FiloCar.Application.Exceptions;
using FiloCar.Application.Interface.Repositories;
using FiloCar.Domain.Entity;

namespace FiloCar.Application.Features.Drivers.Rules
{
    public class DriverRules : BaseRules

    {
        private readonly IReadRepository<Driver> _driverRepository;

        public Task CheckDriverIdNullOrEmpty( int driverId)
        {
            if(driverId <=0)
            {
                throw new BusinessException("driver ID must be greater than zero.");
            }
            return Task.CompletedTask;
        }
        public async Task CheckDriverExists(int driverId)
        {
            var driver = await _driverRepository.GetAsync(x=>x.DriverId == driverId);
            if (driver == null)
                throw new BusinessException("Böyle bir sürücü bulunamadı.");
        }


        public Task CheckDriverName(string driverName)
        {
            if (string.IsNullOrEmpty(driverName))
            {
                throw new BusinessException("Driver name cannot be null or empty.");
            }
            return Task.CompletedTask;
        }

        public Task CheckDepartmanId(int departmanId)
        {
            if (departmanId <= 0)
            {
                throw new BusinessException("Departman ID must be greater than zero.");
            }
            return Task.CompletedTask;
        }
    }
}
