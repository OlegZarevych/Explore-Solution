using Explore.DataAccess.Abstraction.Entities;
using Microsoft.EntityFrameworkCore;

namespace Explore.DataAccess
{
    public class ExploreDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public virtual DbSet<TourEntity> Tours { get; set; }

        public virtual DbSet<ReservationEntity> Reservations { get; set; }
    }
}