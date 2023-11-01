using MediatR;
using ScrumProject.Application.Contract.Members.Commands;
using ScrumProject.Domain.Members;

namespace ScrumProject.Application.Members.Commands;

public class RegisterMemberCommandHandler : IRequestHandler<RegisterMemberCommand, int>
{
    private readonly IMemberRepository _memberRepository;

    public RegisterMemberCommandHandler(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }

    public Task<int> Handle(RegisterMemberCommand request, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
            cancellationToken.ThrowIfCancellationRequested();

        var member = new Member(request.Title, request.MemberType);
        _memberRepository.Insert(member);
        return Task.FromResult(member.Id);
    }
}
