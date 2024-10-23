using ToDo.Application.Abstractions;

namespace ToDo.Application.Exceptions;

public class InvalidTimeFilter() 
    : ToDoException("Invalid time filter");