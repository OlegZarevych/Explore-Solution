using Explore.DataAccess.Abstraction.Entities;
using System.Threading.Tasks;

namespace Explore.DataAccess.Abstraction
{
    public interface ITourRepository : IRepository<TourEntity>
    {
    }
}
