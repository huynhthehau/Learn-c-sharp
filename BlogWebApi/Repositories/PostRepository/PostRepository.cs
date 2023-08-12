using learn_specification.Data;
using learn_specification.Entities;
using learn_specification.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace learn_specification.Repositories.PostRepository
{
    public class PostsRepository : BaseRepository<Post>, IPostsRepository
    {
        public PostsRepository(BlogContext blogContext) : base(blogContext)
        {
        }
        public async Task<Post> GetById_Eager(int id)
        {
            var post = await _blogContext.Posts.Where(x => x.Id == id)
                            .Include(x => x.PostTags)
                            .Include(x => x.PostCategories)
                            .Include(x => x.Comments)
                            .FirstOrDefaultAsync();
            if (post == null)
            {
                throw new Exception($"Post with ID:{id} Not Found");
            }

            return post;
        }
        public async Task<Post> GetById_Explicit(int id)
        {
            // Load Principal Entity
            var post = await _blogContext.Posts.FirstOrDefaultAsync(x => x.Id == id);

            // Explicit Loading for related categories
            _blogContext.Entry<Post>(post)
                .Collection(p => p.PostCategories)
                .Load();

            // Explicit Loading for related tags
            _blogContext.Entry<Post>(post)
                .Collection(p => p.PostTags)
                .Load();

            // Explicit Loading for related comments
            _blogContext.Entry<Post>(post)
                .Collection(p => p.Comments)
                .Load();

            if (post == null)
            {
                throw new Exception($"Post with ID:{id} Not Found");
            }

            return post;
        }
    }

}