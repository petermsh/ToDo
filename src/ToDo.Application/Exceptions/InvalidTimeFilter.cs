using ToDo.Application.Abstractions;

namespace ToDo.Application.Exceptions;

public class InvalidTimeFilterException() 
    : ToDoException("Invalid time filter");