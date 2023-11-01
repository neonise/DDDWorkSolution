using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScrumProject.Application.Contract.Members.Commands;
using ScrumProject.Application.Contract.Members.Queries;
using ScrumProject.Domain.Members;

namespace ScrumProject.Api.Controllers;

[ApiController]
[Route("api/members")]
public class MembersController : ControllerBase
{
    private readonly IMediator _mediator;

    public MembersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public async Task<IActionResult> InsertAsync([FromBody] RegisterMemberCommand command, CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(command, cancellationToken);
        return Ok(id);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Member), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAsync([FromQuery] GetMemberQuery query, CancellationToken cancellationToken)
    {
        var member = await _mediator.Send(query, cancellationToken);
        return Ok(member);
    }
}