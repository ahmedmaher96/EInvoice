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
        Task AddInvoiceAsync(Invoice invoice);
        Task UpdateInvoiceAsync(Invoice invoice);
        void DeleteInvoice(int id);
        Task<Invoice> GetInvoiceByIdAsync(int id);
        Task<IEnumerable<Invoice>> GetAllInvoiceAsync();
        Task<IEnumerable<Invoice>> GetInvoiceList(string filterCode, int filterType, DateTime filterDateTimeInssured);
    }
}
