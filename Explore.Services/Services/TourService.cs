using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Explore.DataAccess.Abstraction;
using Explore.DataAccess.Abstraction.Entities;
using Explore.Dto.Abstraction.CustomMapper;
using Explore.Dto.Abstraction.DTO;
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

        public async Task<Task> AddTourAsync(TourDto tour)
        {
            TourEntity tourEntity = BaseMapper<TourDto, TourEntity>.Map(tour);
            return Task.FromResult(tourRepo.AddAsync(tourEntity));
        }

        public IList<Tour> GetAllTours()
        {
            var entitiesList = this.tourRepo.GetAll();

            //IEnumerable<TourDto> tours = BaseMapper<IEnumerable<TourEntity>, IEnumerable<TourDto>>.Map(entitiesList);

            IList<Tour> tours = new List<Tour>();

            entitiesList.ToList().ForEach(i => tours.Add(BaseMapper<TourEntity, Tour>.Map(i)));

            return tours;
        }

        public Task<IEnumerable<Tour>> GetAllToursAsync()
        {
            return Task.FromResult(this.GetAllTours().AsEnumerable());
        }

        public Tour GetTourById(int id)
        {
            var entity = tourRepo.FindById(id);
            return BaseMapper<TourEntity, Tour>.Map(entity);
        }

        public Task<Tour> GetTourByNameAsync(string name)
        {
            var entitiesLst = this.GetAllTours();
            return Task.FromResult(entitiesLst.Single(o => Equals(o.Name, name)));
        }

        public void RemoveTourById(int id)
        {
            tourRepo.Remove(id);
        }

        public async Task<Task> RemoveTourByIdAsync(int id)
        {
            return Task.FromResult(tourRepo.RemoveAsync(id));
        }

        public IList<Tour> SearchTourByName(string name)
        {
            var tours = this.GetAllTours();
            return tours.Where(item => item.Name.Contains(name)).ToList();
        }

        public bool UpdateTourById(int id, TourDto tour)
        {
            var newTour = BaseMapper<TourDto, TourEntity>.Map(tour);

            newTour.TourId = id;

            tourRepo.Update(newTour);
            return true;
        }

        public async Task<Task> UpdateTourByIdAsync(int id, TourDto tour)
        {
            var newTour = BaseMapper<TourDto, TourEntity>.Map(tour);

            newTour.TourId = id;

            return Task.FromResult(tourRepo.UpdateAsync(newTour));
        }
    }
}