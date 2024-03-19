namespace BaseUserManagement.Domain.Users.Services;

public class UserContext : IUserContext
{
    public Guid UserId { get; set; }
    
    public void SetUserId(Guid userId)
    {
        UserId = userId;
    }
}