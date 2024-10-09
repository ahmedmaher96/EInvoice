using AutoMapper;
using EInvoice.BLL.DTO;
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
            CreateMap<CustomerDTO, Customer>();
            CreateMap<Customer, CustomerDTO>();
            CreateMap<TaxDTO, Tax>();
            CreateMap<Tax, TaxDTO>();
        }
    }
}
