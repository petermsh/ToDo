using ToDo.Application.Abstractions;

namespace ToDo.Application.Exceptions;

/// <summary>
/// Exception thrown when a ToDoTask wih given title already exists
/// </summary>
/// <param name="title"></param>
public class ToDoTaskAlreadyExistsException(string title) 
    : ToDoException($"ToDoTask with title {title} already exists.")
{
}