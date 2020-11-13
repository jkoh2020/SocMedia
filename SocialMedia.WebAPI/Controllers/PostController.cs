using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SocialMedia.WebAPI.Controllers
{
    public class PostController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // Post
        [HttpPost]

        public async Task<IHttpActionResult> Create(Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Posts.Add(post);
                await _context.SaveChangesAsync();
                return Ok();
            }

            return BadRequest(ModelState); // 400
        }

        // Read
        [HttpGet]

        public async Task<IHttpActionResult> GetAll()
        {
            List<Post> posts = await _context.Posts.ToListAsync();
            return Ok(posts);
        }
    }
}
