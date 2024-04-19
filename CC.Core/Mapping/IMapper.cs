namespace CC.Core.Mapping
{
    public interface IMapper
    {
        IMapping<TSource, TDestination> CreateMap<TSource, TDestination>();

        bool AssertMapping(bool throwOnError);
        TDestination Map<TSource, TDestination>(TSource source);
        TDestination Map<TDestination>(object source);
    }
}