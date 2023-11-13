using MediatR;
using ScrumProject.Application.Contract.BackLogs.Commands;
using ScrumProject.Domain.BackLogs;
using ScrumProject.Domain.Interfaces;

namespace ScrumProject.Application.BackLogs.Handlers.Commands;

public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand, Guid>
{
    private readonly IBackLogRepository _backLogRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddCommentCommandHandler(IBackLogRepository backLogRepository, IUnitOfWork unitOfWork)
    {
        _backLogRepository = backLogRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(AddCommentCommand request, CancellationToken cancellationToken)
    {
        var backLog = await _backLogRepository.GetAsync(request.BackLogId, cancellationToken);
        backLog.AddComment(request.CommentText);
        await _unitOfWork.CommitAsync(cancellationToken);
        return backLog.Id;
    }
}
