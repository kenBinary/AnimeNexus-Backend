namespace backend.AnimeNexus.API.Features.Auth.Models
{
    public class AuthenticationResult : OperationResult
    {
        public string? Token { get; init; }

        public static AuthenticationResult Succeeded(string token) => new() { Success = true, Token = token };
        public new static AuthenticationResult Failed(string errorMessage) => new() { Success = false, ErrorMessage = errorMessage };
    }
}