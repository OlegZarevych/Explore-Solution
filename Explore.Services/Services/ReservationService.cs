using Explore.DataAccess.Abstraction;
using Explore.DataAccess.Abstraction.Entities;
using Explore.Dto.Abstraction.CustomMapper;
using Explore.Dto.Abstraction.DTO;
using Explore.Dto.Abstraction.Mapper;
using Explore.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Explore.Services.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork unitOfWork;
        public ReservationService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddReservationAsync(ReservationDto reservation)
        {
            var tour = this.unitOfWork.TourRepository.FindById(reservation.TourId);

            if (tour == null)
            {
                throw new ServiceException($"No tour with id {reservation.TourId}");
            }

            ReservationEntity reservationEntity = BaseMapper<ReservationDto, ReservationEntity>.Map(reservation);
            reservationEntity.Tour = tour;
            reservationEntity.ReservationPrice = tour.Price * reservationEntity.PeopleCount;

            await this.unitOfWork.ReservationRepository.AddAsync(reservationEntity);
            await this.unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
        {
            var reservation = await this.unitOfWork.ReservationRepository.GetAllAsync();

            IList<Reservation> reservationList = new List<Reservation>();

            reservation.ToList().ForEach(i => reservationList.Add(ReservationMapper.Map(i)));
            
            return reservationList;
        }

        public async Task<IEnumerable<ReservationEntity>> GetAllReservationsByTourNameAsync(string tourName)
        {
            return await this.unitOfWork.ReservationRepository.GetReservationByTourNameAsync(tourName);
        }
    }
}