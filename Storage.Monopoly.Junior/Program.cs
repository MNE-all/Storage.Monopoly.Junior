using Storage.Monopoly.Junior.Data;
using Storage.Monopoly.Junior.Data.Generator;
using Storage.Monopoly.Junior.Repositories.Implements;
using Storage.Monopoly.Junior.Repositories.Interfaces;
using Storage.Monopoly.Junior.Services;

// Репозиторий позволяет с легкостью сменить способ хранения данных
IPalletRepository palletRepository = new PalletListRepository();
// Сервис инкапсулирует логику валидации и добавления данных
PalletService palletService = new (palletRepository);

// Input
// Интерфейс ввода данных позволяет с легкостью сменить способ ввода данных
IDataInput input = new DataGenerator();

palletService.AddRange(input.GetPallets());


// Output
TestTaskOutput outputService = new(palletRepository);
outputService.FirstOutput();
Console.WriteLine();
outputService.SecondOutput();



