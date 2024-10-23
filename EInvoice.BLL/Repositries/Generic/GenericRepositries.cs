using EInvoice.BLL.Interfaces.IGeneric;
using EInvoice.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EInvoice.BLL.Repositries.Generic
{
    public class GenericRepositries<T> : IGenericRepositry<T> where T : class
    {
        #region Private Attributes

        private readonly EInvoiceDBContext Context;

        #endregion

        #region Constructors

        public GenericRepositries(EInvoiceDBContext dbcontext)
        {
            Context = dbcontext;
        }

        #endregion

        #region Implementation

        #region Retrieve

        public IQueryable<T> Query()
        {
            return Context.Set<T>().AsQueryable();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Query().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetList(string filterCode, string filterName)
        {
            return await Query()
                        .Where(e => EF.Property<string>(e, "Name").Contains(filterName)
                        || EF.Property<string>(e, "Code").Contains(filterCode))
                        .ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await Context.Set<T>().FindAsync(id);
            return entity ?? Activator.CreateInstance<T>();
        }

        #endregion

        #region Modify

        public async Task AddAsync(T entity)
        {
            bool isExisted = await CheckCodeDuplication(entity);
            if (isExisted)
                throw new Exception("Code is existed already.");

            await Context.Set<T>().AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            bool isExisted = await CheckCodeDuplication(entity);
            if (isExisted)
                throw new Exception("Code is existed already.");

            Context.Set<T>().Update(entity);
            await Context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var entity = Context.Set<T>().Find(id);
            if (entity != null)
            {
                Context.Set<T>().Remove(entity);
                Context.SaveChanges();
            }
        }

        #endregion

        #endregion

        #region Methods

        public async Task<bool> CheckCodeDuplication(T entity)
        {
            var codeProperty = typeof(T).GetProperty("Code");
            if (codeProperty == null)
            {
                throw new Exception("The entity does not have a Code property.");
            }

            string codeValue = (string)codeProperty.GetValue(entity);
            bool isExisted = await Query().AnyAsync(e => EF.Property<string>(e, "Code").Contains(codeValue));
            
            return isExisted;
        }

        #endregion

    }
}
