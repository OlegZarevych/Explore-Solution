using Explore.DataAccess.Abstraction.Entities;
using Microsoft.EntityFrameworkCore;

namespace Explore.DataAccess
{
    public class ExploreDb : DbContext
    {
        public ExploreDb(DbContextOptions options) : base (options)
        {
           Database.EnsureCreated();
        }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlite("Data Source=ExploreDb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<TourEntity> Tours { get; set; }

        public virtual DbSet<ReservationEntity> Reservations { get; set; }
    }
}