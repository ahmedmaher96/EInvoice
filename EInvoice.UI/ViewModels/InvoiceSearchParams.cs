namespace EInvoice.UI.ViewModels
{
    public class InvoiceSearchParams
    {
        #region Parameters

        public string? Code { get; set; }
        public int? Type { get; set; }
        public DateTime? IssuedDate { get; set; }

        #endregion
    }
}
