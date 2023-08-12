using learn_specification.Entities;

namespace learn_specification.interfaces
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        Task<IList<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(int id);

        Task<TEntity> CreateAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<bool> DeleteAsync(int id);
    }

}