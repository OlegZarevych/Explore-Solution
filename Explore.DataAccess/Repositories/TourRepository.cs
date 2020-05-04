using System.Linq;
using System.Collections.Generic;
using Explore.DataAccess.Abstraction;
using Explore.DataAccess.Abstraction.Entities;
using System.Threading.Tasks;

namespace Explore.DataAccess.Repositories
{
    public class TourRepository : ITourRepository
    {
        private readonly ExploreDb exploreDb;

        public TourRepository(ExploreDb db)
        {
            this.exploreDb = db;
        }

        public void Add(TourEntity item)
        {
            exploreDb.Tours.Add(item);
        }

        public async Task AddAsync(TourEntity item)
        {
            await exploreDb.Tours.AddAsync(item);
        }

        public TourEntity FindById(int id)
        {
            return exploreDb.Tours.Where(item => item.TourId == id).SingleOrDefault();
        }

        public IEnumerable<TourEntity> GetAll()
        {
            return exploreDb.Tours.OrderBy(item => item.TourId);
        }

        public async Task<IEnumerable<TourEntity>> GetAllAsync()
        {
            return await exploreDb.Tours.ToAsyncEnumerable().ToList();
        }

        public void Remove(int id)
        {
            exploreDb.Tours.Remove(this.FindById(id));
        }

        public async Task RemoveAsync(int id)
        {
            exploreDb.Tours.Remove(this.FindById(id));
        }

        public void Update(TourEntity item)
        {
            exploreDb.Tours.Update(item);
        }

        public async Task UpdateAsync(TourEntity item)
        {
            exploreDb.Tours.Update(item);
        }
    }
}
