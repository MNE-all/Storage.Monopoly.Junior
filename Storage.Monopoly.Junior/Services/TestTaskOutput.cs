using Storage.Monopoly.Junior.Repositories.Interfaces;

namespace Storage.Monopoly.Junior.Services;

public class TestTaskOutput(IPalletRepository palletRepository)
{
    private IPalletRepository PalletRepository { get; set; } = palletRepository;


    public void FirstOutput()
    {
        var answer1 = PalletRepository.GroupAndSortByExpirationDateThanSortByWeight();

        foreach (var palletGroup in answer1)
        {
            Console.WriteLine($"Дата окончания срока годности: {palletGroup.Key}");
            foreach (var pallet in palletGroup.Value)
            {
                Console.WriteLine($"\t" +
                                  $"Паллет \t" +
                                  $"id: {pallet.Id}   " +
                                  $"Вес: {Math.Round(pallet.Boxes.Sum(b => b.Weight) + pallet.Weight, 2)} \t" +
                                  $"Количество коробок: {pallet.Boxes.Count}");
            }
        }
    }

    public void SecondOutput()
    {
        var answer2 = PalletRepository.GetTop3PalletsWithMaxExpirationDateSortByVolume();

        foreach (var pallet in answer2)   
        {
            Console.WriteLine($"Паллет \t" +
                              $"id: {pallet.Id}   " +
                              $"ширина/высота/глубина: {pallet.Width} / {pallet.Height} / {pallet.Length} \t" +
                              $"Вес: {Math.Round(pallet.Boxes.Sum(b => b.Weight) + pallet.Weight, 2)} \t" +
                              $"Количество коробок: {pallet.Boxes.Count} \t" +
                              $"Наибольший срок годности коробки: {pallet.Boxes.Max(b => b.ExpirationDate)} \t" +
                              $"Наименьший срок годности коробки: {pallet.Boxes.Min(b => b.ExpirationDate)} \t");
    
        }
    }
}