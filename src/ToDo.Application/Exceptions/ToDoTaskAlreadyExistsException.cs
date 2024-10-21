using ToDo.Application.Abstractions;

namespace ToDo.Application.Exceptions;

public class ToDoTaskAlreadyExistsException(string title) 
    : ToDoException($"ToDoTask with title {title} already exists.")
{
}