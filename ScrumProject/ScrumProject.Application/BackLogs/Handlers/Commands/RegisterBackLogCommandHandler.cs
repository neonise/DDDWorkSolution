using MediatR;
using ScrumProject.Application.Contract.BackLogs.Commands;
using ScrumProject.Domain.BackLogs;
using ScrumProject.Domain.Releases.ValueObjects;
using ScrumProject.Domain.Sprints;

namespace ScrumProject.Application.BackLogs.Handlers.Commands;
public class RegisterBackLogCommandHandler : IRequestHandler<RegisterBackLogCommand, Guid>
{
    private readonly ISprintRepository _sprintRepository;
    private readonly IBackLogRepository _backLogRepository;

    public RegisterBackLogCommandHandler(
        ISprintRepository sprintRepository,
        IBackLogRepository backLogRepository)
    {
        _sprintRepository = sprintRepository;
        _backLogRepository = backLogRepository;
    }

    public Task<Guid> Handle(RegisterBackLogCommand request, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
            cancellationToken.ThrowIfCancellationRequested();

        var sprint = _sprintRepository.Get(request.SprintId);
        var backLog = BackLog.CreateNew(sprint, new BackLogTitle(request.Title), request.Description);
        _backLogRepository.Insert(backLog);
        return Task.FromResult(backLog.Id);
    }
}
