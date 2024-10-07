using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EInvoice.DAL.Models
{
    public class Tax
    {
        #region Properties

        [Key]
        public int TaxID { get; set; }

        [Required(ErrorMessage = "Tax Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Code is required")]
        public string TaxCode { get; set; }

        public decimal TaxAmount { get; set; }

        #region Navigational Properties

        public ICollection<ItemTax> ItemTaxes { get; set; }

        #endregion

        #endregion
    }
}
