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
    public class ReplyController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private ReplyService CreateService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var replyService = new ReplyService(userId);
            return replyService;
        }


        public IHttpActionResult Create(PostAReplyToAComment comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateService();
            if (!service.CreateReply(comment))
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
