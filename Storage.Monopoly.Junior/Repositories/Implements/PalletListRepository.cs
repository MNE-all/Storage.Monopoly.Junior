using Storage.Monopoly.Junior.Models;
using Storage.Monopoly.Junior.Repositories.Interfaces;

namespace Storage.Monopoly.Junior.Repositories.Implements;

public class PalletListRepository : IPalletRepository
{
    private readonly HashSet<Pallet> _pallets = [];
    public void Add(Pallet pallet)
    {
        _pallets.Add(pallet);
    }

    public void AddRange(HashSet<Pallet> pallets)
    {
        foreach (var pallet in pallets)
        {
            _pallets.Add(pallet);
        }
    }
    public Dictionary<DateOnly, List<Pallet>> GroupAndSortByExpirationDateThanSortByWeight()
    {
        Dictionary<DateOnly, List<Pallet>> groupedPallets = new ();

        var list = from Pallet in _pallets
            group Pallet by Pallet.Boxes.Min(box => box.ExpirationDate)
            into palletGroup
            select new { PalletGroup = palletGroup };

        list = list.OrderBy(p => p.PalletGroup.Key);
        foreach (var group in list)
        {
            var orderedGroup = group.PalletGroup.OrderBy(p => (p.Weight + p.Boxes.Sum(b => b.Weight)));
            groupedPallets.Add(group.PalletGroup.Key!.Value, orderedGroup.ToList());
        }

        return groupedPallets;
    }

    public List<Pallet> GetTop3PalletsWithMaxExpirationDateSortByVolume()
    {
        var top3 = _pallets.OrderByDescending(p => p.Boxes.Max(b => b.ExpirationDate)).Take(3);
        top3 = top3.OrderBy(p => p.Boxes.Sum(b => b.Width * b.Height * b.Length) + p.Width * p.Height * p.Length);
        return top3.ToList();
    }
}
