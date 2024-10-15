using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EInvoice.DAL.Models
{
    public class InvoiceItemTax
    {
        #region Properties

        [Key]
        public int InvoiceItemTaxID { get; set; }
        public int ItemInvoiceID { get; set; }
        public InvoiceItem InvoiceItem { get; set; }
        public int TaxId { get; set; }
        public Tax Tax { get; set; }
        public decimal TaxAmount { get; set; }

        #endregion
    }
}
