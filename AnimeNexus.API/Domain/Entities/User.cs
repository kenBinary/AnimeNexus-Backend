using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.AnimeNexus.API.Domain.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required Guid UserId { get; set; }
        [MaxLength(9)]
        public required string UserName { get; set; }
        public required string PasswordHash { get; set; }
    }
}