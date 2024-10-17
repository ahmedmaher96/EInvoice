using AutoMapper;
using EInvoice.BLL.DTO;
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
        #region Private Attribute

        private readonly EInvoiceDBContext Context;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors

        public InvoiceRepositry(EInvoiceDBContext context,IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }

        #endregion

        #region Implementation

        #region Invoice

        public IQueryable<Invoice> Query()
        {
            return Context.Invoices.AsQueryable();
        }

        public async Task<IEnumerable<Invoice>> GetAllAsync()
        {
            return await Context.Invoices.ToListAsync();
        }

        public async Task<IEnumerable<Invoice>> GetList(string filterCode, int filterType, DateTime filterDate)
        {
            return await Context.Invoices.Where(i => i.Code.Contains(filterCode)
                                                || i.Type.Equals(filterType)
                                                || i.DateTimeInssured.Equals(filterDate))
                                        .ToListAsync();
        }

        public async Task<Invoice> GetInvoiceByIdAsync(int invoiceId)
        {
            return await Context.Invoices.FindAsync(invoiceId);
        }

        public async Task<Invoice> AddInvoiceAsync(Invoice invoice)
        {
            Context.Invoices.Add(invoice);
            await Context.SaveChangesAsync();
            return invoice;
        }

        public async Task<Invoice> UpdateInvoiceAsync(Invoice invoice)
        {
            Context.Invoices.Update(invoice);
            await Context.SaveChangesAsync();
            return invoice;
        }

        public async Task<bool> DeleteInvoiceAsync(int invoiceId)
        {
            var invoice = await GetInvoiceByIdAsync(invoiceId);
            if (invoice == null) return false;

            Context.Invoices.Remove(invoice);
            await Context.SaveChangesAsync();
            return true;
        }

        #endregion

        #region InvoiceItem

        public async Task<InvoiceItem> GetInvoiceItemByIdAsync(int invoiceItemId)
        {
            return await Context.InvoiceItems.FindAsync(invoiceItemId);
        }

        // Check Again
        public async Task<InvoiceItem> AddItemToInvoiceAsync(int invoiceId, InvoiceItemDTO itemdto)
        {
            var invoice = await GetInvoiceByIdAsync(invoiceId);
            if (invoice == null) 
                return null;

            var item = _mapper.Map<InvoiceItem>(itemdto);
            invoice.InvoiceItems.Add(item);
            await Context.SaveChangesAsync();
            return item;
        }

        // Check again
        public async Task<InvoiceItem> UpdateInvoiceItemAsync(int id, InvoiceItemDTO itemdto)
        {
            var invoiceItem = await GetInvoiceItemByIdAsync(id);
            if (invoiceItem == null)
                return null;

            _mapper.Map(itemdto, invoiceItem);
            Context.InvoiceItems.Update(invoiceItem);
            var mappedInvoiceItem = _mapper.Map<InvoiceItem>(invoiceItem);
            await Context.SaveChangesAsync();
            return invoiceItem;
        }

        public async Task<bool> DeleteInvoiceItemAsync(int itemInvoiceId)
        {
            var item = await Context.InvoiceItems.FindAsync(itemInvoiceId);
            if (item == null) return false;

            Context.InvoiceItems.Remove(item);
            await Context.SaveChangesAsync();
            return true;
        }

        #endregion

        #region InvoiceItemTax

        // Check
        public async Task<InvoiceItemTax> AddTaxToInvoiceItemAsync(int itemInvoiceId, InvoiceItemTax tax)
        {
            var item = await Context.InvoiceItems.FindAsync(itemInvoiceId);
            if (item == null) return null;

            item.InvoiceItemTaxes.Add(tax);
            await Context.SaveChangesAsync();
            return tax;
        }

        // Check
        public async Task<InvoiceItemTax> UpdateInvoiceItemTaxAsync(InvoiceItemTax tax)
        {
            Context.InvoiceItemTaxes.Update(tax);
            await Context.SaveChangesAsync();
            return tax;
        }

        public async Task<bool> DeleteInvoiceItemTaxAsync(int taxId)
        {
            var tax = await Context.InvoiceItemTaxes.FindAsync(taxId);
            if (tax == null) return false;

            Context.InvoiceItemTaxes.Remove(tax);
            await Context.SaveChangesAsync();
            return true;
        } 
        #endregion

        #endregion
    }
}
