namespace BaseUserManagement.Domain.Validations.Constants;

public class SharedErrors
{
    public static readonly Error None = new(string.Empty, string.Empty);
    
    public static readonly Error NullValue = new(Errors.NullValueCode, Errors.NullValueMessage);
}