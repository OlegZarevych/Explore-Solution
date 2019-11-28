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

        public void Add<T>(T item)
        {
            exploreDb.Tours.Add(item as TourEntity);
            exploreDb.SaveChanges();
        }

        public async Task AddAsync<T>(T item)
        {
            await exploreDb.Tours.AddAsync(item as TourEntity);
            await exploreDb.SaveChangesAsync();
        }

        public TourEntity FindById(int id)
        {
            return exploreDb.Tours.Where(item => item.TourId == id).SingleOrDefault();
        }

        public IEnumerable<TourEntity> GetAll()
        {
            return exploreDb.Tours.OrderBy(item => item.TourId);
        }

        public void Remove(int id)
        {
            exploreDb.Tours.Remove(this.FindById(id));
            exploreDb.SaveChanges();
        }

        public async Task RemoveAsync(int id)
        {
            exploreDb.Tours.Remove(this.FindById(id));
            await exploreDb.SaveChangesAsync();
        }

        public void Update<T>(T item)
        {
            exploreDb.Tours.Update(item as TourEntity);
            exploreDb.SaveChanges();
        }

        public async Task UpdateAsync<T>(T item)
        {
            exploreDb.Tours.Update(item as TourEntity);
            await exploreDb.SaveChangesAsync();
        }
    }
}
