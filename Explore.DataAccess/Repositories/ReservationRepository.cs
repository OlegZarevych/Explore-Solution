using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Explore.DataAccess.Abstraction;
using Explore.DataAccess.Abstraction.Entities;
using Microsoft.EntityFrameworkCore;

namespace Explore.DataAccess.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ExploreDb exploreDb;

        public ReservationRepository(ExploreDb db)
        {
            this.exploreDb = db;
        }

        public void Add(ReservationEntity item)
        {
            throw new System.NotImplementedException();
        }

        public async Task AddAsync(ReservationEntity item)
        {
            await this.exploreDb.Reservations.AddAsync(item);
        }

        public ReservationEntity FindById(int id)
        {
            return this.exploreDb.Reservations.Where(item => item.ReservationId == id).SingleOrDefault();
        }

        public IEnumerable<ReservationEntity> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<ReservationEntity>> GetAllAsync()
        {
            return await this.exploreDb.Reservations.ToAsyncEnumerable().ToList();
        }

        public async Task<IEnumerable<ReservationEntity>> GetReservationByTourNameAsync(string tourName)
        {
            return await this.exploreDb.Reservations.
                Include(item => item.Tour).
                Where(item => item.Tour.Name == tourName).
                ToAsyncEnumerable().ToList();
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task RemoveAsync(int id)
        {
            this.exploreDb.Reservations.Remove(this.FindById(id));
        }

        public void Update(ReservationEntity item)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateAsync(ReservationEntity item)
        {
            this.exploreDb.Reservations.Update(item);
        }
    }
}