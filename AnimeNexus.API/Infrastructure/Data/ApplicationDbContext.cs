using Microsoft.EntityFrameworkCore;
using backend.AnimeNexus.API.Domain.Entities;

namespace backend.AnimeNexus.API.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                // tells EF Core to create a unique constraint in the database
                entity.HasIndex(u => u.UserName)
                      .IsUnique();
            });
        }
    }
}