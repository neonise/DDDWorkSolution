using MediatR;
using ScrumProject.Application.Contract.BackLogs.Commands;
using ScrumProject.Domain.BackLogs;
using ScrumProject.Domain.Interfaces;
using ScrumProject.Domain.Sprints;

namespace ScrumProject.Application.BackLogs.Handlers.Commands;
public class RegisterBackLogCommandHandler : IRequestHandler<RegisterBackLogCommand, Guid>
{
    private readonly ISprintRepository _sprintRepository;
    private readonly IBackLogRepository _backLogRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterBackLogCommandHandler(
        ISprintRepository sprintRepository,
        IBackLogRepository backLogRepository,
        IUnitOfWork unitOfWork)
    {
        _sprintRepository = sprintRepository;
        _backLogRepository = backLogRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(RegisterBackLogCommand request, CancellationToken cancellationToken)
    {
        var sprint = await _sprintRepository.GetAsync(request.SprintId, cancellationToken);
        var backLog = BackLog.CreateNew(sprint.Id, request.Title, request.Description);
        await _backLogRepository.AddAsync(backLog, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
        return backLog.Id;
    }
}
