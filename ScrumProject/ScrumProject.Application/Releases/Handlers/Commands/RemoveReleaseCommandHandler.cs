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

    public async Task<Guid> Handle(RemoveReleaseCommand request, CancellationToken cancellationToken)
    {
        var release = await _releaseRepository.GetAsync(request.ReleaseId,cancellationToken);
        var sprintsExist = await _sprintRepository.ExistByReleaseIdAsync(release.Id,cancellationToken);
        if (sprintsExist)
            throw new Exception();

        _releaseRepository.Delete(release);
        return release.Id;
    }
}
