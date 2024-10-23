namespace ToDo.Application.Abstractions;

/// <summary>
/// Base class for project exception
/// </summary>
/// <param name="message"></param>
public abstract class ToDoException(string message) : Exception(message);