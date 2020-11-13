using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
	public class LikeAPost
	{
		[Required]
		public bool Liked { get; set; }
		public int PostId { get; set; }
	}
}
