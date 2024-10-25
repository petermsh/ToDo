using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using NSubstitute;
using ToDo.Application.Commands.SetToDoTaskCompletionPercentage;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;

namespace ToDo.UnitTests.Application.SetToDoTaskCompletionPercentage;

public class SetToDoTaskCompletionPercentageHandlerTests
{
    private readonly IToDoTaskRepository _repository;
    private readonly IValidator<SetToDoTaskCompletionPercentageCommand> _validator;
    private readonly SetToDoTaskCompletionPercentageHandler _handler;

    public SetToDoTaskCompletionPercentageHandlerTests()
    {
        _repository = Substitute.For<IToDoTaskRepository>();
        _validator = Substitute.For<IValidator<SetToDoTaskCompletionPercentageCommand>>();
        _handler = new SetToDoTaskCompletionPercentageHandler(_repository, _validator);
    }
    
    [Fact]
    public async void Handle_WhenDataIsValid_SetToDoTaskCompletionPercentage()
    {
        // Arrange
        var command = new SetToDoTaskCompletionPercentageCommand()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            CompletionPercentage = 50
        };
        
        // Create a ToDoTask object to return from the repository
        var toDoTask = ToDoTask.CreateWithId(
            command.Id,
            "Test ToDoTask",
            "Test description",
            DateTime.UtcNow.AddDays(1),
            0); 

        // Mock the validator to return a valid result
        _validator.ValidateAsync(command, Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(new ValidationResult()));

        // Setup the repository to return the toDoTask when GetAsync is called
        _repository.GetAsync(command.Id, Arg.Any<CancellationToken>())
            .Returns(toDoTask);

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        toDoTask.CompletionPercentage.Should().Be(command.CompletionPercentage);
        await _repository.Received(1).UpdateAsync(Arg.Is<ToDoTask>(t => t.CompletionPercentage == command.CompletionPercentage), Arg.Any<CancellationToken>());
    }
}