using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiloCar.Application.Features.Drivers.Command.CreateDriverCommand;
using FiloCar.Domain.Entity;
using FluentValidation;

namespace FiloCar.Application.Features.Drivers.Commands
{
    public class CreateDriverCommandValidator : AbstractValidator<CreateDriverCommandRequest>
    {
        public CreateDriverCommandValidator()
        {
            RuleFor(x => x.DriverId)
                .GreaterThan(0).WithMessage("Driver ID sıfırdan büyük olmalıdır.");

            RuleFor(x => x.DepartmanId)
                .NotNull().WithMessage("Departman ID boş olamaz.")
                .GreaterThan(0).WithMessage("Departman ID sıfırdan büyük olmalıdır.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("İsim boş olamaz.")
                .MaximumLength(50).WithMessage("İsim en fazla 50 karakter olabilir.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyisim boş olamaz.")
                .MaximumLength(50).WithMessage("Soyisim en fazla 50 karakter olabilir.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarası boş olamaz.")
                .Matches(@"^\d{10}$").WithMessage("Telefon numarası 10 haneli rakamlardan oluşmalıdır.");

            RuleFor(x => x.LicenseNumber)
                .NotEmpty().WithMessage("Ehliyet numarası boş olamaz.")
                .MaximumLength(20).WithMessage("Ehliyet numarası en fazla 20 karakter olabilir.");
        }
    }
}
