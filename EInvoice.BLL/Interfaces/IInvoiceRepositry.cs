using EInvoice.BLL.DTO;
using EInvoice.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EInvoice.BLL.Interfaces
{
    public interface IInvoiceRepositry
    {
        // Signatures

        #region Invoice Signatures

        IQueryable<Invoice> Query();

        Task<IEnumerable<Invoice>> GetAllAsync();

        Task<IEnumerable<Invoice>> GetList(string filterCode, int filterType, DateTime filterDate);

        Task<Invoice> GetInvoiceByIdAsync(int invoiceId);

        Task<Invoice> AddInvoiceAsync(Invoice invoice);

        Task<Invoice> UpdateInvoiceAsync(Invoice invoice);

        Task<bool> DeleteInvoiceAsync(int invoiceId);

        #endregion

        #region InvoiceItem

        Task<InvoiceItem> GetInvoiceItemByIdAsync(int id);

        Task<InvoiceItem> AddItemToInvoiceAsync(int invoiceId, InvoiceItemDTO item);

        Task<InvoiceItem> UpdateInvoiceItemAsync(int id, InvoiceItemDTO item);

        Task<bool> DeleteInvoiceItemAsync(int itemInvoiceId);

        #endregion

        #region InvoiceItemTax

        Task<InvoiceItemTax> AddTaxToInvoiceItemAsync(int itemInvoiceId, InvoiceItemTax tax);

        Task<InvoiceItemTax> UpdateInvoiceItemTaxAsync(InvoiceItemTax tax);

        Task<bool> DeleteInvoiceItemTaxAsync(int taxId); 

        #endregion

    }
}
