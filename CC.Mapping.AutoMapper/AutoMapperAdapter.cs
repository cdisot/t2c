using System;
using AutoMapper;
using CC.Core.Mapping;

namespace CC.Mapping.AutoMapper
{
    public class AutoMapperAdapter : IMapper
    {
        public IMapping<TSource, TDestination> CreateMap<TSource, TDestination>()
        {
            return new AutoMapperMappingAdapter<TSource, TDestination>(Mapper.CreateMap<TSource, TDestination>());
        }

        public bool AssertMapping(bool throwOnError)
        {
            try
            {
                Mapper.AssertConfigurationIsValid();
                return true;
            }
            catch (Exception)
            {
                if (throwOnError)
                    throw;
            }
            return false;
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }

        public TDestination Map<TDestination>(object source)
        {
            return Mapper.Map<TDestination>(source);
        }
    }
}