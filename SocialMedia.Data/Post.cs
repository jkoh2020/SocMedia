using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Data
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        public Guid Author { get; set; }  
    }
}
