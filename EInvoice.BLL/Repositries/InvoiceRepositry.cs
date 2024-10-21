﻿using AutoMapper;
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

        public InvoiceRepositry(EInvoiceDBContext context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }

        #endregion

        #region Implementation

        #region Invoice

        public IQueryable<Invoice> Query()
        {
            return Context.Invoices.Include(i=>i.Customer)
                                   .Include(i => i.InvoiceItems)
                                        .ThenInclude(ii => ii.Item)
                                   .Include(i => i.InvoiceItems)
                                        .ThenInclude(ii => ii.InvoiceItemTaxes)
                                        .ThenInclude(iit => iit.Tax)
                                   .AsQueryable();
        }

        public async Task<IEnumerable<Invoice>> GetAllAsync()
        {
            return await Query().ToListAsync();
        }

        public async Task<IEnumerable<Invoice>> GetList(string filterCode, InvoiceType? filterType, DateTime? filterDate)
        {
            return await Query().Where(i => i.Code.Contains(filterCode)
                                                || i.Type.Equals(filterType)
                                                || i.DateTimeInssured.Equals(filterDate))
                                        .ToListAsync();
        }

        public async Task<Invoice> GetInvoiceByIdAsync(int invoiceId)
        {
            return await Query().FirstOrDefaultAsync(i => i.InvoiceID == invoiceId);
        }

        public async Task<Invoice> AddInvoiceAsync(InvoiceDTO invoicedto)
        {
            var customer = await Context.Customers.Where(c => c.CustomerID == invoicedto.CustomerID).FirstOrDefaultAsync();
            if (customer != null)
                invoicedto.CustomerID = customer.CustomerID;

            ICollection<InvoiceItemDTO> invoceItemsList = invoicedto.InvoiceItems;

            foreach (var invoiceItem in invoceItemsList)
            {
                ICollection<InvoiceItemTaxDTO> invoiceItemTaxList = invoiceItem.InvoiceItemTaxes;
                foreach (var invoiceItemTax in invoiceItemTaxList)
                {
                    var itemTaxes = await AddTaxToInvoiceItemAsync(invoiceItemTax);
                    invoiceItemTax.TaxId = itemTaxes.TaxId ?? 0;
                }
                var item = await AddItemToInvoiceAsync(invoiceItem);
                invoiceItem.ItemID = item.ItemId ?? 0;
            }


            var invoice = _mapper.Map<Invoice>(invoicedto);
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

        public void DeleteInvoice(int invoiceId)
        {
            var invoice = Context.Invoices.Include(i => i.InvoiceItems)
                                          .ThenInclude(ii => ii.InvoiceItemTaxes)
                                          .FirstOrDefault(i => i.InvoiceID == invoiceId);
            if (invoice != null)
            {
                foreach (var invoiceItem in invoice.InvoiceItems)
                {
                    Context.InvoiceItemTaxes.RemoveRange(invoiceItem.InvoiceItemTaxes);
                }

                Context.InvoiceItems.RemoveRange(invoice.InvoiceItems);
                Context.Invoices.Remove(invoice);
                Context.SaveChangesAsync();
            }
        }

        #endregion

        #region InvoiceItem


        public async Task<InvoiceItem> AddItemToInvoiceAsync(InvoiceItemDTO itemdto)
        {
            var itemInvoice = await Context.Items.Where(i => i.ItemID == itemdto.ItemID).FirstOrDefaultAsync();
            if (itemInvoice != null)
                itemdto.ItemID = itemInvoice.ItemID;

            var item = _mapper.Map<InvoiceItem>(itemdto);
            return item;
        }

        #endregion

        #region InvoiceItemTax


        public async Task<InvoiceItemTax> AddTaxToInvoiceItemAsync(InvoiceItemTaxDTO itemTaxdto)
        {
            var itemtax = await Context.Taxs.Where(c => c.TaxID == itemTaxdto.TaxId).FirstOrDefaultAsync();
            if (itemtax != null)
                itemTaxdto.TaxId = itemtax.TaxID;

            var tax = _mapper.Map<InvoiceItemTax>(itemTaxdto);
            return tax;
        }

        #endregion

        #endregion
    }
}
