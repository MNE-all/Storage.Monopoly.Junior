namespace Storage.Monopoly.Junior.Models;

public class Pallet : StandardProperties
{
    public HashSet<Box> Boxes { get; set; } = new();
    // Каждый паллет весит 30 кг.
    public Pallet()
    {
        Weight = 30;
    }
}