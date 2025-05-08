﻿namespace Loyalty.Domain.Common
{
    public abstract class BaseEntity<TKey>
    {
        public virtual TKey Id { get; protected set; }
    }
}
