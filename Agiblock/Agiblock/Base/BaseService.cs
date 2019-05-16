using Agiblock.Base.Interface;
using Agiblock.Repository.Interface;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Agiblock.Base
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, IBaseEntity
    {
        protected readonly IRepository _repository;

        public BaseService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<TEntity> CreateEntity(TEntity data)
        {
            var entity = await _repository.CreateAsync(data);
            return entity;
        }


        public virtual async Task<IQueryable<TEntity>> GetEntities()
        {
            var entityList = await _repository.QueryAsync<TEntity>();
            return entityList;
        }

        public async Task<TEntity> GetEntityById(int id)
        {
            var entity = await _repository.QueryByIdAsync<TEntity>(id);
            return entity;
        }

        #region Unused
        public Task UpdateEntity(TEntity data, int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }
        

        #endregion
    }
}