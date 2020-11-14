using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace SocialMedia.Services
{
    public class CommentService
    {
        private readonly Guid _userId;
        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        // Posting a comment

        public bool CreateComment(PostACommentOnAPost model)
        {
            var entity = new Comment()
            {
                Author = _userId,
                RepliesId = model.RepliesId,
                Text = model.Text
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // Get comment

        public IEnumerable<GetPostComments> GetComment()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts
                        .Where(e => e.Author == _userId)
                        .Select(e => new GetPostComments
                        {
                            Id = e.Id,
                            Text = e.Text
                        });
                return query.ToArray();
            }
        }
    }
}
