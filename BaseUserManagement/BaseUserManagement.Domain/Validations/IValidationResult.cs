namespace BaseUserManagement.Domain.Validations;

/// <summary>
/// Defines a common interface for validation results, specifically focusing on failure cases.
/// </summary>
public interface IValidationResult
{
    public static readonly Error ValidationError = new
    (
        Constants.Errors.ValidationErrorCode,
        Constants.Errors.ValidationErrorMessage
    );

    Error[] Errors { get; }
}
