using backend.AnimeNexus.API.Domain.DTOs;

namespace backend.AnimeNexus.API.Features.Auth.Models
{
    public class UserCreationResult : OperationResult
    {
        public UserDto? CreatedUser { get; init; }

        public static UserCreationResult Succeeded(UserDto user) => new() { Success = true, CreatedUser = user };
        public new static UserCreationResult Failed(string errorMessage) => new() { Success = false, ErrorMessage = errorMessage };
    }
}