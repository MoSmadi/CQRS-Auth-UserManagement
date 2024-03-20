using BaseUserManagement.Domain.Users.Models;

namespace BaseUserManagement.Domain.Users.Repositories;

public interface IUserRepository
{
    Task<User?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken);
    
    Task<User?> GetUserByUsernameAsync(string username, CancellationToken cancellationToken);
}