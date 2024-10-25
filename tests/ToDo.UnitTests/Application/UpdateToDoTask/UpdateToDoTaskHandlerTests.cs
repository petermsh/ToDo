using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using NSubstitute;
using ToDo.Application.Commands.UpdateToDoTask;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;

namespace ToDo.UnitTests.Application.UpdateToDoTask;

public class UpdateToDoTaskHandlerTests
{
    private readonly IToDoTaskRepository _repository;
    private readonly IValidator<UpdateToDoTaskCommand> _validator;
    private readonly UpdateToDoTaskHandler _handler;

    public UpdateToDoTaskHandlerTests()
    {
        _repository = Substitute.For<IToDoTaskRepository>();
        _validator = Substitute.For<IValidator<UpdateToDoTaskCommand>>();
        _handler = new UpdateToDoTaskHandler(_repository, _validator);
    }

    [Fact]
    public async void Handle_WhenDataIsValid_UpdatesToDoTask()
    {
        //Arrange
        var command = new UpdateToDoTaskCommand
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            Title = "Correct title",
            Description = "Correct description",
            ExpiryAt = new DateTime(2025, 10, 26, 15, 30, 10).ToUniversalTime()
        };
        
        // Create a ToDoTask object to return from the repository
        var toDoTask = ToDoTask.CreateWithId(
            command.Id,
            "Old title",
            "Old description",
            DateTime.UtcNow.AddDays(1),
            0); // Initial CompletionPercentage is 0

        // Mock the validator to return a valid result
        _validator.ValidateAsync(command, Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(new ValidationResult()));

        // Setup the repository to return the existing toDoTask when GetAsync is called
        _repository.GetAsync(command.Id, Arg.Any<CancellationToken>())
            .Returns(toDoTask);

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        toDoTask.Title.Should().Be(command.Title);
        toDoTask.Description.Should().Be(command.Description); 
        toDoTask.ExpiryAt.Should().Be(command.ExpiryAt); 
        
        // Verify that the UpdateAsync was called with the updated ToDoTask
        await _repository.Received(1).UpdateAsync(Arg.Is<ToDoTask>(t =>
            t.Title == command.Title &&
            t.Description == command.Description &&
            t.ExpiryAt == command.ExpiryAt), Arg.Any<CancellationToken>());
    }
}