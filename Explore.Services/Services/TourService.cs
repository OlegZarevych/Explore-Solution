using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IList<TourDto> GetAllTours()
        {
            var entitiesList = this.tourRepo.GetAll();

            //IEnumerable<TourDto> tours = BaseMapper<IEnumerable<TourEntity>, IEnumerable<TourDto>>.Map(entitiesList);

            IList<TourDto> tours = new List<TourDto>();

            entitiesList.ToList().ForEach(i => tours.Add(BaseMapper<TourEntity, TourDto>.Map(i)));

            return tours;
        }

        public Task<IEnumerable<TourDto>> GetCustomersAsync()
        {
            return Task.FromResult(this.GetAllTours().AsEnumerable());
        }

        public Task<TourDto> GetTourByNameAsync(string name)
        {
            var entitiesLst = this.GetAllTours();
            return Task.FromResult(entitiesLst.Single(o => Equals(o.Name, name)));
        }
    }
}