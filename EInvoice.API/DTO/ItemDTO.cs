using System.ComponentModel.DataAnnotations;

namespace EInvoice.API.DTO
{
    public class ItemDTO
    {
        [Required(ErrorMessage = "Item Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Code is required")]
        public string ItemCode { get; set; }
    }
}
