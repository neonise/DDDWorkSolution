using MediatR;

namespace ScrumProject.Application.Contract.Products.Commands;

public class AssignBackLogCommand : IRequest
{
    public int MemberId { get; set; }
    public int BackLogId { get; set; }
}
