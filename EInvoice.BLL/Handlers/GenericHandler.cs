using AutoMapper;
using EInvoice.BLL.DTO;
using EInvoice.BLL.Interfaces.IGeneric;
using EInvoice.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EInvoice.BLL.Handlers
{
    public class GenericHandler<Tmodel, TDto> :  IGenericHandler<Tmodel, TDto> where Tmodel : class
    {
        private readonly IGenericRepositry<Tmodel> _repository;
        private readonly IMapper _mapper;

        public GenericHandler(IGenericRepositry<Tmodel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Tmodel>> GetItems(string? filter)
        {
            IEnumerable<Tmodel> Entities;

            if (filter == null)
            {
                Entities = await _repository.GetAllAsync();
            }
            else
            {
                Entities = await _repository.GetList(filter);
                if (Entities == null || !Entities.Any())
                {
                    throw new Exception("Not Found");
                }
            }
            return Entities;
        }

        public async Task<Tmodel> GetSingle(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Tmodel> Save(TDto dto)
        {
            var Entity = _mapper.Map<Tmodel>(dto);
            await _repository.AddAsync(Entity);
            return Entity;
        }

        public async Task<TDto> Update(int id, TDto dto)
        {
            var existingEntity = await _repository.GetByIdAsync(id);
            if (existingEntity == null)
                throw new Exception("No Existing Data With This ID");
            _mapper.Map(dto, existingEntity);
            await _repository.UpdateAsync(existingEntity);
            var mappedEntity = _mapper.Map<TDto>(existingEntity);
            return mappedEntity;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
