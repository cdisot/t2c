using AutoMapper;
using Domain.T2C;
using T2C.Models;

namespace T2C.AutoMapper
{
    public class DomainToViewMappingProfile:Profile
    {
        public override string ProfileName {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {

            //Celular 
            Mapper.CreateMap<CellModel, Cell>();
            Mapper.CreateMap<UserModel, UserCell>();
            Mapper.CreateMap<ImagenModel, Imagen>();

        }
    }
}