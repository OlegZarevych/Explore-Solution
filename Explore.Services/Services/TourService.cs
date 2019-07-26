using Explore.DataAccess.Abstraction;
using Explore.DataAccess.Abstraction.Entities;
using Explore.Dto.Abstraction.CustomMapper;
using Explore.Services.Abstraction;
using ExploreSolution.DTO;

namespace Explore.Services.Services
{
    public class TourService : ITourService
    {
        private readonly ITourRepository tourRepo;

        public TourService(ITourRepository tourRepo)
        {
            this.tourRepo = tourRepo;
        }

        public bool AddTour(TourDto tour)
        {
            TourEntity tourEntity = BaseMapper<TourDto, TourEntity>.Map(tour);

            tourRepo.Add(tourEntity);
            return true;
        }
    }
}
