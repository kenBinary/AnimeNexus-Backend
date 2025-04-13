using backend.AnimeNexus.API.Domain.Entities;

namespace backend.AnimeNexus.API.Features.Auth.Interfaces
{
    public interface IAuthRepository
    {
        Task<User> AddUser(string userName, string passwordHash);
        Task<User?> GetUserByUsernameAsync(string userName);
        Task UpdateUser(User user);
    }
}