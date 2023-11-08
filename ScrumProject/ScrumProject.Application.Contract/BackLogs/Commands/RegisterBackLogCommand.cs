using MediatR;

namespace ScrumProject.Application.Contract.BackLogs.Commands;
public class RegisterBackLogCommand : IRequest<Guid>
{
    public string Title { get; init; }
    public string Description { get; init; }
    public Guid SprintId { get; set; }
}
