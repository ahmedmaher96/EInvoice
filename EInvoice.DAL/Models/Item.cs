using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EInvoice.DAL.Models
{
    public class Item
    {
        #region Properties

        [Key]
        public int ItemID { get; set; }

        [Required(ErrorMessage = "Item Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Code is required")]
        public string Code { get; set; }

        #region Navigational Properties

        public ICollection<InvoiceItem> InvoiceItems { get; set; }

        #endregion

        #endregion
    }
}
