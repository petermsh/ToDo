using MediatR;

namespace ToDo.Application.Commands.CreateToDoTask;

public record CreateToDoTaskCommand(string Title, string Description, DateTime ExpiryAt, int CompletionPercentage) : IRequest;