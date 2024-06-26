﻿using System;
using System.Linq.Expressions;

namespace Domain.Core.Specification
{
    /// <summary>
    /// A logic AND Specification
    /// </summary>
    /// <typeparam name="T">Type of entity that check this specification</typeparam>
    public sealed class AndSpecification<T>
       : CompositeSpecification<T>
       where T :Entity
    {
        #region Members

        /// <summary>
        /// Right Side
        /// </summary>
        private readonly ISpecification<T> _rightSideSpecification;

        /// <summary>
        /// Left Side
        /// </summary>
        private readonly ISpecification<T> _leftSideSpecification;

        #endregion

        #region Public Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="AndSpecification{T}"/> class. 
        /// Default constructor for AndSpecification
        /// </summary>
        /// <param name="leftSide">
        /// Left side specification
        /// </param>
        /// <param name="rightSide">
        /// Right side specification
        /// </param>
        public AndSpecification(ISpecification<T> leftSide, ISpecification<T> rightSide)
        {
            if (leftSide == null)
            {
                throw new ArgumentNullException("leftSide");
            }

            if (rightSide == null)
            {
                throw new ArgumentNullException("rightSide");
            }

            _leftSideSpecification = leftSide;
            _rightSideSpecification = rightSide;
        }

        #endregion

        #region Composite Specification overrides

        /// <summary>
        /// Left side specification
        /// </summary>
        public override ISpecification<T> LeftSideSpecification
        {
            get { return _leftSideSpecification; }
        }

        /// <summary>
        /// Right side specification
        /// </summary>
        public override ISpecification<T> RightSideSpecification
        {
            get { return _rightSideSpecification; }
        }

        /// <summary>
        /// Satisfy condition
        /// </summary>
        /// <returns>
        /// true is satisfy
        /// </returns>
        public override Expression<Func<T, bool>> SatisfiedBy()
        {
            var left = _leftSideSpecification.SatisfiedBy();
            var right = _rightSideSpecification.SatisfiedBy();

            return left.And(right);
        }

        #endregion
    }
}
