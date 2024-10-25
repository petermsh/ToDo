using System.Text.Json;
using Microsoft.AspNetCore.Http;
using ToDo.Application.Abstractions;

namespace ToDo.Application.Exceptions.Middleware;

/// <summary>
/// Logic for exception middleware
/// </summary>
public class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (ToDoException ex)
        {
            // Set response code and response type
            context.Response.StatusCode = 400;
            context.Response.Headers.Add("content-type", "application/json");

            // Set error code based by exception type
            var errorCode = ToUnderscoreCase(ex.GetType().Name.Replace("Exception", string.Empty));
            // Make json response
            var json = JsonSerializer.Serialize(new {ErrorCode = errorCode, ex.Message});
            // Send error message
            await context.Response.WriteAsync(json);
        }
    }
    
    // Method for setting underscore case
    private static string ToUnderscoreCase(string value)
        => string.Concat((value ?? string.Empty).Select((x, i) => i > 0 && char.IsUpper(x) && !char.IsUpper(value[i-1]) ? $"_{x}" : x.ToString())).ToLower();
}