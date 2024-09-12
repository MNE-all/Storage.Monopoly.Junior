using Storage.Monopoly.Junior.Data.Generator;
using Storage.Monopoly.Junior.Repositories.Implements;
using Storage.Monopoly.Junior.Repositories.Interfaces;
using Storage.Monopoly.Junior.Services;

// Domain-Model Layer
IPalletRepository palletRepository = new PalletRepository();

// Input 
DataGenerator dataGenerator = new ();
palletRepository.AddRange(dataGenerator.GeneratePalletsWithBoxes(1500));


// Output
TestTaskOutput outputService = new(palletRepository);
outputService.FirstOutput();
Console.WriteLine();
outputService.SecondOutput();



