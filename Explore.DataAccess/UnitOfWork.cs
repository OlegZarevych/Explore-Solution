using Explore.DataAccess.Abstraction;
using System.Threading.Tasks;

namespace Explore.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ExploreDb db;

        public UnitOfWork(ExploreDb dbContext, ITourRepository tourRepo)
        {
            this.db = dbContext;
            this.TourRepository = tourRepo;
        }

        public ITourRepository TourRepository { get; set; }

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
