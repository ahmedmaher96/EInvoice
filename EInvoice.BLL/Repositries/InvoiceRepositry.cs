using EInvoice.BLL.Interfaces;
using EInvoice.DAL.Context;
using EInvoice.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EInvoice.BLL.Repositries
{
    public class InvoiceRepositry : IInvoiceRepositry
    {
        #region Private Attributes

        private readonly EInvoiceDBContext Context;

        #endregion

        #region Constructors

        public InvoiceRepositry(EInvoiceDBContext dbcontext)
        {
            Context = dbcontext;
        }

        #endregion

        #region Implementation

        #region Retrieve

        public IQueryable<Invoice> Query()
        {
            return Context.Invoices.AsQueryable();
        }

        public async Task<IEnumerable<Invoice>> GetAllInvoiceAsync()
        {
            return await Query().ToListAsync();
        }

        public async Task<IEnumerable<Invoice>> GetInvoiceList(string filterCode, int filterType, DateTime filterDateTimeInssured)
        {
            var filteredInvoices = await Query().Where(i => i.Code.Contains(filterCode)
                                                        || i.Type.Equals(filterType)
                                                        || i.DateTimeInssured == filterDateTimeInssured)
                                                .ToListAsync();
            return filteredInvoices;
        }

        public async Task<Invoice> GetInvoiceByIdAsync(int id)
        {
            return await Context.Invoices.FindAsync(id);
        }

        #endregion

        #region Modify
        
        public async Task AddInvoiceAsync(Invoice invoice)
        {
            await Context.Invoices.AddAsync(invoice);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateInvoiceAsync(Invoice invoice)
        {
            Context.Update(invoice);
            await Context.SaveChangesAsync();
        }

        public void DeleteInvoice(int id)
        {
            var deletedInvoice = Context.Invoices.Find(id);
            if (deletedInvoice != null)
            {
                Context.Invoices.Remove(deletedInvoice);
                Context.SaveChanges();
            }
        } 

        #endregion

        #endregion
    }
}
