namespace BaseUserManagement.Domain.Users.Services;

public interface IUserContext
{
    void SetUserId(Guid userId);
}