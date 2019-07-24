using Explore.DataAccess.Abstraction;
using Explore.DataAccess.Abstraction.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;


namespace Explore.DataAccess
{
    public class ExploreDb : DbContext
    {
        public ExploreDb()
        {
           Database.EnsureCreated();
        }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(@"Server=ZARKOPC5470\SQLEXPRESS02;Database=ExploreDb;Trusted_Connection=True;");
                optionsBuilder.UseSqlite("Data Source=ExploreDb");
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