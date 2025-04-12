using Microsoft.EntityFrameworkCore;
using AnimeNexus.API.Domain.Entities;

namespace backend.AnimeNexus.API.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}