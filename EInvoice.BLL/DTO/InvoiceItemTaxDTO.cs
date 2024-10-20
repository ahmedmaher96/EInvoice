using EInvoice.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EInvoice.BLL.DTO
{
    public class InvoiceItemTaxDTO
    {
        #region Properties

        public int TaxId { get; set; }
        public TaxDTO Tax { get; set; }

        public decimal TaxAmount { get; set; }

        #endregion
    }
}
