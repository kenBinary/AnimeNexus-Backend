namespace backend.AnimeNexus.API.Features.Auth.Models
{
    public class OperationResult
    {
        public bool Success { get; init; }
        public string? ErrorMessage { get; init; }

        public static OperationResult Succeeded() => new() { Success = true };
        public static OperationResult Failed(string errorMessage) => new() { Success = false, ErrorMessage = errorMessage };
    }
}