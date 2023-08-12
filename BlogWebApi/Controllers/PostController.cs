using AutoMapper;
using learn_specification.Data;
using learn_specification.Entities;
using learn_specification.interfaces;
using learn_specification.Models.PostModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace learn_specification.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostsService _postsService;
        private readonly IMapper _mapper;
        private readonly ILogger<PostsController> _logger;

        public PostsController(IPostsService postsService, IMapper mapper, ILogger<PostsController> logger)
        {
            this._postsService = postsService;
            this._mapper = mapper;
            this._logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _postsService.GetAllAsync();
            return Ok(_mapper.Map<IList<PostModel>>(posts));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostModel newPost)
        {
            if (newPost == null)
            {
                return BadRequest();
            }

            var post = _mapper.Map<Post>(newPost);

            post.PostCategories = new List<PostCategories>();
            foreach (var category in newPost.PostCategories)
            {
                post.PostCategories.Add(new PostCategories()
                {
                    CategoryId = category.Id,
                    Post = post
                });
            }

            await _postsService.CreateAsync(post);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Post postModel)
        {
            if (postModel == null || id <= 0)
            {
                return BadRequest();
            }

            postModel.Id = id;
            var post = _mapper.Map<Post>(postModel);
            await _postsService.UpdateAsync(post);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var isDeleted = await _postsService.DeleteAsync(id);
            return Ok(isDeleted);
        }
    }
}