using AutoMapper;
using EInvoice.BLL.DTO;
using EInvoice.DAL.Models;

namespace EInvoice.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Item, ItemDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Tax, TaxDTO>().ReverseMap();
            CreateMap<Invoice, InvoiceDTO>().ReverseMap();
            CreateMap<InvoiceItem, InvoiceItemDTO>().ReverseMap();
            CreateMap<InvoiceItemTax, InvoiceItemTaxDTO>().ReverseMap();
        }
    }
}
