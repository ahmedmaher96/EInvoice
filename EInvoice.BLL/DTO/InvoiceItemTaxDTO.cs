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

        public int InvoiceItemID { get; set; }
        public ICollection<TaxDTO> Taxes { get; set; }

        #endregion
    }
}
