using EInvoice.DAL.Models;

namespace EInvoice.UI.ViewModels
{
    public class InvoiceSearchParams
    {
        #region Parameters

        public string? Code { get; set; }
        public InvoiceType? Type { get; set; }
        public DateTime? IssuedDate { get; set; }

        #endregion
    }
}
