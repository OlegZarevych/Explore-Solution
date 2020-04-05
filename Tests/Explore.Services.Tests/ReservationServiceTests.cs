using Explore.DataAccess.Abstraction;
using Explore.DataAccess.Abstraction.Entities;
using Explore.Dto.Abstraction.DTO;
using Explore.Services.Services;
using Moq;
using System;
using Xunit;

namespace Explore.Services.Tests
{
    public class ReservationServiceTests
    {
        [Fact]
        public async void AddReservationAsync_ValidReservation_Success()
        {
            // Arrange
            decimal actualResultPrice = 0;
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(unitOfWork => unitOfWork.ReservationRepository.AddAsync(It.IsAny<ReservationEntity>())).Verifiable();
            mock.Setup(unitOfWork => unitOfWork.TourRepository.FindById(It.IsAny<int>())).Returns(new TourEntity() { Name = "TourMoq", Price = 5 });
            mock.Setup(unitOfWork => unitOfWork.CommitAsync()).Verifiable();
            mock.Setup(unitOfWork => unitOfWork.ReservationRepository.AddAsync(It.IsAny<ReservationEntity>())).Callback<ReservationEntity>(r => actualResultPrice = r.ReservationPrice);
            var reservationService = new ReservationService(mock.Object);

            ReservationDto reservation = getReservation();

            // Act
            await reservationService.AddReservationAsync(reservation);

            // Assert
            mock.Verify(moq => moq.CommitAsync(), Times.Once);
            Assert.Equal(expected: 10, actualResultPrice);
        }

        [Fact]
        public async void AddReservationAsync_TourDoesntExist_ThrowException()
        {
            // Arrange
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(unitOfWork => unitOfWork.TourRepository.FindById(It.IsAny<int>())).Returns((TourEntity)null);
            mock.Setup(unitOfWork => unitOfWork.CommitAsync()).Verifiable();
            var reservationService = new ReservationService(mock.Object);

            ReservationDto reservation = getReservation();

            // Act & Assert
            var msg = await Assert.ThrowsAsync<ServiceException>(async () => await reservationService.AddReservationAsync(reservation));
            Assert.Equal($"Exception occur in service : No tour with id {reservation.TourId}", msg.Message);
        }

        private static ReservationDto getReservation()
        {
            return new ReservationDto()
            {
                CustomerFullName = "FullName",
                PeopleCount = 2,
                TourId = 1,
                CustomerPhone = "123456789"
            };
        }
    }
}