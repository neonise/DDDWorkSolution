namespace Library.Domain;
public abstract class AggregateRoot<TId> : Entity<TId>
{
    protected AggregateRoot() : base()
    {
    }
}
