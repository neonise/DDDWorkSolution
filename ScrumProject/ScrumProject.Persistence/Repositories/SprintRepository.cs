using ScrumProject.Domain.Products;
using ScrumProject.Domain.Products.ValueObjects;
using ScrumProject.Domain.Releases;
using ScrumProject.Domain.Releases.ValueObjects;
using ScrumProject.Domain.Sprints;

namespace ScrumProject.Persistence.Repositories;

public class SprintRepository : ISprintRepository
{
    private static readonly List<Sprint> Sprints = new()
    {
        Sprint.CreateNew(Release.CreateNew(new Product(new ProductTitle("OMS"),
                                                       DateTime.Now,
                                                       DateTime.Now.AddDays(21)),new ReleaseTitle("release1"),DateTime.Now),
                         new SprintTitle("Sprint1"),
                         DateTime.Now,
                         DateTime.Now.AddMonths(1))
    };

    public Sprint Get(Guid id)
    {
        return Sprints.SingleOrDefault(x => x.Id == id);
    }

    public void Insert(Sprint sprint)
    {
        Sprints.Add(sprint);
    }
}
