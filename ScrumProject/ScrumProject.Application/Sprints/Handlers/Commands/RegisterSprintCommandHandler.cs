using MediatR;
using ScrumProject.Application.Contract.Sprints.Commands;
using ScrumProject.Domain.Releases;
using ScrumProject.Domain.Sprints;

namespace ScrumProject.Application.Sprints.Handlers.Commands;

public class RegisterSprintCommandHandler : IRequestHandler<RegisterSprintCommand, Guid>
{
    private readonly IReleaseRepository _releaseRepository;
    private readonly ISprintRepository _sprintRepository;

    public RegisterSprintCommandHandler(
        IReleaseRepository releaseRepository,
        ISprintRepository sprintRepository)
    {
        _releaseRepository = releaseRepository;
        _sprintRepository = sprintRepository;
    }

    public async Task<Guid> Handle(RegisterSprintCommand request, CancellationToken cancellationToken)
    {
        var release = await _releaseRepository.GetAsync(request.ReleaseId, cancellationToken);
        var sprint = Sprint.CreateNew(release.Id, request.Title, request.FromDate, request.ToDate);
        _sprintRepository.Insert(sprint);
        return sprint.Id;
    }
}
