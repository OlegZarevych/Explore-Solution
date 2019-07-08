using ExploreSolution.DTO;

namespace ExploreSolution.Services
{
    public interface IAuthenticateService
    {
        bool IsAuthenticated(TokenRequest request, out string token);
    }
}