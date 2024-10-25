using FluentValidation.TestHelper;
using ToDo.Application.Commands.SetToDoTaskCompletionPercentage;

namespace ToDo.UnitTests.Application.SetToDoTaskCompletionPercentage;

public class SetToDoTaskCompletionPercentageValidatorTests
{
    [Fact]
    public void Validate_WithValidCommand_ShouldNotHaveValidationError()
    {
        // Arrange
        var validator = new SetToDoTaskCompletionPercentageValidator();
        var command = new SetToDoTaskCompletionPercentageCommand()
        {
            CompletionPercentage = 50
        };
        
        // Act
        var result = validator.TestValidate(command);
        
        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
    
    [Fact]
    public void Validate_WhenCompletionPercentageIsTooLarge_ShouldHaveValidationError()
    {
        // Arrange
        var validator = new SetToDoTaskCompletionPercentageValidator();
        var command = new SetToDoTaskCompletionPercentageCommand()
        {
            CompletionPercentage = 120
        };
        // Act
        var result = validator.TestValidate(command);
        
        // Assert
        result.ShouldHaveValidationErrorFor(c => c.CompletionPercentage);
    }
    
    [Fact]
    public void Validate_WithInvalidCommand_ShouldHaveValidationError()
    {
        // Arrange
        var validator = new SetToDoTaskCompletionPercentageValidator();
        var command = new SetToDoTaskCompletionPercentageCommand()
        {
            CompletionPercentage = -4
        };
        // Act
        var result = validator.TestValidate(command);
        
        // Assert
        result.ShouldHaveValidationErrorFor(c => c.CompletionPercentage);
    }
}