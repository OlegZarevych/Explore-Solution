using System.Linq;
using System.Collections.Generic;
using Explore.DataAccess.Abstraction;
using Explore.DataAccess.Abstraction.Entities;

namespace Explore.DataAccess.Repositories
{
    public class TourRepository : ITourRepository
    {
        private readonly ExploreDb exploreDb;

        public TourRepository()
        {
            this.exploreDb = new ExploreDb();
        }

        public void Add<T>(T item)
        {
            exploreDb.Tours.Add(item as TourEntity);
            exploreDb.SaveChanges();
        }

        public async void AddAsync<T>(T item)
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

        public async void RemoveAsync(int id)
        {
            exploreDb.Tours.Remove(this.FindById(id));
            exploreDb.SaveChangesAsync();
        }

        public void Update<T>(T item)
        {
            exploreDb.Tours.Update(item as TourEntity);
        }
    }
}
