using EInvoice.DAL.Models;
using EInvoice.UI.Pages.InvoicePages;
using EInvoice.UI.ViewModels;
using static System.Net.WebRequestMethods;
using System.Text.Json.Serialization;
using System.Text.Json;
using EInvoice.UI.Pages.TaxPages;
using System.Net.Http.Json;
using EInvoice.BLL.DTO;

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

        public async Task<InvoiceDTO> GetInvoiceById(int? id)
        {
            var response = await http.GetAsync($"api/Invoice/Form/{id}");
            var invoice = new InvoiceDTO();
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            invoice = JsonSerializer.Deserialize<InvoiceDTO>(responseBody, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.Preserve
            }) ?? new InvoiceDTO();
            return invoice;
        }

        public async Task SaveInvoice(InvoiceDTO invoice)
        {
            var response = await http.PostAsJsonAsync("api/Invoice/Form", invoice);
            if (response.IsSuccessStatusCode)
            {
                var newInvoice = await response.Content.ReadFromJsonAsync<Invoice>();
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {errorMessage}");
            }
        }

        public async Task UpdateInvoice(int? id, InvoiceDTO invoice)
        {
            var response = await http.PutAsJsonAsync($"api/Invoice/Form/{id}", invoice);
            if (response.IsSuccessStatusCode)
            {
                var newInvoice = await response.Content.ReadFromJsonAsync<Invoice>();
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {errorMessage}");
            }
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

        #region Retrieve Search Data

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

        public async Task<List<Customer>> GetCustomer(string? name)
        {
            var response = await http.GetFromJsonAsync<List<Customer>>($"api/Customer?filterCode={null}&filterName={name}");
            var customers = new List<Customer>();
            customers = response ?? new List<Customer>();
            return customers;
        }

        #endregion

        #region Retrieve Single Data

        public async Task<Item> GetItemById(int? id)
        {
            var response = await http.GetAsync($"api/Item/Form/{id}");
            var item = new Item();
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            item = JsonSerializer.Deserialize<Item>(responseBody, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.Preserve
            }) ?? new Item();
            return item;
        }

        public async Task<Tax> GetTaxById(int? id)
        {
            var response = await http.GetAsync($"api/Tax/Form/{id}");
            var tax = new Tax();
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            tax = JsonSerializer.Deserialize<Tax>(responseBody, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.Preserve
            }) ?? new Tax();
            return tax;
        }

        public async Task<Customer> GetCustomerById(int? id)
        {
            var response = await http.GetAsync($"api/Customer/Form/{id}");
            var customer = new Customer();
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            customer = JsonSerializer.Deserialize<Customer>(responseBody, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.Preserve
            }) ?? new Customer();
            return customer;
        }
        #endregion

        #endregion
    }
}
