using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController: ControllerBase
    {
        private readonly DataContext _context;

        public PostsController(DataContext context)
        {
            this._context = context;
        }

        // GET api/posts
        [HttpGet(Name = "GetPosts")]
        public ActionResult<List<Post>> Get()
        {
            return this._context.Posts.ToList();
        }

        [HttpGet("{id}", Name = "GetPostById")]
         public ActionResult<Post> GetById(int id)
        {
            var post = _context.Posts.Find(id);

            if (post is null)
            {
                return NotFound();
            }

            return Ok(post);
        }
    }
}
