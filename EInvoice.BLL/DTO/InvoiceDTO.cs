﻿using EInvoice.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EInvoice.BLL.DTO
{
    public class InvoiceDTO
    {
        #region Properties

        [Required(ErrorMessage = "Type of Invoice is required")]
        public int Type { get; set; }

        [Required(ErrorMessage = "Code is required")]
        public string Code { get; set; }

        public DateTime DateTimeInssured { get; set; }

        public ICollection<InvoiceItemDTO> InvoiceItems { get; set; }

        #endregion
    }
}
