using MediatR;
using ScrumProject.Application.Contract.Releases.Commands;
using ScrumProject.Domain.Releases;
using ScrumProject.Domain.Sprints;

namespace ScrumProject.Application.Releases.Handlers.Commands;

public class RemoveReleaseCommandHandler : IRequestHandler<RemoveReleaseCommand, Guid>
{
    private readonly IReleaseRepository _releaseRepository;
    private readonly ISprintRepository _sprintRepository;

    public RemoveReleaseCommandHandler(
        IReleaseRepository releaseRepository,
        ISprintRepository sprintRepository)
    {
        _releaseRepository = releaseRepository;
        _sprintRepository = sprintRepository;
    }

    public Task<Guid> Handle(RemoveReleaseCommand request, CancellationToken cancellationToken)
    {
        var release = _releaseRepository.Get(request.ReleaseId);
        var sprintsExist = _sprintRepository.ExistByReleaseId(release.Id);
        if (sprintsExist)
            throw new Exception();

        _releaseRepository.Delete(release);
        return Task.FromResult(release.Id);
    }
}
