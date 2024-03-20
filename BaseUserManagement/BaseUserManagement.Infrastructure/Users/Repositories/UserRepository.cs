using BaseUserManagement.Domain.Users.Models;
using BaseUserManagement.Domain.Users.Repositories;

namespace BaseUserManagement.Infrastructure.Users.Repositories;

public class UserRepository : IUserRepository
{
    public async Task<User?> GetUserByUsernameAsync(string username, CancellationToken cancellationToken)
    {
        var user = new User("username", "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", "email", "firstName", "lastName");
        return user;
    }
    
    public async Task<User?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var user = new User("username", "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", "email", "firstName", "lastName");
        return user;
    }
}