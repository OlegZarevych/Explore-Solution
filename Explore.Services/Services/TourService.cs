using Explore.DataAccess.Abstraction;
using Explore.DataAccess.Abstraction.Entities;
using Explore.Services.Abstraction;

namespace Explore.Services.Services
{
    public class TourService : ITourService
    {
        private readonly ITourService tourService;
        private readonly IRepository<TourEntity> tourRepo;

        public TourService(ITourService tourService, IRepository<TourEntity> tourRepo)
        {
            this.tourService = tourService;
            this.tourRepo = tourRepo;
        }

        public bool AddTour()
        {
            //tourRepo.Add();
            return true;
        }
    }
}
