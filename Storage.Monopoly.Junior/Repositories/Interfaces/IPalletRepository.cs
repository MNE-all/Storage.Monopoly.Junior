using Storage.Monopoly.Junior.Models;

namespace Storage.Monopoly.Junior.Repositories.Interfaces;

public interface IPalletRepository
{
    public void Add(Pallet pallet);
    public void AddRange(HashSet<Pallet> pallets);
    
    public Dictionary<DateOnly, List<Pallet>>  GroupAndSortByExpirationDateThanSortByWeight();
    public List<Pallet> GetTop3PalletsWithMaxExpirationDateSortByVolume();
}