using Moq;
using Storage.Monopoly.Junior.Models;
using Storage.Monopoly.Junior.Repositories.Interfaces;
using Storage.Monopoly.Junior.Services;

namespace Storage.Monopoly.Junior.Tests.ServiceTests;

public abstract partial class PalletServiceTest
{
    public class PalletServiceRedTest
    {
        [Fact]
        public void AddPalletLessTest()
        {
            // Arrange
            var mock = new Mock<IPalletRepository>();
            mock.Setup(p => p.Add(It.IsAny<Pallet>())).Verifiable();
            PalletService palletService = new(mock.Object);


            // Act
            var errors = palletService.Add(new Pallet
            {

                Length = -1,
                Width = -1,
                Height = -1,
                Weight = -1,
                Boxes =
                [
                    new Box
                    {
                        Height = -1,
                        Length = -1,
                        Width = -1,
                        Weight = -1,
                    }
                ]
            });

            // Assert
            Assert.NotNull(errors);
            var errorList = errors.Select(error => error.ErrorMessage).ToList();
            Assert.Contains("Паллет должен иметь длину не меньше 100 см.", errorList);
            Assert.Contains("Паллет должен иметь ширину не меньше 100 см.", errorList);
            Assert.Contains("Паллет должен иметь высоту не меньше 2 см.", errorList);
            Assert.Contains("Паллет должен иметь вес равный 30 кг.", errorList);

            Assert.Contains("Коробка должна иметь длину не меньше 5 см.", errorList);
            Assert.Contains("Коробка должна иметь ширину не меньше 5 см.", errorList);
            Assert.Contains("Коробка должна иметь высоту не меньше 5 см.", errorList);
            Assert.Contains("Коробка должна иметь вес не меньше 0 кг.", errorList);

        }

        [Fact]
        public void AddPalletGreaterTest()
        {
            // Arrange
            var mock = new Mock<IPalletRepository>();
            mock.Setup(p => p.Add(It.IsAny<Pallet>())).Verifiable();
            PalletService palletService = new(mock.Object);


            // Act
            var errors = palletService.Add(new Pallet
            {

                Length = 250.1,
                Width = 250.1,
                Height = 50.1,
                Weight = 100,
                Boxes =
                [
                    new Box
                    {
                        Length = 250.1,
                        Width = 250.1,
                        Height = 300.1,
                        Weight = 100.1,
                    }
                ]
            });

            // Assert
            Assert.NotNull(errors);
            var errorList = errors.Select(error => error.ErrorMessage).ToList();
            Assert.Contains("Паллет должен иметь длину не больше 250 см.", errorList);
            Assert.Contains("Паллет должен иметь ширину не больше 250 см.", errorList);
            Assert.Contains("Паллет должен иметь высоту не больше 50 cм.", errorList);
            Assert.Contains("Паллет должен иметь вес равный 30 кг.", errorList);

            Assert.Contains("Коробка должна иметь длину не больше 250 см.", errorList);
            Assert.Contains("Коробка должна иметь ширину не больше 250 см.", errorList);
            Assert.Contains("Коробка должна иметь высоту не больше 300 см.", errorList);
            Assert.Contains("Коробка должна иметь вес не больше 100 кг.", errorList);
        }

        [Fact]
        public void AddPalletBoxGreaterThanPalletTest()
        {
            // Arrange
            var mock = new Mock<IPalletRepository>();
            mock.Setup(p => p.Add(It.IsAny<Pallet>())).Verifiable();
            PalletService palletService = new(mock.Object);


            // Act
            var errors = palletService.Add(new Pallet
            {
                Length = 120,
                Width = 120,
                Height = 30,
                Boxes =
                [
                    new Box
                    {
                        Length = 240,
                        Width = 240,
                        Height = 280,
                        Weight = 80,
                    }
                ]
            });

            // Assert
            Assert.NotNull(errors);
            var errorList = errors.Select(error => error.ErrorMessage).ToList();
            Assert.Contains("Коробка должна помещаться на паллет", errorList);
        }
    }
}