using ScrumProject.Domain.Members;

namespace ScrumProject.Persistence.Repositories;

public class MemberRepository : IMemberRepository
{
    private static readonly List<Member> Members = new();
    public Member Get(int id)
    {
        return Members.SingleOrDefault(m => m.Id == id);
    }

    public void Insert(Member member)
    {
        Members.Add(member);
    }
}
