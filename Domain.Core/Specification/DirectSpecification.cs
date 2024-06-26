﻿
using System;
using System.Linq.Expressions;

namespace Domain.Core.Specification
{
    public sealed class DirectSpecification<TEntity>
        : Specification<TEntity>
        where TEntity : Entity
    {
        #region Members

        readonly Expression<Func<TEntity, bool>> _matchingCriteria;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor for Direct Specification
        /// </summary>
        /// <param name="matchingCriteria">A Matching Criteria</param>
        public DirectSpecification(Expression<Func<TEntity, bool>> matchingCriteria)
        {
            if (matchingCriteria == null)
                throw new ArgumentNullException("matchingCriteria");

            _matchingCriteria = matchingCriteria;
        }

        #endregion

        #region Override

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            return _matchingCriteria;
        }

        #endregion
    }
}
