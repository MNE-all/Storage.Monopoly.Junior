using Moq;
using Storage.Monopoly.Junior.Models;
using Storage.Monopoly.Junior.Repositories.Interfaces;
using Storage.Monopoly.Junior.Services;

namespace Storage.Monopoly.Junior.Tests.ServiceTests;

public abstract partial class PalletServiceTest
{
    public class PalletServiceGreenTest
    {
        [Fact]
        public void AddPalletLessEdgeTest()
        {
            // Arrange
            var mock = new Mock<IPalletRepository>();
            mock.Setup(p => p.Add(It.IsAny<Pallet>())).Verifiable();
            PalletService palletService = new(mock.Object);
            
            // Act
            var errors = palletService.Add(new Pallet
            {

                Length = 100,
                Width = 100,
                Height = 2,
                Boxes =
                [
                    new Box
                    {
                        Height = 5,
                        Length = 5,
                        Width = 5,
                        Weight = 0.01,
                    }
                ]
            });

            // Assert
            Assert.Null(errors);
        }
        
        [Fact]
        public void AddPalletGreaterEdgeTest()
        {
            // Arrange
            var mock = new Mock<IPalletRepository>();
            mock.Setup(p => p.Add(It.IsAny<Pallet>())).Verifiable();
            PalletService palletService = new(mock.Object);
            
            // Act
            var errors = palletService.Add(new Pallet
            {
                Length = 250,
                Width = 250,
                Height = 50,
                Boxes =
                [
                    new Box
                    {
                        Length = 250,
                        Width = 250,
                        Height = 300,
                        Weight = 100,
                    }
                ]
            });

            // Assert
            Assert.Null(errors);
        }
        
        /// <summary>
        /// Тестирует возможность размещение коробки, повернув её на 90 градусов (поменяв местами ширину и длину коробки)
        /// </summary>
        [Fact]
        public void AddPalletWithSwappedWidthAndLengthTest()
        {
            // Arrange
            var mock = new Mock<IPalletRepository>();
            mock.Setup(p => p.Add(It.IsAny<Pallet>())).Verifiable();
            PalletService palletService = new(mock.Object);
            
            // Act
            var errors = palletService.Add(new Pallet
            {
                Length = 200,
                Width = 150,
                Height = 30,
                Boxes =
                [
                    new Box
                    {
                        Length = 140,
                        Width = 195,
                        Height = 285,
                        Weight = 38,
                    }
                ]
            });

            // Assert
            Assert.Null(errors);
        }
    }
    
}