using Explore.Services.Abstraction;
using ExploreSolution.DTO;
using GraphQL.Types;


namespace ExploreSolution.API.GraphQL.Scheme
{
    public class TourType : ObjectGraphType<TourDto>
    {
        public TourType(ITourService tour)
        {
            this.Name = nameof(TourDto);

            Field(c => c.Name);
        }
    }
}
