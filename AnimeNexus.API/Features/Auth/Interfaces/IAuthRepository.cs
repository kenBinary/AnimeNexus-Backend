using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.AnimeNexus.API.Domain.Entities;

namespace backend.AnimeNexus.API.Features.Auth.Interfaces
{
    public interface IAuthRepository
    {
        Task<User?> GetUser(string userName, string passwordHash);
        Task AddUser(string userName, string passwordHash);
        Task UpdateUser(User user);

    }
}