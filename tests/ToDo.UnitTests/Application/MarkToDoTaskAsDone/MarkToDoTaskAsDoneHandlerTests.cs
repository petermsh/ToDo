using NSubstitute;
using ToDo.Application.Commands.MarkToDoTaskAsDone;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;

namespace ToDo.UnitTests.Application.MarkToDoTaskAsDone;

public class MarkToDoTaskAsDoneHandlerTests
{
    private readonly IToDoTaskRepository _repository;
    private readonly MarkToDoTaskAsDoneHandler _handler;

    public MarkToDoTaskAsDoneHandlerTests()
    {
        _repository = Substitute.For<IToDoTaskRepository>();
        _handler = new MarkToDoTaskAsDoneHandler(_repository);
    }

    [Fact]
    public async void Handle_WhenDataIsValid_MarkToDoTaskAsDone()
    {
        // Arrange
        var command = new MarkToDoTaskAsDoneCommand(Guid.Parse("00000000-0000-0000-0000-000000000001"));

        // Create a ToDoTask object to return from the repository
        var toDoTask = ToDoTask.CreateWithId(
            Guid.Parse("00000000-0000-0000-0000-000000000001"),
            "Test ToDoTask",
            "Test description",
            new DateTime(2025, 04, 26, 15, 30, 10).ToUniversalTime(),
            10); 

        // Setting up the repository to return the toDoTask when GetAsync is called
        _repository.GetAsync(command.Id, Arg.Any<CancellationToken>())
            .Returns(toDoTask);

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        await _repository.Received(1).UpdateAsync(Arg.Is<ToDoTask>(t => t.CompletionPercentage == 100), Arg.Any<CancellationToken>());
    }
}