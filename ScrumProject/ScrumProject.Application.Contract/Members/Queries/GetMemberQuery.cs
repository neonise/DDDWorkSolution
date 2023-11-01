using MediatR;
using ScrumProject.Domain.Members;

namespace ScrumProject.Application.Contract.Members.Queries;
public class GetMemberQuery : IRequest<Member>
{
    public int MemberId { get; set; }
}
