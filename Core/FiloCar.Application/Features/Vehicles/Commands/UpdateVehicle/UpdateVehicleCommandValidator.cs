using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace FiloCar.Application.Features.Vehicles.Commands.UpdateVehicle
{
    public  class UpdateVehicleCommandValidator  : AbstractValidator<UpdateVehicleCommandRequest>
    {
        public UpdateVehicleCommandValidator() {

            RuleFor(x => x.VehicleId)
                .NotEmpty().WithMessage(" Id is required.")
                .NotNull();
               
            // PlateNumber doğrulaması
            RuleFor(x => x.PlateNumber)
                .NotEmpty().WithMessage("Plate number is required.")
                .Length(5, 15).WithMessage("Plate number must be between 5 and 15 characters.");

            // Brand doğrulaması
            RuleFor(x => x.Brand)
                .NotEmpty().WithMessage("Brand is required.")
                .Length(2, 50).WithMessage("Brand name must be between 2 and 50 characters.");

            // Model doğrulaması
            RuleFor(x => x.Model)
                .NotEmpty().WithMessage("Model is required.")
                .Length(1, 50).WithMessage("Model name must be between 1 and 50 characters.");

            // Year doğrulaması
            RuleFor(x => x.Year)
                .InclusiveBetween(1900, DateTime.Now.Year).WithMessage("Year must be between 1900 and the current year.");

            // Km doğrulaması
            RuleFor(x => x.Km)
                .GreaterThan(0).WithMessage("Kilometers must be greater than 0.");


            // IsActive doğrulaması (varsayılan olarak true, dolayısıyla gereksiz olabilir)
            RuleFor(x => x.IsActive)
                .NotNull().WithMessage("IsActive must be specified.");
        }
    }
}
