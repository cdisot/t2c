using System;
using System.Linq.Expressions;

namespace CC.Core.Mapping
{
    public interface IMapping<TSource, TDestination>
    {
        IMapping<TSource, TDestination> Ignore<TProp>(Expression<Func<TDestination, object>> member);

        IMapping<TSource, TDestination> Map(Expression<Func<TDestination, object>> destinationMember,
            Expression<Func<TSource, object>> sourceMember);

        IMapping<TSource, TDestination> Include<TSourceChild, TDestinationChild>()
            where TSourceChild : TSource
            where TDestinationChild : TDestination;

        void LoadMapperFrom<T>();
    }

    public abstract class MapperConfigurationBase
    {
        protected abstract void Configure(IMapper mapper);
    }
}