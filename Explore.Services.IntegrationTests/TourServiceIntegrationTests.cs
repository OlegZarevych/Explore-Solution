using Explore.DataAccess;
using Explore.DataAccess.Repositories;
using Explore.Services.Services;
using ExploreSolution.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace Explore.Services.IntegrationTests
{
    public class TourServiceIntegrationTests
    {
        [Fact]
        public async void Test1()
        {
            string tourName = "Tour1";
            var options = new DbContextOptionsBuilder<ExploreDb>().UseInMemoryDatabase(databaseName: "Add_writes_to_database").Options;

            using (var context = new ExploreDb(options))
            {
                var tourRepo = new TourRepository(context);
                var unit = new UnitOfWork(context, tourRepo, new ReservationRepository(context));
                var tourService = new TourService(unit);
                var tour = new TourDto()
                { Name = tourName };

                await tourService.AddTourAsync(tour);

                var result = await context.Tours.SingleAsync();

                Assert.Equal(result.Name, tourName);
            }
        }
    }
}
