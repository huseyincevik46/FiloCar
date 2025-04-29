using FluentValidation;

using FiloCar.Application.Features.MaintenanceRecords.Command.CreateCommandRecord;
public class CreateMaintenaceRecordValidator : AbstractValidator<CreateMaintenanceRecordRequest>
{
    public CreateMaintenaceRecordValidator()
    {
        RuleFor(x => x.VehicleId)
            .GreaterThan(0).WithMessage("Vehicle ID must be greater than 0.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(250).WithMessage("Description cannot be longer than 250 characters.");

        RuleFor(x => x.MaintenanceDate)
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Maintenance date cannot be in the future.");

        RuleFor(x => x.Cost)
            .GreaterThanOrEqualTo(0).WithMessage("Cost must be non-negative.");

        RuleFor(x => x.KmAtMaintenance)
            .GreaterThan(0).WithMessage("Kilometer at maintenance must be greater than 0.");

        RuleFor(x => x.ServiceCompanyName)
            .MaximumLength(100).WithMessage("Service company name cannot exceed 100 characters.")
            .When(x => !string.IsNullOrEmpty(x.ServiceCompanyName));
    }
}
