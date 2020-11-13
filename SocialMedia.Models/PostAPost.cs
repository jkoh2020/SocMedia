using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class PostAPost
    {
        // Validation for the post properties

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(120, ErrorMessage = "There are too many characters in this title field")]
        public string Title { get; set; }
        [MaxLength(5000)]
        public string Text { get; set; }
    }
}
