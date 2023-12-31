﻿namespace Library.Domain;
public abstract class Entity<TId> : IEquatable<Entity<TId>>
{
    public TId Id { get; protected set; }
    public override bool Equals(object obj)
    {
        var entity = obj as Entity<TId>;
        if (entity is not null)
            return Equals(entity);

        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public bool Equals(Entity<TId> other)
    {
        if (other == null)
            return false;

        return Id.Equals(other.Id);
    }
}