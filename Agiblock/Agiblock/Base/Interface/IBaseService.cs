using System.Linq;
using System.Threading.Tasks;

namespace Agiblock.Base.Interface
{
    public interface IBaseService<TEntity>
    {
        Task<IQueryable<TEntity>> GetEntities();
        Task<TEntity> GetEntityById(int id);
        Task<TEntity> CreateEntity(TEntity data);
        Task UpdateEntity(TEntity data, int id);
        Task DeleteEntity(int id);
    }
}