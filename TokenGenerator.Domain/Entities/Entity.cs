namespace TokenGenerator.Domain.Entities
{
    using System;

    public abstract class Entity
    {
        public Entity() => Id = Guid.NewGuid();

        public Guid Id { get; private set; }
    }
}