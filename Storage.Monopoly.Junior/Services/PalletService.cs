using FluentValidation.Results;
using Storage.Monopoly.Junior.Models;
using Storage.Monopoly.Junior.Repositories.Interfaces;
using Storage.Monopoly.Junior.Validators;

namespace Storage.Monopoly.Junior.Services;

public class PalletService(IPalletRepository palletRepository)
{
    public void AddRange(HashSet<Pallet> pallets)
    {
        PalletValidator validator = new();

        foreach (var pallet in pallets)
        {
            ValidationResult result = validator.Validate(pallet);
            if (result.IsValid)
            {
                palletRepository.Add(pallet);
            }
            else
            {
                foreach(var failure in result.Errors)
                {
                    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
            }
        }
    }
}
