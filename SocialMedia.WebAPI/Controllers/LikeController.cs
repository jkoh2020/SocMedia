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
    public class LikeController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private LikeService CreateService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var likeService = new LikeService(userId);
            return likeService;
        }

        // Post like
        public IHttpActionResult Create(PostALikeToAPost comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateService();
            if (!service.LikeAPost(comment))
                return InternalServerError();

            return Ok(); // 200

        }

        // Read
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Like> likes = await _context.Likes.ToListAsync();
            return Ok(likes);
        }
    }
}
