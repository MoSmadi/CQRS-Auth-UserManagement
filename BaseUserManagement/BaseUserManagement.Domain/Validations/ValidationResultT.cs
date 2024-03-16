namespace BaseUserManagement.Domain.Validations;

/// <summary>
/// Represents a validation result that can optionally hold a value if successful.
/// </summary>
/// <typeparam name="TValue"></typeparam>
public sealed class ValidationResult<TValue> : Result<TValue>, IValidationResult
{
    public Error[] Errors { get; }
    
    private ValidationResult(Error[] errors) : base(default, false, IValidationResult.ValidationError) =>
        Errors = errors;
    
    public static ValidationResult<TValue> WithErrors(Error[] errors) => new(errors);
}
