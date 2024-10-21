namespace ToDo.Application.Abstractions;

public abstract class ToDoException(string message) : Exception(message);