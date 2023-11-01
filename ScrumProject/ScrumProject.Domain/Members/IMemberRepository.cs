namespace ScrumProject.Domain.Members;

public interface IMemberRepository
{
    void Insert(Member member);
    Member Get(int id);
}
