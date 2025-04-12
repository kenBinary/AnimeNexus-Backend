using System.ComponentModel.DataAnnotations;

namespace backend.AnimeNexus.API.Features.Auth.Models
{
    public class RegisterRequest
    {
        [StringLength(maximumLength: 9, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 9 characters.")]
        public required string UserName { get; set; }

        [StringLength(maximumLength: 20, MinimumLength = 8)]
        // (requires lowercase, uppercase, digit, special character, min 8 chars)
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,}$", ErrorMessage = "Password must have lowercase, uppercase, digit, special character, and min of 8 chars.")]
        public required string Password { get; set; }
    }
}
