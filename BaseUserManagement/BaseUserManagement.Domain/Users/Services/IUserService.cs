using BaseUserManagement.Domain.Users.Models;
using BaseUserManagement.Domain.Validations;

namespace BaseUserManagement.Domain.Users.Services;

public interface IUserService
{
    public Task<Result<User>> ValidateLoginCredentialsAsync(string username, string password, CancellationToken cancellationToken);
}