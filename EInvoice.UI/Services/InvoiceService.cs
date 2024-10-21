using EInvoice.DAL.Models;
using EInvoice.UI.Pages.InvoicePages;
using EInvoice.UI.ViewModels;
using static System.Net.WebRequestMethods;
using System.Text.Json.Serialization;
using System.Text.Json;
using EInvoice.UI.Pages.TaxPages;
using System.Net.Http.Json;

namespace EInvoice.UI.Services
{
    public class InvoiceService
    {
        #region Private Attributes
        
        private readonly HttpClient http;

        #endregion

        #region Constructors
        
        public InvoiceService(HttpClient httpClient)
        {
            http = httpClient;
        }

        #endregion

        #region Methods
        
        public async Task<List<Invoice>> GetInvoices(string? code, InvoiceType? type, DateTime? date)
        {
            var response = await http.GetAsync($"api/Invoice?Code={code}&type={type}&dateTime={date}");
            var invoices = new List<Invoice>();
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            invoices = JsonSerializer.Deserialize<List<Invoice>>(responseBody, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.Preserve
            }) ?? new List<Invoice>();
            return invoices;
        }

        public async Task DeleteInvoice(int id)
        {
            var response = await http.DeleteAsync($"api/Invoice/{id}");
        }

        public async Task<Invoice> EditInvoice(int id)
        {
            var invoice = new Invoice();
            var response = await http.GetAsync($"api/Invoice/Form/{id}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            invoice = JsonSerializer.Deserialize<Invoice>(responseBody, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.Preserve
            }) ?? new Invoice();
            return invoice;
        } 

        public async Task<List<Tax>> GetTaxes(string? name)
        {
            var response = await http.GetFromJsonAsync<List<Tax>>($"api/Tax?filterCode={null}&filterName={name}");
            var taxes = new List<Tax>();
            taxes = response ?? new List<Tax>();
            return taxes;
        }

        public async Task<List<Item>> GetItems(string? name)
        {
            var response = await http.GetFromJsonAsync<List<Item>>($"api/Item?filterCode={null}&filterName={name}");
            var items = new List<Item>();
            items = response ?? new List<Item>();
            return items;
        }

        #endregion
    }
}
