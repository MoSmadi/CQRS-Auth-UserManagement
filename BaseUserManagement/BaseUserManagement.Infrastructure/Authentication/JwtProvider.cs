using BaseUserManagement.Domain.Authentication;
using BaseUserManagement.Domain.Users.Models;

namespace BaseUserManagement.Infrastructure.Authentication;

public class JwtProvider : IJwtProvider
{
    public string GenerateJwtToken(User user)
    {
        return String.Empty;
    }
}