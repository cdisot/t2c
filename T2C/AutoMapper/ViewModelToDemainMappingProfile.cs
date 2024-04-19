using AutoMapper;
using Domain.T2C;
using T2C.Models;

namespace T2C.AutoMapper
{
    public class ViewModelToDemainMappingProfile:Profile
    {

        public override string ProfileName
        {
            get { return "DomainToViewMappings"; }
        }

        protected override void Configure()
        {


            //Agencia de turismo 


            Mapper.CreateMap<Cell, CellModel>();
            Mapper.CreateMap<UserCell, UserModel>();
            Mapper.CreateMap<Imagen, ImagenModel>();
       
        }
    }
}