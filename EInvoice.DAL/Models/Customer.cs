using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EInvoice.DAL.Models
{
    public class Customer
    {
        #region Properties

        [Key]
        public int CustomerID { get; set; }
        
        [Required(ErrorMessage ="Customer Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Code is required")]
        public string Code { get; set; }
        
        #region Navigational Properties
        
        public ICollection<Invoice> Invoices { get; set; } 
        
        #endregion

        #endregion
    }
}
