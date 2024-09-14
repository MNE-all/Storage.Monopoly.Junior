using FluentValidation.Results;
using Storage.Monopoly.Junior.Models;
using Storage.Monopoly.Junior.Repositories.Interfaces;
using Storage.Monopoly.Junior.Validators;

namespace Storage.Monopoly.Junior.Services;

public class PalletService(IPalletRepository palletRepository)
{
    public void AddRange(HashSet<Pallet> pallets)
    {
        foreach (var failure in pallets.Select(Add).OfType<List<ValidationFailure>>().SelectMany(errors => errors))
        {
            Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " +
                              failure.ErrorMessage);
        }
    }

    public List<ValidationFailure>? Add(Pallet pallet)
    {
        PalletValidator validator = new();
        ValidationResult result = validator.Validate(pallet);
        if (result.IsValid)
        {
            palletRepository.Add(pallet);
        }
        else
        {
            return result.Errors;
        }
        return null;
    }
}
