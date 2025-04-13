using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.AnimeNexus.API.Features.Auth.Models
{
    public class RegisterUserResponse
    {
        public required string UserName { get; set; }
        public DateTime UserRegisterdTimestamp { get; set; } = DateTime.UtcNow;

    }
}