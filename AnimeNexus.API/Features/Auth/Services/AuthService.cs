using backend.AnimeNexus.API.Features.Auth.Models;
using backend.AnimeNexus.API.Features.Auth.Interfaces;
using AutoMapper;
using backend.AnimeNexus.API.Domain.DTOs;

namespace backend.AnimeNexus.API.Features.Auth.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;


        public AuthService(IAuthRepository authRepository, IJwtService jwtService, IMapper mapper)
        {
            _authRepository = authRepository;
            _jwtService = jwtService;
            _mapper = mapper;
        }

        public async Task<UserCreationResult> AddNewUserAsync(string userName, string plainTextPassword)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(plainTextPassword))
            {
                return UserCreationResult.Failed("Username and password cannot be empty.");
            }

            var existingUser = await DoesUserExistAsync(userName);
            if (existingUser)
            {
                return UserCreationResult.Failed("Username already exists.");
            }

            var passwordHash = HashPassword(plainTextPassword);

            try
            {
                var addedUser = await _authRepository.AddUser(userName, passwordHash);
                var addedUserDto = _mapper.Map<UserDto>(addedUser);

                return UserCreationResult.Succeeded(addedUserDto);
            }
            catch (Exception)
            {
                return UserCreationResult.Failed("An error occurred while creating the user.");
            }
        }

        public async Task<AuthenticationResult> AuthenticateUserAsync(string userName, string plainTextPassword)
        {
            var user = await _authRepository.GetUserByUsernameAsync(userName);

            if (user == null)
            {
                return AuthenticationResult.Failed("Invalid username or password.");
            }

            if (!VerifyPassword(plainTextPassword, user.PasswordHash))
            {
                return AuthenticationResult.Failed("Invalid username or password.");
            }

            var token = _jwtService.GenerateJwtToken(user.UserName);

            return AuthenticationResult.Succeeded(token);
        }

        public async Task<bool> DoesUserExistAsync(string userName)
        {
            var user = await _authRepository.GetUserByUsernameAsync(userName);
            return user != null;
        }

        public string HashPassword(string plainTextPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(plainTextPassword);
        }

        public async Task<OperationResult> UpdateUserPasswordAsync(string userName, string newPlainTextPassword)
        {
            if (string.IsNullOrWhiteSpace(newPlainTextPassword))
            {
                return OperationResult.Failed("New password cannot be empty.");
            }

            var user = await _authRepository.GetUserByUsernameAsync(userName);
            if (user == null)
            {
                return OperationResult.Failed("User not found.");
            }

            var newPasswordHash = HashPassword(newPlainTextPassword);
            user.PasswordHash = newPasswordHash;

            try
            {
                await _authRepository.UpdateUser(user);
                return OperationResult.Succeeded();
            }
            catch (Exception)
            {
                return OperationResult.Failed("An error occurred while updating the password.");
            }
        }

        public bool VerifyPassword(string plainTextPassword, string hashedPassword)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(plainTextPassword, hashedPassword);
            }
            catch
            {
                return false;
            }
        }
    }
}