using FluentValidation;
using Storage.Monopoly.Junior.Models;

namespace Storage.Monopoly.Junior.Validators;

public class PalletValidator : AbstractValidator<Pallet>
{
    public PalletValidator()
    {
        RuleFor(p => p.Length).NotNull().NotEmpty()
            .GreaterThanOrEqualTo(100).WithMessage("Паллет должен иметь длину не меньше 100 см.")
            .LessThanOrEqualTo(250).WithMessage("Паллет должен иметь длину не больше 250 см.");
        RuleFor(p => p.Width).NotNull().NotEmpty()
            .GreaterThanOrEqualTo(100).WithMessage("Паллет должен иметь ширину не меньше 100 см.")
            .LessThanOrEqualTo(250).WithMessage("Паллет должен иметь ширину не больше 250 см.");
        RuleFor(p => p.Height).NotNull().NotEmpty()
            .GreaterThanOrEqualTo(2).WithMessage("Паллет должен иметь высоту не меньше 2 см.")
            .LessThanOrEqualTo(50).WithMessage("Паллет должен иметь высоту не больше 50 cм.");
        RuleFor(p => p.Weight).NotNull().NotEmpty()
            .Equal(30).WithMessage("Паллет должен иметь вес равный 30 кг.");
        RuleForEach(p => p.Boxes).SetValidator(p => new BoxValidator(p.Width, p.Length));
    }
}
