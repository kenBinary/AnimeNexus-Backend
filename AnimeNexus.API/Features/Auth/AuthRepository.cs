using backend.AnimeNexus.API.Domain.Entities;
using backend.AnimeNexus.API.Features.Auth.Interfaces;
using backend.AnimeNexus.API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.AnimeNexus.API.Features.Auth
{
    public class AuthRepository : IAuthRepository
    {
        readonly ApplicationDbContext _context;

        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddUser(string userName, string passwordHash)
        {
            var user = new User
            {
                UserName = userName,
                PasswordHash = passwordHash
            };

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User?> GetUserByUsernameAsync(string userName)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == userName);
        }

        public async Task UpdateUser(User user)
        {
            _context.Users.Update(user);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine($"Concurrency error updating user: {ex.Message}");
                throw;
            }
        }
    }
}