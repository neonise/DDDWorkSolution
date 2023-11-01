using MediatR;
using ScrumProject.Domain.Members.Enums;

namespace ScrumProject.Application.Contract.Members.Commands;

public class RegisterMemberCommand : IRequest<int>
{
    public string Title { get; set; }
    public MemberType MemberType { get; set; }
}
