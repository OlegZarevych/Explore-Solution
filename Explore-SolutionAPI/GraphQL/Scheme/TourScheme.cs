using GraphQL;
using GraphQL.Types;

namespace ExploreSolution.API.GraphQL.SchemeQl
{
    public class TourScheme : Schema
    {
        public TourScheme(ToursQuery query, IDependencyResolver resolver)
        {
            Query = query;
            DependencyResolver = resolver;
        }
    }
}
