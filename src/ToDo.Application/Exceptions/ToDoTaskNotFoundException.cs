using ToDo.Application.Abstractions;

namespace ToDo.Application.Exceptions;

public class ToDoTaskNotFoundException(string id) 
    : ToDoException($"ToDoTask with id: {id} not found");