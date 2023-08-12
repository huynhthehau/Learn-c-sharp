using learn_specification.Entities;
using learn_specification.Specifications;

namespace learn_specification.Repositories.BaseRepository
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IList<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(int id);

        Task<TEntity> CreateAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<bool> DeleteAsync(int id);
        Task<TEntity> GetByIdAsync(int id, IBaseSpecifications<TEntity> baseSpecifications = null);
    }
}