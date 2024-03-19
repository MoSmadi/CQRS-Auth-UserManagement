namespace BaseUserManagement.Application.Users.Models.Responses;

public class LoginResponse
{
    public string Token { get; private set; }
    
    public LoginResponse(string token)
    {
        Token = token;
    }
}