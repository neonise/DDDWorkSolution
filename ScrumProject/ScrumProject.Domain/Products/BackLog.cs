using Library.Domain;

namespace ScrumProject.Domain.Products;

public class BackLog : Entity<int>
{
    public string Title { get; init; }
    public string Description { get; init; }

    public BackLog(string title, string description)
    {
        Title = title;
        Description = description;
    }
}
