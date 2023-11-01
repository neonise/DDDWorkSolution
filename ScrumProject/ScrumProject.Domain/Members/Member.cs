using Library.Domain;
using ScrumProject.Domain.Members.Enums;

namespace ScrumProject.Domain.Members;
public class Member : AggregateRoot<int>
{
    public string Title { get; init; }
    public MemberType MemberType { get; init; }

    public Member(string title, MemberType memberType)
    {
        CheckRule(title);
        Title = title;
        MemberType = memberType;
        SetEntityId();
    }

    private void SetEntityId()
    {
        var random = new Random();
        Id = random.Next(1, 100);
    }

    private void CheckRule(string title)
    {
        if (string.IsNullOrEmpty(title))
            throw new ArgumentNullException(nameof(title));
    }
}
