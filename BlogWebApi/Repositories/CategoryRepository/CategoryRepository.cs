using learn_specification.Data;
using learn_specification.Entities;
using learn_specification.Repositories.BaseRepository;

namespace learn_specification.Repositories.CategoryRepository
{
    public class CategoriesRepository : BaseRepository<Category>, ICategoriesRepository
    {
        public CategoriesRepository(BlogContext blogContext) : base(blogContext)
        {
        }
    }
}