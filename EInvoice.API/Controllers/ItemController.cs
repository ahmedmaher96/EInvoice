using AutoMapper;
using EInvoice.API.DTO;
using EInvoice.BLL.Interfaces.IGeneric;
using EInvoice.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EInvoice.API.Controllers
{
    public class ItemController : APIBaseController
    {
        #region Private Attribute

        private readonly IGenericRepositry<Item> _genericRepositry;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors

        public ItemController(IGenericRepositry<Item> genericRepositry, IMapper mapper)
        {
            _genericRepositry = genericRepositry;
            _mapper = mapper;
        }

        #endregion

        #region Actions

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems(string? filter = null)
        {
            IEnumerable<Item> items;

            if (filter == null)
            {
                items = await _genericRepositry.GetAllAsync();
            }
            else
            {
                items = await _genericRepositry.GetList(filter);
                if (items == null || !items.Any())
                {
                    return NotFound();
                }
            }
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetSingle(int id)
        {
            var item = await _genericRepositry.GetByIdAsync(id);
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromForm] ItemDTO itemDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var mappedItem = _mapper.Map<ItemDTO, Item>(itemDto);
            await _genericRepositry.AddAsync(mappedItem);
            return Ok(itemDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] ItemDTO itemDTO)
        {
            var existingItem = await _genericRepositry.GetByIdAsync(id);
            if (existingItem == null)
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _mapper.Map(itemDTO, existingItem);
            await _genericRepositry.UpdateAsync(existingItem);
            var mappedItem = _mapper.Map<ItemDTO>(existingItem);
            return Ok(mappedItem);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        { 
            _genericRepositry.Delete(id);
            return Ok();
        }

        #endregion

    }
}
