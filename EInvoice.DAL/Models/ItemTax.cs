using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EInvoice.DAL.Models
{
    public class ItemTax
    {
        #region Properties

        public int ItemTaxID { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int TaxId { get; set; }
        public Tax Tax { get; set; }

        public decimal TaxAmount { get; set; }

        #endregion
    }
}
