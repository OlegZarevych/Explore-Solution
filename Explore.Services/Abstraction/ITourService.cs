using Explore.Dto.Abstraction.DTO;
using ExploreSolution.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Explore.Services.Abstraction
{
    public interface ITourService
    {
        bool AddTour(TourDto tour);

        void AddTourAsync(TourDto tour);

        IList<Tour> GetAllTours();

        Task<IEnumerable<Tour>> GetAllToursAsync();

        Task<Tour> GetTourByNameAsync(string name);

        Tour GetTourById(int id);

        bool UpdateTourById(int id, TourDto tour);

        void RemoveTourById(int id);

        void RemoveTourByIdAsync(int id);

        IList<Tour> SearchTourByName(string name);
    }
}