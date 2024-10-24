using MediatR;

namespace ToDo.Application.Commands.SetToDoTaskCompletionPercentage;

/// <summary>
/// Command for setting CompletionPercentage
/// </summary>
/// <param name="id"></param>
/// <param name="completionPercentage"></param>
public class SetToDoTaskCompletionPercentageCommand() : IRequest
{
    public Guid Id { get; init; }
    public int CompletionPercentage { get; init; }
}