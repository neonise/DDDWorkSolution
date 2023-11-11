using MediatR;
using ScrumProject.Application.Contract.BackLogs.Commands;
using ScrumProject.Domain.BackLogs;

namespace ScrumProject.Application.BackLogs.Handlers.Commands;

public class RemoveCommentCommandHandler : IRequestHandler<RemoveCommentCommand, Unit>
{
    private readonly IBackLogRepository _backLogRepository;

    public RemoveCommentCommandHandler(IBackLogRepository backLogRepository)
    {
        _backLogRepository = backLogRepository;
    }

    public async Task<Unit> Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
    {
        var backLog = await _backLogRepository.GetAsync(request.BackLogId, cancellationToken);
        var backLogComment = backLog.BackLogComments.FirstOrDefault(x => x.Id == request.BackLogCommentId);
        backLog.RemoveComment(backLogComment);
        await _backLogRepository.CommitAsync(cancellationToken);
        return Unit.Value;
    }
}
