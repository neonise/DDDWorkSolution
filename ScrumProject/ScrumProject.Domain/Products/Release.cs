using Library.Domain;

namespace ScrumProject.Domain.Products;

public class Release : Entity<int>
{
    public HashSet<Sprint> Sprints { get; private set; }
    public Release()
    {
    }
}
