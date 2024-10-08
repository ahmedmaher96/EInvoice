﻿using AutoMapper;
using EInvoice.API.Controllers.Generic;
using EInvoice.BLL.DTO;
using EInvoice.BLL.Interfaces.IGeneric;
using EInvoice.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EInvoice.API.Controllers
{
    public class ItemController : GenericController<Item, ItemDTO>
    {
        #region Constructors

        public ItemController(IGenericHandler<Item, ItemDTO> handler, IMapper mapper)
            : base(handler, mapper)
        {

        }

        #endregion
    }
}
