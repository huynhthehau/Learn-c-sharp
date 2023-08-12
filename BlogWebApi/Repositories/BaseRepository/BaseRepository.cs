using learn_specification.Data;
using learn_specification.Entities;
using learn_specification.Specifications;
using Microsoft.EntityFrameworkCore;

namespace learn_specification.Repositories.BaseRepository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly BlogContext _blogContext;

        public BaseRepository(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            try
            {
                return await _blogContext.Set<TEntity>().AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            try
            {
                var item = await _blogContext.Set<TEntity>().Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
                if (item == null)
                {
                    throw new Exception($"Couldn't find entity with id={id}");
                }

                return item;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entity with id={id}: {ex.Message}");
            }
        }

        public async Task<TEntity> CreateAsync(TEntity data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                await _blogContext.Set<TEntity>().AddAsync(data);
                await _blogContext.SaveChangesAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(data)} could not be saved: {ex.Message}");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                _blogContext.Set<TEntity>().Update(data);
                await _blogContext.SaveChangesAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(data)} could not be updated: {ex.Message}");
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _blogContext.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                throw new Exception($"{nameof(id)} could not be found.");
            }

            _blogContext.Set<TEntity>().Remove(entity);
            await _blogContext.SaveChangesAsync();
            return true;
        }



        public async Task<TEntity> GetByIdAsync(int id, IBaseSpecifications<TEntity> baseSpecifications = null)
        {
            try
            {
                var item = await SpecificationEvaluator<TEntity>.GetQuery(_blogContext.Set<TEntity>()
                                        .Where(x => x.Id == id)
                                        .AsQueryable(), baseSpecifications)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync();

                if (item == null)
                {
                    throw new Exception($"Couldn't find entity with id={id}");
                }

                return item;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entity with id={id}: {ex.Message}");
            }
        }
    }
}