using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class LikeService
    {
		private readonly Guid _userId;
		public LikeService(Guid userId)
		{
			_userId = userId;
		}

		// Posting like

		public bool LikeAPost(PostALikeToAPost model)
		{
			var entity = new Like()
			{
				Liker = _userId,
				PostId = model.PostId
			};

			using (var ctx = new ApplicationDbContext())
			{
				ctx.Likes.Add(entity);
				return ctx.SaveChanges() == 1;
			}
		}

	}
}
