using AutoMapper;
using EInvoice.API.Controllers.Generic;
using EInvoice.BLL.DTO;
using EInvoice.BLL.Interfaces;
using EInvoice.BLL.Repositries;
using EInvoice.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EInvoice.API.Controllers
{
    public class InvoiceController : APIBaseController
    {
        #region Private Attributes

        private readonly IInvoiceRepositry _invoiceRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors
        public InvoiceController(IInvoiceRepositry invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        #endregion

        #region End Points

        #region Invoice Endpoints

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllInvoices()
        {
            var invoices = await _invoiceRepository.GetAllAsync();
            return Ok(invoices);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetInvoiceById(int id)
        {
            var invoice = await _invoiceRepository.GetInvoiceByIdAsync(id);
            if (invoice == null) return NotFound();

            return Ok(invoice);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddInvoice([FromBody] InvoiceDTO invoiceDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdInvoice = await _invoiceRepository.AddInvoiceAsync(invoiceDto);
            return Ok();
        }

        [HttpPut("Update/{id}")]
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

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var result = await _invoiceRepository.DeleteInvoiceAsync(id);
            if (!result) return NotFound();

            return Ok();
        }

        #endregion

        #region InvoiceItem Endpoints

        [HttpGet("GetInvoiceItemById/{id}")]
        public async Task<IActionResult> GetInvoiceItemById(int id)
        {
            var invoiceItem = await _invoiceRepository.GetInvoiceItemByIdAsync(id);
            if (invoiceItem == null) return NotFound();

            return Ok(invoiceItem);
        }

        //[HttpPost("AddItem")]
        //public async Task<IActionResult> AddInvoiceItem([FromBody] InvoiceItemDTO invoiceItemDto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var createdItem = await _invoiceRepository.AddItemToInvoiceAsync(invoiceItemDto);
        //    return CreatedAtAction(nameof(GetInvoiceItemById), new { id = createdItem.ItemInvoiceID }, createdItem);
        //}

        [HttpPut("UpdateItem/{id}")]
        public async Task<IActionResult> UpdateInvoiceItem(int id, [FromBody] InvoiceItemDTO invoiceItemDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedItem = await _invoiceRepository.UpdateInvoiceItemAsync(id, invoiceItemDto);
            if (updatedItem == null) return NotFound();

            return Ok(updatedItem);
        }

        [HttpDelete("DeleteItem/{id}")]
        public async Task<IActionResult> DeleteInvoiceItem(int id)
        {
            var result = await _invoiceRepository.DeleteInvoiceItemAsync(id);
            if (!result) return NotFound();

            return Ok();
        }

        #endregion

        #region InvoiceItemTax Endpoints

        [HttpGet("GetInvoiceItemTax")]
        public async Task<IActionResult> GetInvoiceItemTaxes(int id)
        {
            var itemTaxes = await _invoiceRepository.GetInvoiceItemTaxes(id);
            if (itemTaxes == null)
                return NotFound();
            return Ok(itemTaxes);
        }

        //[HttpPost("AddTaxToItem")]
        //public async Task<IActionResult> AddTaxToInvoiceItem([FromBody] InvoiceItemTaxDTO invoiceItemTaxDto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var createdTax = await _invoiceRepository.AddTaxToInvoiceItemAsync(invoiceItemTaxDto);
        //    return CreatedAtAction(nameof(GetInvoiceItemById), new { id = createdTax.InvoiceItemTaxID }, createdTax);
        //}

        //[HttpPut("UpdateTax/{id}")]
        //public async Task<IActionResult> UpdateInvoiceItemTax(int id, [FromBody] InvoiceItemTaxDTO invoiceItemTaxDto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var updatedTax = await _invoiceRepository.UpdateInvoiceItemTaxAsync(_mapper.Map<InvoiceItemTax>(invoiceItemTaxDto));
        //    if (updatedTax == null) return NotFound();

        //    return Ok(updatedTax);
        //}

        [HttpDelete("DeleteTax/{id}")]
        public async Task<IActionResult> DeleteInvoiceItemTax(int id)
        {
            var result = await _invoiceRepository.DeleteInvoiceItemTaxAsync(id);
            if (!result) return NotFound();

            return Ok();
        }

        #endregion

        #endregion

    }
}
