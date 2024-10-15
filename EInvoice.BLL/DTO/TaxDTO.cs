using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EInvoice.BLL.DTO
{
    public class TaxDTO
    {
        #region Properties

        [Required(ErrorMessage = "Tax Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Code is required")]
        public string Code { get; set; }

        #endregion
    }
}
