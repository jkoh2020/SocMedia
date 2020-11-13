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
using System.Web.Http.ModelBinding;

namespace SocialMedia.WebAPI.Controllers
{
    public class CommentController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
          private CommentService CreateService()
          {
         var userId = Guid.Parse(User.Identity.GetUserId());
         var commentService = new CommentService(userId);
             return commentService;
        }


         public IHttpActionResult Create(PostACommentOnAPost comment)
          {
           if (!ModelState.IsValid)
                 return BadRequest(ModelState);
            var service = CreateService();
            if (!service.CreateComment(comment))
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
