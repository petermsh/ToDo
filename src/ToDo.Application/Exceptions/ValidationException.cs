using FluentValidation.Results;
using ToDo.Application.Abstractions;

namespace ToDo.Application.Exceptions;

/// <summary>
/// Definition for 
/// </summary>
/// <param name="result"></param>
public class ValidationException(ValidationResult result) : Exception(result.ToString())
{
    public List<string> ErrorMessages { get; } = result.Errors.Select(e => e.ErrorMessage).ToList();
}