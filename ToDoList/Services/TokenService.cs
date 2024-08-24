using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TodoList.Models;

namespace TodoList.Services;

public class TokenService
{
    public string Generate(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Role, user.Role)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.TOKEN_KEY));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var now = DateTime.Now;

        var tokenDescriptor = new JwtSecurityToken(
            "test-issuer",
            "test-audience",
            claims,
            now,
            now.AddMinutes(Constants.TOKEN_EXPIRATION_IN_MINUTES),
            credentials);

        var token = tokenHandler.WriteToken(tokenDescriptor);
        return token;
    }
}
