using System.Threading.Tasks;
using backend.AnimeNexus.API.Features.Auth.Models;

namespace backend.AnimeNexus.API.Features.Auth.Interfaces
{

    public interface IAuthService
    {
        string HashPassword(string plainTextPassword);

        bool VerifyPassword(string plainTextPassword, string hashedPassword);

        Task<bool> DoesUserExistAsync(string userName);

        Task<AuthenticationResult> AuthenticateUserAsync(string userName, string plainTextPassword);

        Task<UserCreationResult> AddNewUserAsync(string userName, string plainTextPassword);

        Task<OperationResult> UpdateUserPasswordAsync(string userName, string newPlainTextPassword);

    }
}