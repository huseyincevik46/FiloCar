
using FiloCar.Application.Bases;
using FiloCar.Application.Exceptions;
using FiloCar.Application.Features.Vehicles.Exceptions;
using FiloCar.Domain.Entity;

namespace FiloCar.Application.Features.Vehicles.Rules
{
    public class VehicleRules : BaseRules
    {
        // Vehicle plate number must be unique
        public Task VehiclePlateNumber(IList<Vehicle> vehicles, string plateNumber)

        {
            if (vehicles.Any(x => x.PlateNumber == plateNumber)) throw new VehiclePlateNumberException();
            return Task.CompletedTask;
        }

        public Task VehicleShouldExistWhenSelected(Vehicle vehicle)
        {
            if (vehicle == null)
                throw new NotFoundException("Vehicle not found.");
            return Task.CompletedTask;
        }
    }
    
}
