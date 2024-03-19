using BaseUserManagement.Domain.Users.Models;

namespace BaseUserManagement.Domain.Users.Repositories;

public interface IUserRepository
{
    Task<User?> GetUserByUsernameAsync(string username, CancellationToken cancellationToken);
}