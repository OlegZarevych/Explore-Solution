using Explore.DataAccess.Abstraction;
using Explore.Services.Services;
using Machine.Specifications;
using Machine.Fakes;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

using Explore.DataAccess.Abstraction.Entities;
using It = Machine.Specifications.It;
using Explore.Services.Abstraction;
using Explore.Dto.Abstraction.DTO;
using Explore.DataAccess.Repositories;

namespace Explore.Specs
{
    [Subject("Reservation")]
    public class When_Add_New_Reservation : WithSubject<ReservationService>
    {
        static ReservationDto reservation;

        Establish context = () =>
        {
            The<IUnitOfWork>().WhenToldTo(unitOfWork => unitOfWork.TourRepository.FindById(Moq.It.IsAny<int>())).Return(new TourEntity() { Name = "TourMoq", Price = 5 });
            The<IUnitOfWork>().WhenToldTo(unitOfWork => unitOfWork.ReservationRepository.FindById(Moq.It.IsAny<int>())).Return(new ReservationEntity());
            //The<IUnitOfWork>().WhenToldTo(unitOfWork => unitOfWork.ReservationRepository.AddAsync(Moq.It.IsAny<ReservationEntity>()));

            reservation = new ReservationDto()
            {
                CustomerFullName = "FullName",
                PeopleCount = 2,
                TourId = 1,
                CustomerPhone = "123456789"
            };


        };

        Because of = async () =>
        {
            await Subject.AddReservationAsync(reservation);
        };

        It Should_Add_Valid_Tour = () =>
        {
            The<IUnitOfWork>().WasToldTo(unitOfWork => unitOfWork.CommitAsync());
        };
    }
}
