using Storage.Monopoly.Junior.Models;

namespace Storage.Monopoly.Junior.Data.Generator;

public interface IGenerator
{
    public Box GenerateBox(int width, int height, int depth);
    public Pallet GeneratePallet();
    public Pallet GeneratePalletWithBoxes();
    public HashSet<Pallet> GeneratePalletsWithBoxes(int amount);
}