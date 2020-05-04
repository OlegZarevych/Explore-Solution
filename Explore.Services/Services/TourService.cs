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
        private readonly IUnitOfWork unitOfWork;
        public TourService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public bool AddTour(TourDto tour)
        {
            TourEntity tourEntity = BaseMapper<TourDto, TourEntity>.Map(tour);

            this.unitOfWork.TourRepository.Add(tourEntity);
            this.unitOfWork.Commit();

            return true;
        }

        public async Task<int> AddTourAsync(TourDto tour)
        {
            TourEntity tourEntity = BaseMapper<TourDto, TourEntity>.Map(tour);
            int id = await this.unitOfWork.TourRepository.AddTourAsync(tourEntity);
            await this.unitOfWork.CommitAsync();
            return id;
        }

        public IList<Tour> GetAllTours()
        {
            var entitiesList = this.unitOfWork.TourRepository.GetAll();

            IList<Tour> tours = new List<Tour>();

            entitiesList.ToList().ForEach(i => tours.Add(BaseMapper<TourEntity, Tour>.Map(i)));

            return tours;
        }

        public async Task<IEnumerable<Tour>> GetAllToursAsync()
        {
            var entitiesList = await this.unitOfWork.TourRepository.GetAllAsync();

            IList<Tour> tours = new List<Tour>();

            entitiesList.ToList().ForEach(i => tours.Add(BaseMapper<TourEntity, Tour>.Map(i)));

            return tours;
        }

        public Tour GetTourById(int id)
        {
            var entity = unitOfWork.TourRepository.FindById(id);
            return BaseMapper<TourEntity, Tour>.Map(entity);
        }

        public void RemoveTourById(int id)
        {
            unitOfWork.TourRepository.Remove(id);
            this.unitOfWork.Commit();
        }

        public async Task RemoveTourByIdAsync(int id)
        {
            await unitOfWork.TourRepository.RemoveAsync(id);
            await this.unitOfWork.CommitAsync();
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

            this.unitOfWork.TourRepository.Update(newTour);
            this.unitOfWork.Commit();
            return true;
        }

        public async Task UpdateTourByIdAsync(int id, TourDto tour)
        {
            var newTour = BaseMapper<TourDto, TourEntity>.Map(tour);

            newTour.TourId = id;

            await this.unitOfWork.TourRepository.UpdateAsync(newTour);
            await this.unitOfWork.CommitAsync();
        }
    }
}