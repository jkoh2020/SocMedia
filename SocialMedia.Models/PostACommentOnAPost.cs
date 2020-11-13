using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
   public class PostACommentOnAPost
        //Max post length of 5000
    {
        [Required]
        [MaxLength(5000)]
        public string Text { get; set; }
        public int RepliesId { get; set; }
    }
}
