using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EInvoice.DAL.Models
{
    public class InvoiceItem
    {
        #region Properties

        [Key]
        public int InvoiceItemID { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public int Quantity { get; set; }
        public decimal Total => Quantity * Amount;

        public decimal TotalTaxes => InvoiceItemTaxes?.Sum(i => i.TaxAmount) ?? 0;

        public decimal ItemNetAmount => Total + TotalTaxes;

        #region Navigational Properties

        public int? ItemId { get; set; }
        public Item Item { get; set; }
        public int? InvoiceId { get; set; }
        [JsonIgnore]
        public Invoice Invoice { get; set; }
        public ICollection<InvoiceItemTax> InvoiceItemTaxes {  get; set; }

        #endregion

        #endregion
    }
}
