using System.Collections.Immutable;

namespace Library.Domain;
public abstract class AggregateRoot<TId> : Entity<TId>
{
    private readonly IList<IDomainEvent> _events;
    protected AggregateRoot() : base()
    {
        _events = new List<IDomainEvent>();
    }

    public IReadOnlyCollection<IDomainEvent> Events => _events.ToImmutableArray();

    public void ClearEvents()
    {
        _events.Clear();
    }

    protected void AddEvent<TE>(TE @event) where TE : IDomainEvent
    {
        _events.Add(@event);
    }
}
