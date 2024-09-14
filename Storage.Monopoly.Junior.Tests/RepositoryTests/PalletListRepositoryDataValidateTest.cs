using Storage.Monopoly.Junior.Models;

namespace Storage.Monopoly.Junior.Tests.RepositoryTests;

public partial class PalletListRepositoryTest
{
    /// <summary>
    /// Тестировние добавления и групировки с сортировками
    /// </summary>
    [Fact]
    public void PalletAddRules()
    {
        _palletRepository.Add(
            new Pallet
            {
                Width = -10,
                Height = -56,
                Length = -54,
                Weight = -8,
                
            });
        
        
    }
}