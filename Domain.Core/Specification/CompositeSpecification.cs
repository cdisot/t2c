﻿namespace Domain.Core.Specification
{
    public abstract class CompositeSpecification<TEntity>
         : Specification<TEntity>
         where TEntity : Entity
    {
        #region Properties

        /// <summary>
        /// Left side specification for this composite element
        /// </summary>
        public abstract ISpecification<TEntity> LeftSideSpecification { get; }

        /// <summary>
        /// Right side specification for this composite element
        /// </summary>
        public abstract ISpecification<TEntity> RightSideSpecification { get; }

        #endregion
    }
}
