using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ToDo.Api.Controllers;

/// <summary>
/// Base controller
/// </summary>
[ApiController]
[Route("api/[controller]")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
public class BaseApiController : ControllerBase
{
    // Private field for IMediator instance
    private IMediator? _mediator;

    // Property thar retrieves IMediator service from the HttpContext
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
    
}