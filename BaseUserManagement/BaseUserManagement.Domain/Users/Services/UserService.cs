using BaseUserManagement.Domain.Users.Constants;
using BaseUserManagement.Domain.Users.Extensions;
using BaseUserManagement.Domain.Users.Models;
using BaseUserManagement.Domain.Users.Repositories;
using BaseUserManagement.Domain.Validations;

namespace BaseUserManagement.Domain.Users.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<Result<User>> ValidateLoginCredentialsAsync(string username, string password, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByUsernameAsync(username, cancellationToken);
        
        if (user is null)
        {
            return Result.Failure<User>(UserConstants.InvalidUsername);
        }
        
        var hashedPassword = password.HashPassword();
        
        if (user.HashedPassword != hashedPassword)
        {
            return Result.Failure<User>(UserConstants.InvalidCredentials);
        }
        
        return Result.Success(user);
    }
}