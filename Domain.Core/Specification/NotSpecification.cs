
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Core.Specification
{
    /// <summary>
    /// NotEspecification convert a original
    /// specification with NOT logic operator
    /// </summary>
    /// <typeparam name="TEntity">
    /// </typeparam>
    public sealed class NotSpecification<TEntity> : Specification<TEntity>
        where TEntity : Entity
    {
        #region Members

        private readonly Expression<Func<TEntity, bool>> _originalCriteria;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="NotSpecification{TEntity}"/> class. 
        /// Constructor for NotSpecificaiton
        /// </summary>
        /// <param name="originalSpecification">
        /// Original specification
        /// </param>
        public NotSpecification(ISpecification<TEntity> originalSpecification)
        {
            if (originalSpecification == null)
            {
                throw new ArgumentNullException("originalSpecification");
            }

            _originalCriteria = originalSpecification.SatisfiedBy();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotSpecification{TEntity}"/> class. 
        /// Constructor for NotSpecification
        /// </summary>
        /// <param name="originalSpecification">
        /// Original specificaiton
        /// </param>
        public NotSpecification(Expression<Func<TEntity, bool>> originalSpecification)
        {
            if (originalSpecification == null)
            {
                throw new ArgumentNullException("originalSpecification");
            }

            _originalCriteria = originalSpecification;
        }

        #endregion

        #region Override Specification methods

        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            return Expression.Lambda<Func<TEntity, bool>>(
                Expression.Not(_originalCriteria.Body), _originalCriteria.Parameters.Single());
        }

        #endregion
    }
}
