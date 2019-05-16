using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Agiblock.Base;
using Agiblock.Repository.Interface;

namespace Agiblock.Repository
{
    public class Repository : IRepository
    {
        private DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
   
        }

        public Task DeleteAsync<T>(int id) where T : class, IBaseEntity
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<T> CreateAsync<T>(T data) where T : class, IBaseEntity
        {
            var result = _context.Set<T>().Add(data);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<IQueryable<T>> QueryAsync<T>() where T : class, IBaseEntity
        {
            return await Task.Run(() => _context.Set<T>());
        }

        public async Task<T> QueryByIdAsync<T>(int id) where T : class, IBaseEntity
        {
            return await Task.Run(() => _context.Set<T>().SingleOrDefault(x => x.Id == id));
        }

        public Task UpdateAsync<T>(int id, T data) where T : class, IBaseEntity
        {
            throw new NotImplementedException();
        } 
    }
}