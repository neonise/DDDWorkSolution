using MediatR;
using ScrumProject.Application.Contract.BackLogs.Commands;
using ScrumProject.Domain.BackLogs;
using ScrumProject.Domain.Interfaces;

namespace ScrumProject.Application.BackLogs.Handlers.Commands;

public class RemoveCommentCommandHandler : IRequestHandler<RemoveCommentCommand, Unit>
{
    private readonly IBackLogRepository _backLogRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveCommentCommandHandler(IBackLogRepository backLogRepository, IUnitOfWork unitOfWork)
    {
        _backLogRepository = backLogRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
    {
        var backLog = await _backLogRepository.GetAsync(request.BackLogId, cancellationToken);
        var backLogComment = backLog.BackLogComments.FirstOrDefault(x => x.Id == request.BackLogCommentId);
        backLog.RemoveComment(backLogComment);
        await _unitOfWork.CommitAsync(cancellationToken);
        return Unit.Value;
    }
}
