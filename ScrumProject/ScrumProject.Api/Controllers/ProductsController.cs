using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScrumProject.Application.Contract.Products.Commands;
using ScrumProject.Application.Contract.Products.Queries;
using ScrumProject.Domain.Products;

namespace ScrumProject.Api.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public async Task<IActionResult> InsertAsync([FromBody] RegisterProductCommand command, CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(command, cancellationToken);
        return Ok(id);
    }

    [HttpPost("release")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public async Task<IActionResult> InsertReleaseAsync([FromBody] RegisterReleaseCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    [HttpPost("sprint")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public async Task<IActionResult> InsertSprintAsync([FromBody] RegisterSprintCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    [HttpPost("backlog")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public async Task<IActionResult> InsertBackLogAsync([FromBody] RegisterBackLogCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    [HttpPut("assign-backlog")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public async Task<IActionResult> AssignBackLogAsync([FromBody] AssignBackLogCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAsync([FromQuery] GetProductQuery query, CancellationToken cancellationToken)
    {
        var product = await _mediator.Send(query, cancellationToken);
        return Ok(product);
    }
}
