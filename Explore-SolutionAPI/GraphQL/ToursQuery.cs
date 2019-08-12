using Explore.Services.Abstraction;
using ExploreSolution.API.GraphQL.Scheme;
using GraphQL.Types;

namespace ExploreSolution.API.GraphQL
{
    public class ToursQuery : ObjectGraphType<object>
    {
        public ToursQuery(ITourService tourServices)
        {
            Name = "Query";
            Field<ListGraphType<TourType>>(
                "tours",
                resolve: context => tourServices.GetAllToursAsync()
                );
        }
    }
}