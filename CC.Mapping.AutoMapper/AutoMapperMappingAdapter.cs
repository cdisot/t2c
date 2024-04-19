using System;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using CC.Core.Mapping;

namespace CC.Mapping.AutoMapper
{
    public class AutoMapperMappingAdapter<TS, TD> : IMapping<TS, TD>
    {
        private readonly IMappingExpression<TS, TD> _mappingExpression;

        public AutoMapperMappingAdapter(IMappingExpression<TS, TD> mappingExpression)
        {
            _mappingExpression = mappingExpression;
        }

        public IMapping<TS, TD> Ignore<TProp>(Expression<Func<TD, object>> member)
        {
            _mappingExpression.ForMember(member, o => o.Ignore());
            return this;
        }

        public IMapping<TS, TD> Map(Expression<Func<TD, object>> destinationMember,
            Expression<Func<TS, object>> sourceMember)
        {
            _mappingExpression.ForMember(destinationMember, o => o.MapFrom(sourceMember));
            return this;
        }

        public IMapping<TS, TD> Include<TSourceChild, TDestinationChild>()
            where TSourceChild : TS
            where TDestinationChild : TD
        {
            _mappingExpression.Include<TSourceChild, TDestinationChild>();
            return this;
        }

        public void LoadMapperFrom<T>()
        {
            var type = typeof(T);
            foreach (
                var config in
                    type.Assembly.DefinedTypes.Where(t => t.IsSubclassOf(typeof(MapperConfigurationBase)))
                        .Select(c => c.GetConstructor(new[] { typeof(IMapper) })))
            {
                config.Invoke(new object[] {this});
            }
        }
    }
}
