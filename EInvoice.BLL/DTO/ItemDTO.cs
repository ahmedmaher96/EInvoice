using System.ComponentModel.DataAnnotations;

namespace EInvoice.BLL.DTO
{
    public class ItemDTO
    {
        #region Properties

        [Required(ErrorMessage = "Item Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Code is required")]
        public string Code { get; set; }

        #endregion
    }
}
