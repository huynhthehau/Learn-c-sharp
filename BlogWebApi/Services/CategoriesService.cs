using learn_specification.Entities;
using learn_specification.interfaces;
using learn_specification.Repositories.CategoryRepository;

namespace learn_specification.Services
{
    // Posts: Business Layer Implementation
    public class CategoriesService : BaseService<ICategoriesRepository, Category>, ICategoriesService
    {
        public CategoriesService(ICategoriesRepository repository, ILogger<CategoriesService> logger)
            : base(repository, logger)
        {
        }
    }
}