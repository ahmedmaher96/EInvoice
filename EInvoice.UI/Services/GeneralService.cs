using EInvoice.DAL.Models;
using EInvoice.UI.Pages;
using static System.Net.WebRequestMethods;

namespace EInvoice.UI.Services
{
    public class GeneralService
    {
        #region Properties

        #region Properties

        public Item Item { get; private set; }
        public Tax Tax { get; private set; }
        public Customer Customer { get; private set; }
        public Invoice Invoice { get; private set; }

        #endregion

        #region Methods

        public void SetItem(Item item)
        {
            Item = item;
        }

        public void SetTax(Tax tax)
        {
            Tax = tax;
        }

        public void SetCustomer(Customer customer)
        {
            Customer = customer;
        }

        public void SetInvoice(Invoice invoice)
        {
            Invoice = invoice;
        }

        #endregion
        #endregion

    }
}
