using learn_specification.Entities;
using learn_specification.interfaces;
using learn_specification.Repositories.PostRepository;
using learn_specification.Specifications;

namespace learn_specification.Services
{
    // Posts: Business Layer Implementation
    public class PostsService : BaseService<IPostsRepository, Post>, IPostsService
    {
        public PostsService(IPostsRepository repository, ILogger<PostsService> logger)
            : base(repository, logger)
        {
        }
        public Task<Post> GetById(int id)
        {
            return Repository.GetByIdAsync(id, new PostRelatedDataSpecifications());
        }
    }
}