using BaseUserManagement.Domain.Users.Models;

namespace BaseUserManagement.Domain.Authentication;

public interface IJwtProvider
{
    public string GenerateJwtToken(User user);
}
