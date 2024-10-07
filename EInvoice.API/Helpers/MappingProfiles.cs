using AutoMapper;
using EInvoice.API.DTO;
using EInvoice.DAL.Models;

namespace EInvoice.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //CreateMap<model,modeldto>()
            //          .Formember(property,MapFrom(where to find it));
            CreateMap<ItemDTO, Item>();
            CreateMap<Item, ItemDTO>();
        }
    }
}
