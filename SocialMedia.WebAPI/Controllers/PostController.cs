using Microsoft.AspNet.Identity;
using SocialMedia.Data;
using SocialMedia.Models;
using SocialMedia.Services;
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
    [Authorize]
    public class PostController : ApiController
    {
        
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private PostService CreateService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var postService = new PostService(userId);
            return postService;
        }

        // Post
       // [HttpPost]

        // public async Task<IHttpActionResult> Create(Post post)
        // {
        //    if (ModelState.IsValid)
        //    {
        //  _context.Posts.Add(post);
        // await _context.SaveChangesAsync();
        //         return Ok();
        // }

        //       return BadRequest(ModelState); // 400
        // }
        
        public IHttpActionResult Create(PostAPost post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateService();
            if (!service.CreatePost(post))
                return InternalServerError();
            return Ok(); // 200

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
