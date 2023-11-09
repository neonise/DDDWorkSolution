using MediatR;

namespace ScrumProject.Application.Contract.BackLogs.Commands;
public class RegisterBackLogCommand : IRequest<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid SprintId { get; set; }
}
