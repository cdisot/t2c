using AutoMapper;

namespace T2C.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMapping()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewMappingProfile>();
                x.AddProfile<ViewModelToDemainMappingProfile>();
            }

    );
        }
    }
}