using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.AnimeNexus.API.Features.Auth.Models
{
    public class ResetPasswordRequest
    {
        [StringLength(maximumLength: 9, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 9 characters.")]
        public required string UserName { get; set; }

        [StringLength(maximumLength: 20, MinimumLength = 8)]
        // (requires lowercase, uppercase, digit, special character, min 8 chars)
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,}$", ErrorMessage = "Password must have lowercase, uppercase, digit, special character, and min of 8 chars.")]
        public required string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
        public required string ConfirmPassword { get; set; }
    }
}