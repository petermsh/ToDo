using NSubstitute;
using ToDo.Application.Commands.CreateToDoTask;
using ToDo.Application.Exceptions;
using ToDo.Application.Services;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;

namespace ToDo.UnitTests.Application;

/// <summary>
/// Tests for CreateToDoTaskHandler
/// </summary>
public class CreateToDoTaskHandlerTests
{
  private readonly IToDoTaskRepository _repository;
  private readonly IToDoTasksReadService _readService;
  private readonly CreateToDoTaskHandler _handler;

  public CreateToDoTaskHandlerTests()
  {
    // Create substitutes for the dependencies
    _repository = Substitute.For<IToDoTaskRepository>();
    _readService = Substitute.For<IToDoTasksReadService>();
        
    // Create the handler with the mocked dependencies
    _handler = new CreateToDoTaskHandler(_repository, _readService);
  }
  
  [Fact]
  public async Task Handle_ShouldThrowToDoTaskAlreadyExistsException_WhenTitleAlreadyExists()
  {
    // Arrange
    var command = new CreateToDoTaskCommand("Test Title", "Test Description", DateTime.UtcNow.AddDays(1), 0);

    // Act
    // Mock ExistsByTitleAsync to return true
    _readService.ExistsByTitleAsync(Arg.Any<string>()).Returns(true);

    // Assert
    await Assert.ThrowsAsync<ToDoTaskAlreadyExistsException>(() => _handler.Handle(command, CancellationToken.None));

    // Verify that AddAsync is never called since exception is thrown
    await _repository.DidNotReceive().AddAsync(Arg.Any<ToDoTask>(), Arg.Any<CancellationToken>());
  }
}