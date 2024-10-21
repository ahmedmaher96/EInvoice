using AutoMapper;
using EInvoice.API.Controllers.Generic;
using EInvoice.BLL.DTO;
using EInvoice.BLL.Interfaces;
using EInvoice.BLL.Repositries;
using EInvoice.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace EInvoice.API.Controllers
{
    public class InvoiceController : APIBaseController
    {
        #region Private Attributes

        private readonly IInvoiceRepositry _invoiceRepository;
        private readonly IMapper _mapper;
        private readonly JsonSerializerOptions _jsonOptions;

        #endregion

        #region Constructors
        public InvoiceController(IInvoiceRepositry invoiceRepository, IMapper mapper, JsonSerializerOptions jsonOptions)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
            _jsonOptions = jsonOptions;
        }

        #endregion

        #region End Points

        #region Invoice Endpoints

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetAllInvoices([FromQuery] string? Code = null, InvoiceType? type = null, DateTime? dateTime = null)
        {
            IEnumerable<Invoice> invoices;

            if (Code == null && type == null && dateTime == null)
            {
                invoices = await _invoiceRepository.GetAllAsync();
            }
            else
            {
                invoices = await _invoiceRepository.GetList(Code, type, dateTime);
                if (invoices == null || !invoices.Any())
                {
                    throw new Exception("Not Found");
                }
            }

            var jsonString = JsonSerializer.Serialize(invoices, _jsonOptions);

            return Content(jsonString, "application/json");
        }

        [HttpGet("Form/{id}")]
        public async Task<ActionResult<Invoice>> GetInvoiceById(int id)
        {
            var invoice = await _invoiceRepository.GetInvoiceByIdAsync(id);
            if (invoice == null) return NotFound();

            var jsonString = JsonSerializer.Serialize(invoice, _jsonOptions);

            return Content(jsonString, "application/json");
        }

        [HttpPost("Form")]
        public async Task<IActionResult> AddInvoice([FromBody] InvoiceDTO invoiceDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdInvoice = await _invoiceRepository.AddInvoiceAsync(invoiceDto);
            return Ok();
        }

        [HttpPut("Form/{id}")]
        public async Task<IActionResult> UpdateInvoice(int id, [FromBody] InvoiceDTO invoiceDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var invoiceToUpdate = await _invoiceRepository.GetInvoiceByIdAsync(id);
            if (invoiceToUpdate == null) return NotFound();

            _mapper.Map(invoiceDto, invoiceToUpdate);
            var updatedInvoice = await _invoiceRepository.UpdateInvoiceAsync(invoiceToUpdate);
            return Ok(updatedInvoice);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteInvoice(int id)
        {
            _invoiceRepository.DeleteInvoice(id);
            return Ok();
        }

        #endregion

        #endregion

    }
}
