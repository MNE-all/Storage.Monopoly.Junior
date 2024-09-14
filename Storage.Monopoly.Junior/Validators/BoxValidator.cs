using FluentValidation;
using Storage.Monopoly.Junior.Models;

namespace Storage.Monopoly.Junior.Validators;

public class BoxValidator : AbstractValidator<Box>
{
    public BoxValidator()
    {
        RuleFor(box => box.Id).NotEmpty().WithMessage("Box id cannot be empty");
    }

    public BoxValidator(double width, double length) : base()
    {
        RuleFor(b => b)
            .Must(b => (b.Width <= width && b.Length <= length) || (b.Width <= length && b.Length <= width))
            .WithMessage("Коробка должна помещаться на паллет");
    }

}
