using ExploreSolution.DTO;
using System.Collections.Generic;

namespace Explore.Services.Abstraction
{
    public interface ITourService
    {
        bool AddTour(TourDto tour);

        IList<TourDto> GetAllTours();
    }
}