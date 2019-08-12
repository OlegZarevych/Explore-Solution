using ExploreSolution.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Explore.Services.Abstraction
{
    public interface ITourService
    {
        bool AddTour(TourDto tour);

        IList<TourDto> GetAllTours();

        Task<IEnumerable<TourDto>> GetAllToursAsync();


        Task<TourDto> GetTourByNameAsync(string name);
    }
}