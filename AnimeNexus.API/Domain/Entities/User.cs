using System.ComponentModel.DataAnnotations.Schema;

namespace backend.AnimeNexus.API.Domain.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required Guid UserId { get; set; }
        public required string UserName { get; set; }
        public required string PasswordHash { get; set; }
    }
}