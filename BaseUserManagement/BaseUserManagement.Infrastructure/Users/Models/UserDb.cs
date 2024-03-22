namespace BaseUserManagement.Infrastructure.Users.Models;

public class UserDb
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string HashedPassword { get; set; }
    public string Email { get; set; }
}