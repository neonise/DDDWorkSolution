using MediatR;
using ScrumProject.Application.Contract.Members.Queries;
using ScrumProject.Domain.Members;

namespace ScrumProject.Application.Members.Queries;

public class GetMemberQueryHandler : IRequestHandler<GetMemberQuery, Member>
{
    private readonly IMemberRepository _memberRepository;

    public GetMemberQueryHandler(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }
    public Task<Member> Handle(GetMemberQuery request, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
            cancellationToken.ThrowIfCancellationRequested();

        var member = _memberRepository.Get(request.MemberId);
        return Task.FromResult(member);
    }
}
