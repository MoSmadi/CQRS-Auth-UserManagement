using BaseUserManagement.Domain.Primitives;

namespace BaseUserManagement.Domain.Users.Models;

public class User : AggregateRoot
{
    public string Username { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string HashedPassword { get; private set; }
    public string Email { get; private set; }
    
    public User(string username, string hashedPassword, string email, string firstName, string lastName) : base(Guid.NewGuid())
    {
        Username = username;
        HashedPassword = hashedPassword;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
    }
}