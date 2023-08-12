using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using efcore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efcore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public BlogController(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        [HttpPost]
        public async Task<IActionResult> createBlog()
        {
            object author = new Blog { BlogId = 1, Url = "hahaha", Rating = 2 };
            _appDbContext.Add(author);
            _appDbContext.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> updateBlog()
        {
            var blog = new Blog
            {
                BlogId = 1,
                Url = "asdasd2123123123",
                Rating = 5,
                Posts = new List<Post>{
                    new Post
                {
                    Content = "sdadasdsad",
                    Title = "sdadads"
                }
                }
            };
            _appDbContext.Update(blog);
            _appDbContext.Attach(blog);
            _appDbContext.Entry(blog).Property("Url").IsModified = true;
            _appDbContext.SaveChanges();
            return Ok();
        }
        [HttpPut("s")]
        public async Task<IActionResult> UpdateBlog2()
        {

            var author = new Author
            {
                AuthorId = 1,
                FirstName = "William",
                LastName = "Shakespeare",
                Books = new List<Book>{
                    new Book { Title = "Hamlet", Isbn = "1234" }
                }
            };
            _appDbContext.Add(author);
            _appDbContext.SaveChanges();

            return Ok();
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteBlog()
        {
            var context = _appDbContext;
            var author = context.Authors.Single(a => a.AuthorId == 1);
            var books = context.Books.Where(b => EF.Property<int>(b, "AuthorId") == 1);
            foreach (var book in books)
            {
                author.Books.Remove(book);
            }
            context.Remove(author);
            context.SaveChanges();

            return Ok();
        }
    }
}
