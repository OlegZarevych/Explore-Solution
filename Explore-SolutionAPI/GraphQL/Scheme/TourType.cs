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
            this.Description = "Touristic tours for adventure";

            Field(c => c.Name);

            Field(c => c.Description);

            Field(c => c.Notes);

            Field(c => c.Price);
        }
    }
}
