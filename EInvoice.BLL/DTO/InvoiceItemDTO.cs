using EInvoice.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EInvoice.BLL.DTO
{
    public class InvoiceItemDTO
    {
        #region Properties

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public int Quantity { get; set; }

        public int ItemID { get; set; }

        //public ICollection<InvoiceItemTaxDTO> InvoiceItemTaxes { get; set; }

        #endregion
    }
}
