using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "UrlSlug cannot be longer than 50 characters.")]
        public string UrlSlug { get; set; }

        public string Description { get; set; }

        public ICollection<PostTag> PostTags { get; set; }
    }
}
