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

        IQueryable<Invoice> Query();

        Task<IEnumerable<Invoice>> GetAllAsync();

        Task<IEnumerable<Invoice>> GetList(string filterCode, InvoiceType? filterType, DateTime? filterDate);

        Task<Invoice> GetInvoiceByIdAsync(int invoiceId);

        Task<Invoice> AddInvoiceAsync(InvoiceDTO invoicedto);

        Task<Invoice> UpdateInvoiceAsync(Invoice invoice);

        void DeleteInvoice(int invoiceId);

    }
}
