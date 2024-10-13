using CleanArchitecture.Application.Commands;
using CleanArchitecture.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await mediator.Send(new PostQuery()));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreatePostCommand command)
    {
        await mediator.Send(command);
        return Created();
    }
}
