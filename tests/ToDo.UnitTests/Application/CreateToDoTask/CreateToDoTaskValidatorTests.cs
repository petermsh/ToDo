using FluentValidation.TestHelper;
using ToDo.Application.Commands.CreateToDoTask;

namespace ToDo.UnitTests.Application.CreateToDoTask;

public class CreateToDoTaskValidatorTests
{
    [Fact]
    public void Validate_WithValidCommand_ShouldNotHaveValidationError()
    {
        // Arrange
        var validator = new CreateToDoTaskValidator();
        var command = new CreateToDoTaskCommand(
            "Correct title",
            "Correct description",
            new DateTime(2025, 10, 26, 15, 30, 10).ToUniversalTime(),
            0);

        // Act
        var result = validator.TestValidate(command);
        
        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
    
    [Fact]
    public void Validate_WithInvalidCommand_ShouldHaveValidationError()
    {
        // Arrange
        var validator = new CreateToDoTaskValidator();
        var command = new CreateToDoTaskCommand(
            "Incorrect title too much letters",
            "Incorrect description too much letterstoo much letterstoo much letterstoo much letterstoo much letterstoo much letters" +
            "too much letterstoo much letterstoo much letterstoo much letterstoo much letterstoo much letterstoo much letterstoo much letterstoo much letters",
            new DateTime(2024, 10, 24, 15, 30, 10).ToUniversalTime(),
            120);

        // Act
        var result = validator.TestValidate(command);
        
        // Assert
        result.ShouldHaveValidationErrorFor(c => c.Title);
        result.ShouldHaveValidationErrorFor(c => c.Description);
        result.ShouldHaveValidationErrorFor(c => c.ExpiryAt);
        result.ShouldHaveValidationErrorFor(c => c.CompletionPercentage);
    }
}