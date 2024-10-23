using MediatR;

namespace ToDo.Application.Queries.GetSpecific;

/// <summary>
/// Query definition
/// </summary>
public class GetSpecificToDoTaskQuery : IRequest<SpecificToDoTaskDto>
{
    public Guid Id { get; set; }
}