using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EInvoice.DAL.Models
{
    public class InvoiceItem
    {
        #region Properties

        [Key]
        public int ItemInvoiceID { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public int Quantity { get; set; }
        public decimal TotalAmount => Quantity * Amount;

        public decimal TotalTaxes => Item.ItemTaxes?.Sum(i => i.Tax.TaxAmount) ?? 0;

        public decimal TotalNetAmout => TotalAmount + TotalTaxes;

        #region Navigational Properties

        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        #endregion

        #endregion
    }
}
