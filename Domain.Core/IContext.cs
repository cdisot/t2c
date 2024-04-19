using System.Linq;

namespace Domain.Core
{
    public interface IContext
    {
        IQueryable<TEntity> CreateSet<TEntity>() where TEntity : class;
        
        /// <summary>
        /// Add this item into the Context
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="item">The item </param>
        TEntity Add<TEntity>(TEntity item) where TEntity : class;

        /// <summary>
        /// Set object as modified
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="item">The entity item to set as modified</param>
        void Update<TEntity>(TEntity item) where TEntity : class;

        void Delete<TEntity>(TEntity item) where TEntity : class;

        int SaveChanges();
        IUnitOfWork BeginTransaction();
    }
}
