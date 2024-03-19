using BaseUserManagement.Domain.Users.Models;
using BaseUserManagement.Domain.Users.Repositories;

namespace BaseUserManagement.Infrastructure.Users.Repositories;

public class UserRepository : IUserRepository
{
    public async Task<User?> GetUserByUsernameAsync(string username, CancellationToken cancellationToken)
    { 
        var user = new User("username", "password", "email", "firstName", "lastName");
        return user;
    }
}