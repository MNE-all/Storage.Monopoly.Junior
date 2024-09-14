using Storage.Monopoly.Junior.Models;

namespace Storage.Monopoly.Junior.Data.Generator;

public class DataGenerator : IGenerator, IDataInput
{
    private readonly Random _random = new();
    public Box GenerateBox(int width = 250, int height = 300, int depth = 250)
    {
        if (_random.Next(2) == 0)
        {
            return new Box
            {
                Width = Math.Round(_random.NextInt64(5, width - 1) + _random.NextDouble(), 2),
                Height = Math.Round(_random.NextInt64(5, height - 1) + _random.NextDouble(), 2),
                Length = Math.Round(_random.NextInt64(5, depth - 1) + _random.NextDouble()),
                Weight = Math.Round(_random.NextInt64(1, 100)  - _random.NextDouble() + 0.1, 2),
                ExpirationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(_random.Next(1, 180))),

            };
        }

        return new Box
        {
            Width = Math.Round(_random.NextInt64(5, width - 1) + _random.NextDouble(), 2),
            Height = Math.Round(_random.NextInt64(5, height - 1) + _random.NextDouble(), 2),
            Length = Math.Round(_random.NextInt64(5, depth - 1) + _random.NextDouble(), 2),
            Weight = Math.Round(_random.NextInt64(1, 100) - _random.NextDouble() + 0.1, 2),
            PackingDate = DateOnly.FromDateTime(new DateTime(2000, 1, 1).AddDays((_random.Next(1, 8760)))),
        };
    }

    public Pallet GeneratePallet()
    {
        return new Pallet
        {
            Width = Math.Round(_random.NextInt64(100, 249) + _random.NextDouble(), 2),
            Height = Math.Round(_random.NextInt64(2, 19) + _random.NextDouble(), 2),
            Length = Math.Round(_random.NextInt64(100, 249) + _random.NextDouble(), 2)
        };
    }

    public Pallet GeneratePalletWithBoxes()
    {
        var pallet = GeneratePallet();

        for (int i = 0; i < _random.Next(1, 20); i++)
        {
            pallet.Boxes.Add(GenerateBox((int)pallet.Width, depth: (int)pallet.Length));
        }

        return pallet;
    }

    public HashSet<Pallet> GeneratePalletsWithBoxes(int amount)
    {
        HashSet<Pallet> pallets = [];
        for (int i = 0; i < amount; i++)
        {
            pallets.Add(GeneratePalletWithBoxes());
        }
        return pallets;
    }

    public HashSet<Pallet> GetPallets() => GeneratePalletsWithBoxes(99999);
}
