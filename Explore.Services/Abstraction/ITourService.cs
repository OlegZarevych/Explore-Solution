using ExploreSolution.DTO;

namespace Explore.Services.Abstraction
{
    public interface ITourService
    {
        bool AddTour(TourDto tour);
    }
}