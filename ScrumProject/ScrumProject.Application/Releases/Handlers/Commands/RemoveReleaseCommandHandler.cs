using MediatR;
using ScrumProject.Application.Contract.Releases.Commands;
using ScrumProject.Domain.Interfaces;
using ScrumProject.Domain.Releases;
using ScrumProject.Domain.Sprints;

namespace ScrumProject.Application.Releases.Handlers.Commands;

public class RemoveReleaseCommandHandler : IRequestHandler<RemoveReleaseCommand, Guid>
{
    private readonly IReleaseRepository _releaseRepository;
    private readonly ISprintRepository _sprintRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveReleaseCommandHandler(
        IReleaseRepository releaseRepository,
        ISprintRepository sprintRepository,
        IUnitOfWork unitOfWork)
    {
        _releaseRepository = releaseRepository;
        _sprintRepository = sprintRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(RemoveReleaseCommand request, CancellationToken cancellationToken)
    {
        var release = await _releaseRepository.GetAsync(request.ReleaseId,cancellationToken);
        var sprintsExist = await _sprintRepository.ExistByReleaseIdAsync(release.Id,cancellationToken);
        if (sprintsExist)
            throw new Exception();

        _releaseRepository.Delete(release);
        await _unitOfWork.CommitAsync(cancellationToken);
        return release.Id;
    }
}