using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using backend.AnimeNexus.API.Features.Auth.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace backend.AnimeNexus.API.Features.Auth.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        private readonly SymmetricSecurityKey _jwtKey;
        private readonly string? _issuer;
        private readonly string? _audience;
        private readonly double _expiryMinutes;


        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;

            var secret = _configuration["Jwt:Secret"];
            _issuer = _configuration["Jwt:Issuer"];
            _audience = _configuration["Jwt:Audience"];

            if (string.IsNullOrEmpty(secret))
            {
                throw new ArgumentNullException(nameof(secret), "JWT Secret not configured.");
            }
            if (string.IsNullOrEmpty(_issuer))
            {
                throw new ArgumentNullException(nameof(_issuer), "JWT Issuer not configured.");
            }
            if (string.IsNullOrEmpty(_audience))
            {
                throw new ArgumentNullException(nameof(_audience), "JWT Audience not configured.");
            }
            if (!double.TryParse(_configuration["Jwt:ExpiryMinutes"], out _expiryMinutes))
            {
                _expiryMinutes = 60;
            }

            _jwtKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        }
        public string GenerateJwtToken(string userName, IEnumerable<Claim>? additionalClaims = null)
        {
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, userName),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
            };

            if (additionalClaims != null)
            {
                claims.AddRange(additionalClaims);
            }

            var credentials = new SigningCredentials(_jwtKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_expiryMinutes),
                Issuer = _issuer,
                Audience = _audience,
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}