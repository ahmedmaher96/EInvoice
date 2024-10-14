using EInvoice.DAL.Models;
using EInvoice.UI.Pages;
using static System.Net.WebRequestMethods;

namespace EInvoice.UI.Services
{
    public class ItemService
    {
        #region Properties

        public Item ItemProperty { get; set; }

        #endregion

        #region Methods

        public void GetItem(Item item)
        {
            ItemProperty = item;
        }

        #endregion
    }
}
