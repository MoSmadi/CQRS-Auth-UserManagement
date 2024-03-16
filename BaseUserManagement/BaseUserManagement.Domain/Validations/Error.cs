using BaseUserManagement.Domain.Validations.Constants;

namespace BaseUserManagement.Domain.Validations;

/// <summary>
/// Error class acts like a container for error information. It provides a structured way to capture and handle errors within the system.
/// - It stores an error code (like "404") and a descriptive message (like "Not Found").
/// - It allows comparison of errors to see if they represent the same issue.
/// - It offers ways to convert errors to strings for easy logging or display.
/// - It ensures errors are handled consistently within the code.
/// </summary>
public sealed class Error : IEquatable<Error>
{
    public static readonly Error None = new(string.Empty, string.Empty);
    
    public static readonly Error NullValue = new(Errors.NullValueCode, Errors.NullValueMessage);
    
    public string Code { get; }

    public string Message { get; }
    
    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public bool Equals(Error? other)
    {
        if (other is null)
        {
            return false;
        }

        return Code == other.Code && Message == other.Message;
    }

    public static bool operator ==(Error? a, Error? b)
    {
        if (a is null && b is null)
        {
            return true;
        }

        if (a is null || b is null)
        {
            return false;
        }

        return a.Equals(b);
    }

    public static implicit operator string(Error error) => error.Code;

    public static bool operator !=(Error? a, Error? b) => !(a == b);

    public override bool Equals(object? obj) => obj is Error error && Equals(error);

    public override int GetHashCode() => HashCode.Combine(Code, Message);

    public override string ToString() => Code;
}
