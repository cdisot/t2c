using Domain.Core.Specification;

namespace Domain.Core
{
    public class EntitySpecification<TEntity>
        where TEntity: Entity
    {
        /// <summary>
        /// Specification for any entity that is active, equal to not removed ["soft delete"]
        /// </summary>
        /// <returns>specification that represent the active entity condition</returns>
        public static ISpecification<TEntity> IsNotRemoveEntity()
        {
            return new DirectSpecification<TEntity>(e => true);
        }
    }
}
