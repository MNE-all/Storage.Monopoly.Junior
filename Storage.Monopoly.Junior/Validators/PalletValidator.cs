using FluentValidation;
using Storage.Monopoly.Junior.Models;

namespace Storage.Monopoly.Junior.Validators;

public class PalletValidator : AbstractValidator<Pallet>
{
    public PalletValidator()
    {
        RuleForEach(p => p.Boxes).SetValidator(p => new BoxValidator(p.Width, p.Length));
    }
}
