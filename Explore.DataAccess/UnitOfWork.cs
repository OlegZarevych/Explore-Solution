using Explore.DataAccess.Abstraction;
using System.Threading.Tasks;

namespace Explore.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ExploreDb db;

        public UnitOfWork(ExploreDb dbContext, ITourRepository tourRepo, IReservationRepository reservationRepo)
        {
            this.db = dbContext;
            this.TourRepository = tourRepo;
            this.ReservationRepository = reservationRepo;
        }

        public ITourRepository TourRepository { get; set; }

        public IReservationRepository ReservationRepository { get; set; }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}