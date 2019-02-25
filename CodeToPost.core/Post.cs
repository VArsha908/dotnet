using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodeToPost.core
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        public string Name {get; set;}
        [Required]
        public string Message { get; set; }
        public int Like { get; set; }
        public string Comment { get; set; }
    }
}
