namespace Library.Domain;
public abstract class ValueObject
{
    public static bool operator ==(ValueObject left, ValueObject right)
    {
        if (Equals(left, null))
        {
            if (Equals(right, null))
                return true;

            return false;
        }
        return left.Equals(right);
    }

    public static bool operator !=(ValueObject left, ValueObject right)
    {
        return !(left == right);
    }

    protected abstract IEnumerable<object> GetEqualityComponents();
    public override bool Equals(object obj)
    {
        if (obj is null || obj.GetType() != GetType())
            return false;

        var other = (ValueObject)obj;
        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x != null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
    }
}