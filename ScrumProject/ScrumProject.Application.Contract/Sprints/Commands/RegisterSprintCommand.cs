using MediatR;

namespace ScrumProject.Application.Contract.Sprints.Commands;
public class RegisterSprintCommand : IRequest<Guid>
{
    public string Title { get; set; }
    public DateTime ToDate { get; set; }
    public DateTime FromDate { get; set; }
    public Guid ReleaseId { get; set; }
}
