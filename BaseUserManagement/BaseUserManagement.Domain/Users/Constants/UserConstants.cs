using BaseUserManagement.Domain.Validations;

namespace BaseUserManagement.Domain.Users.Constants;

public static class UserConstants
{
    public static readonly Error EmailAlreadyExists = new("User.EmailAlreadyExists", "The specified email is already in use");

    public static readonly Func<Guid, Error> NotFound = id => new Error("User.NotFound", $"The user with the identifier {id} was not found.");

    public static readonly Error InvalidCredentials = new("User.InvalidCredentials", "The provided credentials are invalid");
    
    public static readonly Error InvalidUsername = new("User.InvalidUsername", "The provided username is invalid");
}