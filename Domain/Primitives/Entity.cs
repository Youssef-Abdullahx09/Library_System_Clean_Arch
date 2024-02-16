namespace Domain.Primitives
{
    public abstract class Entity : IEquatable<Entity>
    {
        public Guid Id { get; }

        protected Entity(Guid id)
        {
            Id = id;
        }
        public static bool operator ==(Entity? left, Entity? right)
        {
            if (ReferenceEquals(left, right))
                return true;

            if (left is null || right is null)
                return false;

            return left.Equals(right);
        }

        public static bool operator !=(Entity? left, Entity? right) => !(left == right);
        public override bool Equals(object? obj)
        {
            if (obj is not Entity entity)
                return false;

            if (ReferenceEquals(this, entity))
                return true;

            return GetType() == entity.GetType() && Id.Equals(entity.Id);
        }

        public bool Equals(Entity? other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return GetType() == other.GetType() && Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
