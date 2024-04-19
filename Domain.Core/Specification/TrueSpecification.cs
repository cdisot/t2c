
using System;
using System.Linq.Expressions;

namespace Domain.Core.Specification
{
    /// <summary>
    /// True specification
    /// </summary>
    public sealed class TrueSpecification<TEntity>
        :Specification<TEntity>
        where TEntity:Entity
    {
        #region Specification overrides

        /// <summary>
        /// <see cref=" Specification{TEntity}"/>
        /// </summary>
        /// <returns><see cref=" Specification{TEntity}"/></returns>
        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            const bool result = true;

            Expression<Func<TEntity, bool>> trueExpression = t => result;
            return trueExpression;
        }

        #endregion
    }
}
