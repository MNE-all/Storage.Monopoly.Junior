using Storage.Monopoly.Junior.Models;
using Storage.Monopoly.Junior.Repositories.Implements;
using Storage.Monopoly.Junior.Repositories.Interfaces;

namespace Storage.Monopoly.Junior.Tests;

/// <summary>
/// Тестирование репозитория паллетов
/// </summary>
public class PalletListRepositoryTest
{
    /// <summary>
    /// Тестировние добавления и групировки с сортировками
    /// </summary>
    [Fact]
    public void GetGroupedPalletsTest()
    {
        // Arrange
        IPalletRepository palletRepository = new PalletListRepository();
        List<Guid> ids = [];
        for (var i = 0; i < 6; i++)
        {
            ids.Add(Guid.NewGuid());
        }

        palletRepository.Add(new Pallet
        {
            Id = ids[5],
            Boxes =
            {
                new Box
                {
                    ExpirationDate = DateOnly.FromDateTime(new DateTime(2025, 12, 31)),
                },
            }
        });

        var weight = 25.0;
        for (var i = 3; i < 5; i++)
        {
            palletRepository.Add(new Pallet
            {
                Id = ids[i],
                Boxes =
                {
                    new Box
                    {
                        Weight = weight,
                        ExpirationDate = DateOnly.FromDateTime(new DateTime(2024, 12, 31)),
                    },
                }
            });
            weight -= 0.01;
        }

        weight = 25.0;
        for (var i = 0; i < 3; i++)
        {
            palletRepository.Add(new Pallet
            {
                Id = ids[i],
                Boxes =
                {
                    new Box
                    {
                        Weight = weight,
                        ExpirationDate = DateOnly.FromDateTime(new DateTime(2020, 12, 31)),
                    }
                }
            });
            weight -= 4.4;
        }


        int[] answerIds = [2, 1, 0, 4, 3, 5];
        var currentId = 0;


        // Act 
        var result = palletRepository.GroupAndSortByExpirationDateThanSortByWeight();


        // Assert
        foreach (var pallet in result.Values.SelectMany(res => res))
        {
            Assert.True(pallet.Id == ids[answerIds[currentId++]]);
        }
    }
}