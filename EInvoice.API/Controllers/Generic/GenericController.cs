using AutoMapper;
using EInvoice.BLL.DTO;
using EInvoice.BLL.Interfaces.IGeneric;
using EInvoice.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EInvoice.API.Controllers.Generic
{
    public class GenericController<TModel, TDto> : APIBaseController
    {
        #region Private Attributes

        protected readonly IGenericHandler<TModel, TDto> _handler;
        protected readonly IMapper _mapper;

        #endregion

        #region Constructors

        protected GenericController(IGenericHandler<TModel, TDto> handler, IMapper mapper)
        {
            _handler = handler;
            _mapper = mapper;
        }

        #endregion

        #region Actions

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TModel>>> GetElements([FromQuery] string? filterCode = null, string? filterName = null)
        {
            IEnumerable<TModel> Entities = await _handler.GetElements(filterCode, filterName);
            if (Entities == null || !Entities.Any())
            {
                return NotFound("No items found.");
            }
            return Ok(Entities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TModel>> GetSingle(int id)
        {
            var Entity = await _handler.GetSingle(id);
            return Ok(Entity);
        }

        [HttpPost("Form")]
        public async Task<IActionResult> Save([FromBody] TDto tDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newItem = await _handler.Save(tDto);
            return Ok(newItem);
        }

        [HttpPut("Form/{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] TDto tDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var updatedEntity = await _handler.Update(id, tDto);
            return Ok(updatedEntity);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _handler.Delete(id);
            return Ok();
        }

        #endregion
    }
}
