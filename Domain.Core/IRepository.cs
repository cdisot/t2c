using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Core.Specification;

namespace Domain.Core
{
    public interface IRepository<TEntity> where TEntity: Entity
    {
        /// <summary>
        /// Add item into repository
        /// </summary>
        /// <param name="item">Item to add to repository</param>
        TEntity Add(TEntity item);


        /// <summary>
        /// Delete item 
        /// </summary>
        /// <param name="item">Item to delete</param>
        void Remove(TEntity item);

        /// <summary>
        /// Delete item 
        /// </summary>
        /// <param name="id">Id of item to delete</param>
        void Remove(Guid id);

        void Update(TEntity persited);

        /// <summary>
        /// Get element by entity key
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// Entity 
        /// </returns>
        TEntity GetById(Guid id);

        TEntity GetByName(string name);

        TEntity FirstOrDefaultMatching(ISpecification<TEntity> specification) ;

        /// <summary>
        /// Get all elements of type {T} in repository
        /// </summary>
        /// <returns>List of selected elements</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Get all elements of type {T} that matching a
        /// Specification <paramref name="specification"/>
        /// </summary>
        /// <param name="specification">Specification that result meet</param>
        /// <returns>IEnumerable of Entities that matching the specification</returns>
        IEnumerable<TEntity> AllMatching(ISpecification<TEntity> specification);

        /// <summary>
        /// Get all elements of type {T} in repository
        /// </summary>
        /// <typeparam name="TKProperty">
        /// Entity Type
        /// </typeparam>
        /// <param name="pageIndex">
        /// Page index
        /// </param>
        /// <param name="pageCount">
        /// Number of elements in each page
        /// </param>
        /// <param name="orderByExpression">
        /// Order by expression for this query
        /// </param>
        /// <param name="ascending">
        /// Specify if order is ascending
        /// </param>
        /// <returns>
        /// List of selected elements
        /// </returns>
        IEnumerable<TEntity> GetPaged<TKProperty>(int pageIndex, int pageCount, Expression<Func<TEntity, TKProperty>> orderByExpression, bool ascending);

        /// <summary>
        /// Get  elements of type {T} in repository
        /// </summary>
        /// <param name="filter">Filter that each element do match</param>
        /// <returns>List of selected elements</returns>
        IEnumerable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> filter);

        IQueryable<TEntity> CreateSet();

        IUnitOfWork BeginTransaction();

        bool AnyMatching(ISpecification<TEntity> specification);

        TEntity Get(ISpecification<TEntity> specification);
    }
}
