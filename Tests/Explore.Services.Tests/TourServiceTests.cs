using System.Collections.Generic;
using Xunit;
using Moq;
using Explore.Services.Services;
using Explore.DataAccess.Abstraction;
using Explore.DataAccess.Abstraction.Entities;
using ExploreSolution.DTO;

namespace Explore.Services.Tests
{
    public class TourServiceTests
    {
        [Fact]
        public void GetAllUsers_WithoutParameters_RetursAllUsers()
        {
            // Arrange
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(unitOfWork => unitOfWork.TourRepository.GetAll()).Returns(GetAllTours);
            var tourService = new TourService(mock.Object);

            // Act
            var actualTours = tourService.GetAllTours();

            // Assertions
            Assert.True(actualTours.Count == 2);
            Assert.Equal(1, actualTours[0].TourId);
            Assert.Equal(2, actualTours[1].TourId);
            Assert.Equal(1, actualTours[0].Price);
            Assert.Equal("Tour2", actualTours[1].Name);
        }

        [Fact]
        public async void AddTourAsync_ValidTour_Success()
        {
            // Arrange
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(unitOfWork => unitOfWork.TourRepository.AddAsync(It.IsAny<TourEntity>())).Verifiable();
            mock.Setup(unitOfWork => unitOfWork.CommitAsync()).Verifiable();
            var tourService = new TourService(mock.Object);
            TourDto tour = new TourDto()
            {
                Name = "TourId",
                Price = 5
            };

            // Act
            await tourService.AddTourAsync(tour);

            // Assert
            mock.Verify(moq => moq.CommitAsync(), Times.Once);
        }

        [Fact]
        public void AddTour_ValidTour_ReturnTrue()
        {
            // Arrange
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(unitOfWork => unitOfWork.TourRepository.AddAsync(It.IsAny<TourEntity>())).Verifiable();
            mock.Setup(unitOfWork => unitOfWork.Commit()).Verifiable();
            var tourService = new TourService(mock.Object);
            TourDto tour = new TourDto()
            {
                Name = "TourId",
                Price = 5
            };

            // Act
            var result =  tourService.AddTour(tour);

            // Assert
            mock.Verify(moq => moq.Commit(), Times.Once);
            Assert.True(result);
        }

        [Fact]
        public void UpdateTour_ValidTour_ReturnTrue()
        {
            // Arrange
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(unitOfWork => unitOfWork.TourRepository.Update(It.IsAny<TourEntity>())).Verifiable();
            mock.Setup(unitOfWork => unitOfWork.Commit()).Verifiable();
            var tourService = new TourService(mock.Object);
            TourDto tour = new TourDto()
            {
                Name = "TourId",
                Price = 5
            };
            int tourId = 1;

            // Act
            var result = tourService.UpdateTourById(tourId, tour);

            // Assert
            mock.Verify(moq => moq.Commit(), Times.Once);
            Assert.True(result);
        }

        private IEnumerable<TourEntity> GetAllTours()
        {
            return new List<TourEntity>
            {
                new TourEntity
                {
                    Name = "Tour1",
                    TourId = 1,
                    Price = 1
                },
                new TourEntity
                {
                    Name = "Tour2",
                    TourId = 2,
                    Price = 2
                }
            };
        }
    }
}
