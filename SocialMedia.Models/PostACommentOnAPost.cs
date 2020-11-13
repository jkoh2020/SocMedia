using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
   public class PostACommentOnAPost
    {
        [Required]
        [MaxLength(5000)]
        public string Text { get; set; }
    }
}
