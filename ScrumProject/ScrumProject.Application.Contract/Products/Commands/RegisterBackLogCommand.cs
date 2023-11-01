using MediatR;

namespace ScrumProject.Application.Contract.Products.Commands;
public class RegisterBackLogCommand : IRequest
{
    public string Title { get; init; }
    public string Description { get; init; }
    public int? MemberId { get; private set; }
    public int SprintId { get; set; }
}
