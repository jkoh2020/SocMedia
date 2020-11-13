using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class ReplyService
    {
        private readonly Guid _userId;
        public ReplyService(Guid userId)
        {
            _userId = userId;
        }

        // Post reply

        public bool CreateReply(PostAReplyToAComment model)
        {
            var entity = new Reply()
            {
                Author = _userId,
                Text = model.Text
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // Get reply

        public IEnumerable<GetCommentReplies> GetComment()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts
                        .Where(e => e.Author == _userId)
                        .Select(e => new GetCommentReplies
                        {
                            Id = e.Id,
                            Text = e.Text
                        });
                return query.ToArray();
            }
        }
    }
}
