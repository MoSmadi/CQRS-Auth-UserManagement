using BaseUserManagement.Domain.Validations.Constants;

namespace BaseUserManagement.Domain.Validations;

/// <summary>
/// This part of the code builds on the Result class to specifically handle successful results with values.
/// - It inherits from Result, keeping success/failure functionality.
/// - It adds a field to store a value of a specific type (TValue).
/// - You can only access the value if the result is successful (using the Value property). Trying to access it on a failure throws an error.
/// - It allows easy conversion of a value to a successful Result/<TValue/>.
/// In short, it creates a type-safe way to hold both success and a specific value when an operation succeeds.
/// </summary>
/// <typeparam name="TValue"></typeparam>
public class Result<TValue> : Result
{
    private readonly TValue? _value;

    protected internal Result(TValue? value, bool isSuccess, Error error) : base(isSuccess, error) => _value = value;

    public TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException(Exceptions.InvalidOperationExceptionMessage);

    public static implicit operator Result<TValue>(TValue? value) => Create(value);
}