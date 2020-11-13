using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class PostService
    {
        private readonly Guid _userId;
        public PostService(Guid userId) // Creater a constructor
        {
            _userId = userId;
        }

        // Posting a post

        public bool CreatePost(PostAPost model)
        {
            var entity = new Post()
            {
                Author = _userId,
                Title = model.Title,
                Text = model.Text
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

      


        // Get post

        public IEnumerable<GetPosts> GetPost()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts
                        .Where(e => e.Author == _userId)
                        .Select(e => new GetPosts
                        {
                            Id = e.Id,
                            Title = e.Title,
                            Text = e.Text
                        });
                return query.ToArray();
            }
        }

      

    }
}
