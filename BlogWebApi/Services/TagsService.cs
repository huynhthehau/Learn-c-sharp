using learn_specification.Entities;
using learn_specification.interfaces;
using learn_specification.Repositories.PostRepository;
using learn_specification.Repositories.TagRepository;

namespace learn_specification.Services
{
    public class TagsService : BaseService<ITagsRepository, Tag>, ITagsService
    {
        public TagsService(ITagsRepository repository, ILogger<TagsService> logger)
            : base(repository, logger)
        {
        }
    }
}