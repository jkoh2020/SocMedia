using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class PostALikeToAPost
    {
        public Post LikedPost { get; set; }

        public Guid Liker { get; set; }
    }
}
