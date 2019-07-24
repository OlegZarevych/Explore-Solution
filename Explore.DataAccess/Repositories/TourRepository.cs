using System.Collections.Generic;
using Explore.DataAccess.Abstraction;
using Explore.DataAccess.Abstraction.Entities;

namespace Explore.DataAccess.Repositories
{
    public class TourRepository : IRepository<TourEntity>
    {
        private readonly ExploreDb exploreDb;

        public TourRepository(ExploreDb exploreDb)
        {
            this.exploreDb = exploreDb;
        }

        public void Add<T>(T item)
        {
            exploreDb.Tours.Add(item as TourEntity);
            exploreDb.SaveChanges();
        }

        public TourEntity Find()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TourEntity> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Remove()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
