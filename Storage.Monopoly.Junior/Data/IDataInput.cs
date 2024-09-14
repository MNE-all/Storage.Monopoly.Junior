using Storage.Monopoly.Junior.Models;

namespace Storage.Monopoly.Junior.Data;

/// <summary>
/// Интерфейс для упрощения последующей смены способа ввода
/// </summary>
public interface IDataInput
{
    /// <summary>
    /// Получить список паллетов
    /// </summary>
    /// <returns>Список паллетов</returns>
    public HashSet<Pallet> GetPallets();
}
