using Storage.Monopoly.Junior.Models;
using Storage.Monopoly.Junior.Repositories.Implements;
using Storage.Monopoly.Junior.Repositories.Interfaces;

namespace Storage.Monopoly.Junior.Tests.RepositoryTests;

/// <summary>
/// Тестирование репозитория паллетов
/// </summary>
public class PalletListRepositoryTest
{
    private readonly IPalletRepository _palletRepository = new PalletListRepository();

    /// <summary>
    /// Тестировние добавления и групировки с сортировками
    /// </summary>
    [Fact]
    public void GetGroupedPalletsTest()
    {
        // Arrange
        List<Guid> ids = [];
        for (var i = 0; i < 6; i++)
        {
            ids.Add(Guid.NewGuid());
        }

        _palletRepository.Add(new Pallet
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
            _palletRepository.Add(new Pallet
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
            _palletRepository.Add(new Pallet
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
        var result = _palletRepository.GroupAndSortByExpirationDateThanSortByWeight();


        // Assert
        foreach (var pallet in result.Values.SelectMany(res => res))
        {
            Assert.True(pallet.Id == ids[answerIds[currentId++]]);
        }
    }

    [Fact]
    public void GetTop3PalletsTest()
    {
        // Arrange
        List<Guid> ids = [];
        for (var i = 0; i < 6; i++)
        {
            ids.Add(Guid.NewGuid());
        }

        double width = 20.0, height = 20.0, length = 3.0;
        for (var i = 0; i < 3; i++)
        {
            _palletRepository.Add(new Pallet
            {
                Id = ids[2 - i],
                Boxes =
                {
                    new Box
                    {
                        Width = width,
                        Height = height,
                        Length = length,
                        ExpirationDate = DateOnly.FromDateTime(new DateTime(2024, 12, 31)),
                    },
                    new Box
                    {
                        Width = width,
                        Height = height,
                        Length = length,
                        ExpirationDate = DateOnly.FromDateTime(new DateTime(2001, 12, 31)),
                    }
                }
            });
            width *= 1.3;
            height *= 1.3;
            length *= 1.5;
        }

        for (var i = 3; i < 6; i++)
        {
            _palletRepository.Add(new Pallet
            {
                Id = ids[i],
                Boxes =
                {
                    new Box
                    {
                        Width = width,
                        Height = height,
                        Length = length,
                        ExpirationDate = DateOnly.FromDateTime(new DateTime(2023, 12, 31)),
                    },
                    new Box
                    {
                        Width = width,
                        Height = height,
                        Length = length,
                        ExpirationDate = DateOnly.FromDateTime(new DateTime(2001, 12, 31)),
                    }
                }
            });
            width *= 1.5;
            height *= 1.5;
            length *= 2;
        }

        int[] answerIds = [2, 1, 0];
        var currentId = 0;

        // Act 
        var result = _palletRepository.GetTop3PalletsWithMaxExpirationDateSortByVolume();

        // Assert
        foreach (var pallet in result)
        {
            Assert.True(pallet.Id == ids[answerIds[currentId++]]);
        }
    }
}