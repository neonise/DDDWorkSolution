using MediatR;
using ScrumProject.Application.Contract.Sprints.Commands;
using ScrumProject.Domain.Releases;
using ScrumProject.Domain.Releases.ValueObjects;
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

    public Task<Guid> Handle(RegisterSprintCommand request, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
            cancellationToken.ThrowIfCancellationRequested();

        var release = _releaseRepository.Get(request.ReleaseId);
        var sprint = Sprint.CreateNew(release.Id, new SprintTitle(request.Title), request.FromDate, request.ToDate);
        _sprintRepository.Insert(sprint);
        return Task.FromResult(sprint.Id);
    }
}
