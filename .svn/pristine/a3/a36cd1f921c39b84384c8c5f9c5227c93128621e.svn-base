

using FiloCar.Application.Bases;
using FiloCar.Application.Exceptions;
using FiloCar.Domain.Entity;

namespace FiloCar.Application.Rules
    {
        public class MaintenanceRecordRules : BaseRules
        {
            // 1. Vehicle mevcut mu
            public Task VehicleShouldExistWhenSelected(Vehicle? vehicle)
            {
                if (vehicle == null)
                    throw new NotFoundException("Vehicle not found.");
                return Task.CompletedTask;
            }

            // 2. Gelecekteki bir tarihe bakım kaydı olamaz
            public Task MaintenanceDateCannotBeInFuture(DateTime maintenanceDate)
            {
                if (maintenanceDate > DateTime.Now)
                    throw new BusinessException("Maintenance date cannot be in the future.");
                return Task.CompletedTask;
            }

            // 3. Km sıfırdan büyük olmalı
            public Task KmShouldBeGreaterThanZero(int km)
            {
                if (km <= 0)
                    throw new BusinessException("Kilometer at maintenance must be greater than zero.");
                return Task.CompletedTask;
            }

            // 4. Servis ismi çok uzun olamaz
            public Task ServiceCompanyNameMaxLength(string? serviceCompanyName)
            {
                if (!string.IsNullOrEmpty(serviceCompanyName) && serviceCompanyName.Length > 100)
                    throw new BusinessException("Service company name must be 100 characters or less.");
                return Task.CompletedTask;
            }
        }
    }


