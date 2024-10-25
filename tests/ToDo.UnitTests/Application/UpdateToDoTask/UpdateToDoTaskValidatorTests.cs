using FluentValidation.TestHelper;
using ToDo.Application.Commands.UpdateToDoTask;

namespace ToDo.UnitTests.Application.UpdateToDoTask;

public class UpdateToDoTaskValidatorTests
{
    [Fact]
    public void Validate_WithValidCommand_ShouldNotHaveValidationError()
    {
        // Arrange
        var validator = new UpdateToDoTaskValidator();
        var command = new UpdateToDoTaskCommand
        {
            Title = "Correct title",
            Description = "Correct description",
            ExpiryAt = new DateTime(2025, 10, 26, 15, 30, 10).ToUniversalTime()
        };
        
        // Act
        var result = validator.TestValidate(command);
        
        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
    
    [Fact]
    public void Validate_WithInvalidCommand_ShouldHaveValidationError()
    {
        // Arrange
        var validator = new UpdateToDoTaskValidator();
        var command = new UpdateToDoTaskCommand
        {
            Title = "Incorrect title too much letters",
            Description = "Incorrect description too much letterstoo much letterstoo much letterstoo much letterstoo much letterstoo much letters" +
                          "too much letterstoo much letterstoo much letterstoo much letterstoo much letterstoo much letterstoo much letterstoo much letterstoo much letters",
            ExpiryAt = new DateTime(2023, 10, 26, 15, 30, 10).ToUniversalTime()
        };
        // Act
        var result = validator.TestValidate(command);
        
        // Assert
        result.ShouldHaveValidationErrorFor(c => c.Title);
        result.ShouldHaveValidationErrorFor(c => c.Description);
        result.ShouldHaveValidationErrorFor(c => c.ExpiryAt);
    }
}