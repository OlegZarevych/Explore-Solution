using System.Linq;
using System.Collections.Generic;
using Explore.DataAccess.Abstraction;
using Explore.DataAccess.Abstraction.Entities;
using System;

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

        public IEnumerable<TourEntity> FindById(int id)
        {
            return exploreDb.Tours.Where(item => item.TourId == id);
        }

        public IEnumerable<TourEntity> GetAll()
        {
            return exploreDb.Tours.OrderBy(item => item.Id);
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
