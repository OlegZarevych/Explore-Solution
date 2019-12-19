using System.Collections.Generic;
using System.Threading.Tasks;
using Explore.DataAccess.Abstraction;
using Explore.DataAccess.Abstraction.Entities;

namespace Explore.DataAccess.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        public void Add(ReservationEntity item)
        {
            throw new System.NotImplementedException();
        }

        public Task AddAsync(ReservationEntity item)
        {
            throw new System.NotImplementedException();
        }

        public ReservationEntity FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ReservationEntity> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ReservationEntity>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(ReservationEntity item)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(ReservationEntity item)
        {
            throw new System.NotImplementedException();
        }
    }
}