namespace Storage.Monopoly.Junior.Models;

public class Box : StandardProperties
{
    private readonly DateOnly? _packingDate;

    /// <summary>
    /// Дата упаковки
    /// </summary>
    public DateOnly? PackingDate
    {
        get => _packingDate;
        init
        {
            ExpirationDate = value?.AddDays(100);
            _packingDate = value;
        }
    }

    /// <summary>
    /// Дата окончания срока годности
    /// </summary>
    public DateOnly? ExpirationDate { get; init; }
}