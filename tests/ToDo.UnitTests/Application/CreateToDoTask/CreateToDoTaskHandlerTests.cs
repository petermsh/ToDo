using FluentValidation;
using FluentValidation.Results;
using NSubstitute;
using ToDo.Application.Commands.CreateToDoTask;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;


namespace ToDo.UnitTests.Application.CreateToDoTask;

public class CreateToDoTaskHandlerTests
{
    private readonly IToDoTaskRepository _repository;
    private readonly IValidator<CreateToDoTaskCommand> _validator;
    private readonly CreateToDoTaskHandler _handler;
    
    public CreateToDoTaskHandlerTests()
    {
        _repository = Substitute.For<IToDoTaskRepository>();
        _validator = Substitute.For<IValidator<CreateToDoTaskCommand>>();
        _handler = new CreateToDoTaskHandler(_repository, _validator);
    }
    
    [Fact]
    public async void Handle_WhenDataIsValid_CreatesToDoTask()
    {
        //Arrange
        var command = new CreateToDoTaskCommand(
            "Correct title",
            "Correct description",
            new DateTime(2025, 10, 26, 15, 30, 10).ToUniversalTime(),
            0);
        
        // Mock the validator to return a valid result
        _validator.ValidateAsync(command, Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(new ValidationResult()));
        
        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        await _repository.Received(1).AddAsync(Arg.Any<ToDoTask>(), Arg.Any<CancellationToken>());
    }
}