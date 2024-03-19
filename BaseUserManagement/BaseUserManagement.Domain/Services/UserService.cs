using BaseUserManagement.Domain.Users.Models;
using BaseUserManagement.Domain.Validations;

namespace BaseUserManagement.Domain.Services;

public class UserService : IUserService
{
    public async Task<Result<User>> ValidateLoginCredentialsAsync(string username, string password, CancellationToken cancellationToken)
    {
        return Result.Success(new User("username", "password", "email", "firstName", "lastName"));
    }
}