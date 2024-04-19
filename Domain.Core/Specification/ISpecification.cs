
using System;
using System.Linq.Expressions;

namespace Domain.Core.Specification
{
    public interface ISpecification<TEntity> 
        where TEntity : Entity
    {
        /// <summary>
        /// Check if this specification is satisfied by a 
        /// specific expression lambda
        /// </summary>
        /// <returns>Expression to be evaluated</returns>
        Expression<Func<TEntity, bool>> SatisfiedBy();
    }
}
