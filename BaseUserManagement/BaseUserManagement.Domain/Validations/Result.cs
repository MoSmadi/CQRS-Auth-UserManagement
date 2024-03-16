namespace BaseUserManagement.Domain.Validations;

/// <summary>
/// The Result class acts like a wrapper to tell you if an operation was successful or not. It provides a clean way to handle both success and failure cases.
/// - It says if something worked (success) or not (failure).
/// - If it failed, it holds information about the error (using the Error class).
/// - It offers easy ways to create results for success (with or without a value) and failure (with an error message).
/// </summary>
public class Result
{
    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public Error Error { get; }
    
    protected Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None)
        {
            throw new InvalidOperationException();
        }

        if (!isSuccess && error == Error.None)
        {
            throw new InvalidOperationException();
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new(true, Error.None);

    public static Result Failure(Error error) => new(false, error);

    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);

    public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);

    public static Result<TValue> Create<TValue>(TValue? value) =>
        value is not null 
            ? Success(value) 
            : Failure<TValue>(Error.NullValue);
}
