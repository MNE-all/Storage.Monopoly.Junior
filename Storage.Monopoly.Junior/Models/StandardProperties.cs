using System.ComponentModel.DataAnnotations;

namespace Storage.Monopoly.Junior.Models;

public abstract class StandardProperties
{
    public Guid Id { get; set; } = Guid.NewGuid();
    /// <summary>
    /// Ширина
    /// </summary>
    /// <remarks>
    /// Данные указываются в сантиметрах
    /// </remarks>
    [Range(0.1, 1000)]
    public double Width { get; set; }
    /// <summary>
    /// Длина
    /// </summary>
    /// <remarks>
    /// Данные указываются в сантиметрах
    /// </remarks>
    [Range(0.1, 1000)]
    public double Length { get; set; }
    /// <summary>
    /// Высота
    /// </summary>
    /// <remarks>
    /// Данные указываются в сантиметрах
    /// </remarks>
    [Range(0.1, 1000)]
    public double Height { get; set; }
    /// <summary>
    /// Вес
    /// </summary>
    /// <remarks>
    /// Данные указываются в килограммах
    /// </remarks>
    [Range(0.1, 100)]
    public double Weight { get; set; }
}
