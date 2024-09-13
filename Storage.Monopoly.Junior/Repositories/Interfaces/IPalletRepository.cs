using Storage.Monopoly.Junior.Models;

namespace Storage.Monopoly.Junior.Repositories.Interfaces;

public interface IPalletRepository
{
    /// <summary>
    /// Добаление паллета
    /// </summary>
    /// <param name="pallet">Паллет</param>
    public void Add(Pallet pallet);
    /// <summary>
    /// Добаление списка паллетов
    /// </summary>
    /// <param name="pallets">Паллеты</param>
    public void AddRange(HashSet<Pallet> pallets);

    /// <summary>
    /// Получение группированного списка в соответсвии с заданием
    /// </summary>
    /// <returns>Групированный, по датам, список паллетов</returns>
    public Dictionary<DateOnly, List<Pallet>>  GroupAndSortByExpirationDateThanSortByWeight();

    /// <summary>
    /// Получение 3-х паллетов в соответствии с заданием
    /// </summary>
    /// <returns>Список с 3-мя паллетами, которые содержат коробки с наибольшим сроком годности</returns>
    public List<Pallet> GetTop3PalletsWithMaxExpirationDateSortByVolume();
}
