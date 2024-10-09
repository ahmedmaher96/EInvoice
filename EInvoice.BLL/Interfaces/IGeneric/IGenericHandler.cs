using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EInvoice.BLL.Interfaces.IGeneric
{
    public interface IGenericHandler<TModel, TDto>
    {
        // Signatures
        Task<IEnumerable<TModel>> GetItems(string? filter);
        Task<TModel> GetSingle(int id);
        Task<TModel> Save(TDto dto);
        Task<TDto> Update(int id, TDto dto);
        void Delete(int id);
    }
}
