using learn_specification.Entities;
using learn_specification.interfaces;
using learn_specification.Repositories.BaseRepository;

namespace learn_specification.Services
{
    public class BaseService<TRepository, TEntity> : IBaseService<TEntity> where TRepository
    : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly IBaseRepository<TEntity> Repository;
        protected readonly ILogger Logger;

        public BaseService(TRepository repository, ILogger logger)
        {
            Repository = repository;
            Logger = logger;
        }

        public Task<IList<TEntity>> GetAllAsync()
        {
            return Repository.GetAllAsync();
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            return Repository.GetByIdAsync(id);
        }

        public Task<TEntity> CreateAsync(TEntity entity)
        {
            return Repository.CreateAsync(entity);
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            return Repository.UpdateAsync(entity);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return Repository.DeleteAsync(id);
        }
    }
}