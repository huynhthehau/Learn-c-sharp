using learn_specification.Data;
using learn_specification.Entities;
using learn_specification.Repositories.BaseRepository;

namespace learn_specification.Repositories.TagRepository
{
    // Tags Repository : Implementation

    public class TagsRepository : BaseRepository<Tag>, ITagsRepository
    {
        public TagsRepository(BlogContext blogContext) : base(blogContext)
        {
        }
    }
}