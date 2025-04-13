using System.Security.Claims;

namespace backend.AnimeNexus.API.Features.Auth.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwtToken(string userName, IEnumerable<Claim>? additionalClaims = null);
    }
}