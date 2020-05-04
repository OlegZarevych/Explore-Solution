using Explore.Dto.Abstraction.DTO;
using ExploreSolution.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Explore.Services.Abstraction
{
    public interface ITourService
    {
        bool AddTour(TourDto tour);

        Task<int> AddTourAsync(TourDto tour);

        IList<Tour> GetAllTours();

        Task<IEnumerable<Tour>> GetAllToursAsync();

        Tour GetTourById(int id);

        bool UpdateTourById(int id, TourDto tour);

        Task UpdateTourByIdAsync(int id, TourDto tour);

        void RemoveTourById(int id);

        Task RemoveTourByIdAsync(int id);

        IList<Tour> SearchTourByName(string name);
    }
}