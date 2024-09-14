using FluentValidation;
using Storage.Monopoly.Junior.Models;

namespace Storage.Monopoly.Junior.Validators;

public class BoxValidator : AbstractValidator<Box>
{
    public BoxValidator()
    {
        RuleFor(box => box.Length).NotNull().NotEmpty()
            .GreaterThanOrEqualTo(5).WithMessage("Коробка должна иметь длину не меньше 5 см.")
            .LessThanOrEqualTo(250).WithMessage("Коробка должна иметь длину не больше 250 см.");
        RuleFor(box => box.Width).NotNull().NotEmpty()
            .GreaterThanOrEqualTo(5).WithMessage("Коробка должна иметь ширину не меньше 5 см.")
            .LessThanOrEqualTo(250).WithMessage("Коробка должна иметь ширину не больше 250 см.");
        RuleFor(box => box.Height).NotNull().NotEmpty()
            .GreaterThanOrEqualTo(5).WithMessage("Коробка должна иметь высоту не меньше 5 см.")
            .LessThanOrEqualTo(300).WithMessage("Коробка должна иметь высоту не больше 300 см.");
        RuleFor(box => box.Weight).NotNull().NotEmpty()
            .GreaterThanOrEqualTo(0).WithMessage("Коробка должна иметь вес не меньше 0 кг.")
            .LessThanOrEqualTo(100).WithMessage("Коробка должна иметь вес не больше 100 кг.");
    }

    public BoxValidator(double width, double length) : this()
    {
        RuleFor(b => b)
            .Must(b => (b.Width <= width && b.Length <= length) || (b.Width <= length && b.Length <= width))
            .WithMessage("Коробка должна помещаться на паллет");
    }

}
