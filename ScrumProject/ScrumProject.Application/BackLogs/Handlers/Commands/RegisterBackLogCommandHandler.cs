using MediatR;
using ScrumProject.Application.Contract.BackLogs.Commands;
using ScrumProject.Domain.BackLogs;
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

    public async Task<Guid> Handle(RegisterBackLogCommand request, CancellationToken cancellationToken)
    {
        var sprint = await _sprintRepository.GetAsync(request.SprintId, cancellationToken);
        var backLog = BackLog.CreateNew(sprint.Id, request.Title, request.Description);
        _backLogRepository.Insert(backLog);
        return backLog.Id;
    }
}
