using AutoMapper;
using EInvoice.API.Controllers.Generic;
using EInvoice.BLL.DTO;
using EInvoice.BLL.Interfaces.IGeneric;
using EInvoice.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EInvoice.API.Controllers
{
    public class CustomerController : GenericController<Customer, CustomerDTO>
    {
        #region Constructors

        public CustomerController(IGenericHandler<Customer, CustomerDTO> handler, IMapper mapper)
            : base(handler, mapper)
        {
            
        }

        #endregion
    }
}
