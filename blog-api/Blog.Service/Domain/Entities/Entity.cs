using System;

namespace Blog.Service.Domain.Entities
{
    public abstract class Entity
    {
        public long Id { get; protected set; }
        public DateTime CreationDate { get; protected set; }

    }
}
